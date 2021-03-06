using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using Nito.AsyncEx;
using Omnius.Core;
using Omnius.Core.Cryptography;
using Omnius.Core.Helpers;
using Omnius.Xeus.Engines.Storages.Internal.Models;
using Omnius.Xeus.Engines.Storages.Internal.Repositories.Entities;
using Omnius.Xeus.Utils.Extentions;

namespace Omnius.Xeus.Engines.Storages.Internal.Repositories
{
    internal sealed partial class DeclaredMessagePublisherRepository : DisposableBase
    {
        private readonly LiteDatabase _database;

        public DeclaredMessagePublisherRepository(string dirPath)
        {
            DirectoryHelper.CreateDirectory(dirPath);

            _database = new LiteDatabase(Path.Combine(dirPath, "lite.db"));
            this.Items = new PublishedDeclaredMessageItemRepository(_database);
        }

        protected override void OnDispose(bool disposing)
        {
            _database.Dispose();
        }

        public async ValueTask MigrateAsync(CancellationToken cancellationToken = default)
        {
            await this.Items.MigrateAsync(cancellationToken);
        }

        public PublishedDeclaredMessageItemRepository Items { get; }

        public sealed class PublishedDeclaredMessageItemRepository
        {
            private const string CollectionName = "published_items";

            private readonly LiteDatabase _database;

            private readonly AsyncReaderWriterLock _asyncLock = new();

            public PublishedDeclaredMessageItemRepository(LiteDatabase database)
            {
                _database = database;
            }

            internal async ValueTask MigrateAsync(CancellationToken cancellationToken = default)
            {
                using (await _asyncLock.WriterLockAsync(cancellationToken))
                {
                    if (_database.GetDocumentVersion(CollectionName) <= 0)
                    {
                        var col = this.GetCollection();
                        col.EnsureIndex(x => x.Signature, false);
                    }

                    _database.SetDocumentVersion(CollectionName, 1);
                }
            }

            public ILiteCollection<PublishedDeclaredMessageItemEntity> GetCollection()
            {
                var col = _database.GetCollection<PublishedDeclaredMessageItemEntity>(CollectionName);
                return col;
            }

            public bool Exists(OmniSignature signature)
            {
                using (_asyncLock.ReaderLock())
                {
                    var signatureEntity = OmniSignatureEntity.Import(signature);

                    var col = this.GetCollection();
                    return col.Exists(n => n.Signature == signatureEntity);
                }
            }

            public IEnumerable<PublishedDeclaredMessageItem> FindAll()
            {
                using (_asyncLock.ReaderLock())
                {
                    var col = this.GetCollection();
                    return col.FindAll().Select(n => n.Export());
                }
            }

            public IEnumerable<PublishedDeclaredMessageItem> Find(OmniSignature signature)
            {
                using (_asyncLock.ReaderLock())
                {
                    var signatureEntity = OmniSignatureEntity.Import(signature);

                    var col = this.GetCollection();
                    return col.Find(n => n.Signature == signatureEntity).Select(n => n.Export());
                }
            }

            public PublishedDeclaredMessageItem? FindOne(OmniSignature signature, string registrant)
            {
                using (_asyncLock.ReaderLock())
                {
                    var signatureEntity = OmniSignatureEntity.Import(signature);

                    var col = this.GetCollection();
                    return col.FindOne(n => n.Signature == signatureEntity && n.Registrant == registrant).Export();
                }
            }

            public void Insert(PublishedDeclaredMessageItem item)
            {
                using (_asyncLock.WriterLock())
                {
                    var itemEntity = PublishedDeclaredMessageItemEntity.Import(item);

                    var col = this.GetCollection();

                    if (col.Exists(n => n.Signature == itemEntity.Signature && n.Registrant == itemEntity.Registrant)) return;

                    col.Insert(itemEntity);
                }
            }

            public void Delete(OmniSignature signature, string registrant)
            {
                using (_asyncLock.WriterLock())
                {
                    var signatureEntity = OmniSignatureEntity.Import(signature);

                    var col = this.GetCollection();
                    col.DeleteMany(n => n.Signature == signatureEntity && n.Registrant == registrant);
                }
            }
        }
    }
}
