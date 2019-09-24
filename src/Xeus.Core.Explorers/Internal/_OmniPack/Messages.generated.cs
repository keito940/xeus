using Omnix.Algorithms.Cryptography;
using Omnix.Network;
using Xeus.Core;

#nullable enable

namespace Xeus.Core.Explorers.Internal
{
    internal enum ProtocolVersion : byte
    {
        Version1 = 1,
    }

    internal sealed partial class BroadcastClue : global::Omnix.Serialization.OmniPack.IOmniPackMessage<BroadcastClue>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<BroadcastClue> Formatter { get; }
        public static BroadcastClue Empty { get; }

        static BroadcastClue()
        {
            BroadcastClue.Formatter = new ___CustomFormatter();
            BroadcastClue.Empty = new BroadcastClue(string.Empty, global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero, Clue.Empty, null);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxTypeLength = 256;

        public BroadcastClue(string type, global::Omnix.Serialization.OmniPack.OmniTimestamp creationTime, Clue clue, OmniCertificate? certificate)
        {
            if (type is null) throw new global::System.ArgumentNullException("type");
            if (type.Length > 256) throw new global::System.ArgumentOutOfRangeException("type");
            if (clue is null) throw new global::System.ArgumentNullException("clue");
            this.Type = type;
            this.CreationTime = creationTime;
            this.Clue = clue;
            this.Certificate = certificate;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (type != default) ___h.Add(type.GetHashCode());
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                if (clue != default) ___h.Add(clue.GetHashCode());
                if (certificate != default) ___h.Add(certificate.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public string Type { get; }
        public global::Omnix.Serialization.OmniPack.OmniTimestamp CreationTime { get; }
        public Clue Clue { get; }
        public OmniCertificate? Certificate { get; }

        public static BroadcastClue Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(BroadcastClue? left, BroadcastClue? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(BroadcastClue? left, BroadcastClue? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is BroadcastClue)) return false;
            return this.Equals((BroadcastClue)other);
        }
        public bool Equals(BroadcastClue? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Type != target.Type) return false;
            if (this.CreationTime != target.CreationTime) return false;
            if (this.Clue != target.Clue) return false;
            if ((this.Certificate is null) != (target.Certificate is null)) return false;
            if (!(this.Certificate is null) && !(target.Certificate is null) && this.Certificate != target.Certificate) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<BroadcastClue>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in BroadcastClue value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Type != string.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.CreationTime != global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero)
                    {
                        propertyCount++;
                    }
                    if (value.Clue != Clue.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.Certificate != null)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Type != string.Empty)
                {
                    w.Write((uint)0);
                    w.Write(value.Type);
                }
                if (value.CreationTime != global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero)
                {
                    w.Write((uint)1);
                    w.Write(value.CreationTime);
                }
                if (value.Clue != Clue.Empty)
                {
                    w.Write((uint)2);
                    Clue.Formatter.Serialize(ref w, value.Clue, rank + 1);
                }
                if (value.Certificate != null)
                {
                    w.Write((uint)3);
                    OmniCertificate.Formatter.Serialize(ref w, value.Certificate, rank + 1);
                }
            }

            public BroadcastClue Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                string p_type = string.Empty;
                global::Omnix.Serialization.OmniPack.OmniTimestamp p_creationTime = global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero;
                Clue p_clue = Clue.Empty;
                OmniCertificate? p_certificate = null;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                p_type = r.GetString(256);
                                break;
                            }
                        case 1:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                        case 2:
                            {
                                p_clue = Clue.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 3:
                            {
                                p_certificate = OmniCertificate.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new BroadcastClue(p_type, p_creationTime, p_clue, p_certificate);
            }
        }
    }

    internal sealed partial class UnicastClue : global::Omnix.Serialization.OmniPack.IOmniPackMessage<UnicastClue>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<UnicastClue> Formatter { get; }
        public static UnicastClue Empty { get; }

        static UnicastClue()
        {
            UnicastClue.Formatter = new ___CustomFormatter();
            UnicastClue.Empty = new UnicastClue(string.Empty, OmniSignature.Empty, global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero, Clue.Empty, null);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxTypeLength = 256;

        public UnicastClue(string type, OmniSignature signature, global::Omnix.Serialization.OmniPack.OmniTimestamp creationTime, Clue clue, OmniCertificate? certificate)
        {
            if (type is null) throw new global::System.ArgumentNullException("type");
            if (type.Length > 256) throw new global::System.ArgumentOutOfRangeException("type");
            if (signature is null) throw new global::System.ArgumentNullException("signature");
            if (clue is null) throw new global::System.ArgumentNullException("clue");
            this.Type = type;
            this.Signature = signature;
            this.CreationTime = creationTime;
            this.Clue = clue;
            this.Certificate = certificate;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (type != default) ___h.Add(type.GetHashCode());
                if (signature != default) ___h.Add(signature.GetHashCode());
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                if (clue != default) ___h.Add(clue.GetHashCode());
                if (certificate != default) ___h.Add(certificate.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public string Type { get; }
        public OmniSignature Signature { get; }
        public global::Omnix.Serialization.OmniPack.OmniTimestamp CreationTime { get; }
        public Clue Clue { get; }
        public OmniCertificate? Certificate { get; }

        public static UnicastClue Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(UnicastClue? left, UnicastClue? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(UnicastClue? left, UnicastClue? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is UnicastClue)) return false;
            return this.Equals((UnicastClue)other);
        }
        public bool Equals(UnicastClue? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Type != target.Type) return false;
            if (this.Signature != target.Signature) return false;
            if (this.CreationTime != target.CreationTime) return false;
            if (this.Clue != target.Clue) return false;
            if ((this.Certificate is null) != (target.Certificate is null)) return false;
            if (!(this.Certificate is null) && !(target.Certificate is null) && this.Certificate != target.Certificate) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<UnicastClue>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in UnicastClue value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Type != string.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.Signature != OmniSignature.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.CreationTime != global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero)
                    {
                        propertyCount++;
                    }
                    if (value.Clue != Clue.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.Certificate != null)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Type != string.Empty)
                {
                    w.Write((uint)0);
                    w.Write(value.Type);
                }
                if (value.Signature != OmniSignature.Empty)
                {
                    w.Write((uint)1);
                    OmniSignature.Formatter.Serialize(ref w, value.Signature, rank + 1);
                }
                if (value.CreationTime != global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero)
                {
                    w.Write((uint)2);
                    w.Write(value.CreationTime);
                }
                if (value.Clue != Clue.Empty)
                {
                    w.Write((uint)3);
                    Clue.Formatter.Serialize(ref w, value.Clue, rank + 1);
                }
                if (value.Certificate != null)
                {
                    w.Write((uint)4);
                    OmniCertificate.Formatter.Serialize(ref w, value.Certificate, rank + 1);
                }
            }

            public UnicastClue Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                string p_type = string.Empty;
                OmniSignature p_signature = OmniSignature.Empty;
                global::Omnix.Serialization.OmniPack.OmniTimestamp p_creationTime = global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero;
                Clue p_clue = Clue.Empty;
                OmniCertificate? p_certificate = null;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                p_type = r.GetString(256);
                                break;
                            }
                        case 1:
                            {
                                p_signature = OmniSignature.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                        case 3:
                            {
                                p_clue = Clue.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 4:
                            {
                                p_certificate = OmniCertificate.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new UnicastClue(p_type, p_signature, p_creationTime, p_clue, p_certificate);
            }
        }
    }

    internal sealed partial class MulticastClue : global::Omnix.Serialization.OmniPack.IOmniPackMessage<MulticastClue>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<MulticastClue> Formatter { get; }
        public static MulticastClue Empty { get; }

        static MulticastClue()
        {
            MulticastClue.Formatter = new ___CustomFormatter();
            MulticastClue.Empty = new MulticastClue(string.Empty, OmniSignature.Empty, global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero, Clue.Empty, null, null);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxTypeLength = 256;

        public MulticastClue(string type, OmniSignature signature, global::Omnix.Serialization.OmniPack.OmniTimestamp creationTime, Clue clue, OmniHashcash? hashcash, OmniCertificate? certificate)
        {
            if (type is null) throw new global::System.ArgumentNullException("type");
            if (type.Length > 256) throw new global::System.ArgumentOutOfRangeException("type");
            if (signature is null) throw new global::System.ArgumentNullException("signature");
            if (clue is null) throw new global::System.ArgumentNullException("clue");
            this.Type = type;
            this.Signature = signature;
            this.CreationTime = creationTime;
            this.Clue = clue;
            this.Hashcash = hashcash;
            this.Certificate = certificate;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (type != default) ___h.Add(type.GetHashCode());
                if (signature != default) ___h.Add(signature.GetHashCode());
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                if (clue != default) ___h.Add(clue.GetHashCode());
                if (hashcash != default) ___h.Add(hashcash.GetHashCode());
                if (certificate != default) ___h.Add(certificate.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public string Type { get; }
        public OmniSignature Signature { get; }
        public global::Omnix.Serialization.OmniPack.OmniTimestamp CreationTime { get; }
        public Clue Clue { get; }
        public OmniHashcash? Hashcash { get; }
        public OmniCertificate? Certificate { get; }

        public static MulticastClue Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(MulticastClue? left, MulticastClue? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(MulticastClue? left, MulticastClue? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is MulticastClue)) return false;
            return this.Equals((MulticastClue)other);
        }
        public bool Equals(MulticastClue? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Type != target.Type) return false;
            if (this.Signature != target.Signature) return false;
            if (this.CreationTime != target.CreationTime) return false;
            if (this.Clue != target.Clue) return false;
            if ((this.Hashcash is null) != (target.Hashcash is null)) return false;
            if (!(this.Hashcash is null) && !(target.Hashcash is null) && this.Hashcash != target.Hashcash) return false;
            if ((this.Certificate is null) != (target.Certificate is null)) return false;
            if (!(this.Certificate is null) && !(target.Certificate is null) && this.Certificate != target.Certificate) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<MulticastClue>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in MulticastClue value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Type != string.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.Signature != OmniSignature.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.CreationTime != global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero)
                    {
                        propertyCount++;
                    }
                    if (value.Clue != Clue.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.Hashcash != null)
                    {
                        propertyCount++;
                    }
                    if (value.Certificate != null)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Type != string.Empty)
                {
                    w.Write((uint)0);
                    w.Write(value.Type);
                }
                if (value.Signature != OmniSignature.Empty)
                {
                    w.Write((uint)1);
                    OmniSignature.Formatter.Serialize(ref w, value.Signature, rank + 1);
                }
                if (value.CreationTime != global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero)
                {
                    w.Write((uint)2);
                    w.Write(value.CreationTime);
                }
                if (value.Clue != Clue.Empty)
                {
                    w.Write((uint)3);
                    Clue.Formatter.Serialize(ref w, value.Clue, rank + 1);
                }
                if (value.Hashcash != null)
                {
                    w.Write((uint)4);
                    OmniHashcash.Formatter.Serialize(ref w, value.Hashcash, rank + 1);
                }
                if (value.Certificate != null)
                {
                    w.Write((uint)5);
                    OmniCertificate.Formatter.Serialize(ref w, value.Certificate, rank + 1);
                }
            }

            public MulticastClue Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                string p_type = string.Empty;
                OmniSignature p_signature = OmniSignature.Empty;
                global::Omnix.Serialization.OmniPack.OmniTimestamp p_creationTime = global::Omnix.Serialization.OmniPack.OmniTimestamp.Zero;
                Clue p_clue = Clue.Empty;
                OmniHashcash? p_hashcash = null;
                OmniCertificate? p_certificate = null;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                p_type = r.GetString(256);
                                break;
                            }
                        case 1:
                            {
                                p_signature = OmniSignature.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                        case 3:
                            {
                                p_clue = Clue.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 4:
                            {
                                p_hashcash = OmniHashcash.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 5:
                            {
                                p_certificate = OmniCertificate.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new MulticastClue(p_type, p_signature, p_creationTime, p_clue, p_hashcash, p_certificate);
            }
        }
    }

    internal sealed partial class ContentLocation : global::Omnix.Serialization.OmniPack.IOmniPackMessage<ContentLocation>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<ContentLocation> Formatter { get; }
        public static ContentLocation Empty { get; }

        static ContentLocation()
        {
            ContentLocation.Formatter = new ___CustomFormatter();
            ContentLocation.Empty = new ContentLocation(OmniAddress.Empty, global::System.Array.Empty<Clue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxCluesCount = 65536;

        public ContentLocation(OmniAddress address, Clue[] clues)
        {
            if (address is null) throw new global::System.ArgumentNullException("address");
            if (clues is null) throw new global::System.ArgumentNullException("clues");
            if (clues.Length > 65536) throw new global::System.ArgumentOutOfRangeException("clues");
            foreach (var n in clues)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Address = address;
            this.Clues = new global::Omnix.DataStructures.ReadOnlyListSlim<Clue>(clues);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (address != default) ___h.Add(address.GetHashCode());
                foreach (var n in clues)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public OmniAddress Address { get; }
        public global::Omnix.DataStructures.ReadOnlyListSlim<Clue> Clues { get; }

        public static ContentLocation Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(ContentLocation? left, ContentLocation? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(ContentLocation? left, ContentLocation? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is ContentLocation)) return false;
            return this.Equals((ContentLocation)other);
        }
        public bool Equals(ContentLocation? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Address != target.Address) return false;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Clues, target.Clues)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<ContentLocation>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in ContentLocation value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Address != OmniAddress.Empty)
                    {
                        propertyCount++;
                    }
                    if (value.Clues.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Address != OmniAddress.Empty)
                {
                    w.Write((uint)0);
                    OmniAddress.Formatter.Serialize(ref w, value.Address, rank + 1);
                }
                if (value.Clues.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Clues.Count);
                    foreach (var n in value.Clues)
                    {
                        Clue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public ContentLocation Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                OmniAddress p_address = OmniAddress.Empty;
                Clue[] p_clues = global::System.Array.Empty<Clue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                p_address = OmniAddress.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_clues = new Clue[length];
                                for (int i = 0; i < p_clues.Length; i++)
                                {
                                    p_clues[i] = Clue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new ContentLocation(p_address, p_clues);
            }
        }
    }

    internal sealed partial class RelayOption : global::Omnix.Serialization.OmniPack.IOmniPackMessage<RelayOption>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<RelayOption> Formatter { get; }
        public static RelayOption Empty { get; }

        static RelayOption()
        {
            RelayOption.Formatter = new ___CustomFormatter();
            RelayOption.Empty = new RelayOption(0, 0);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public RelayOption(byte hopLimit, byte priority)
        {
            this.HopLimit = hopLimit;
            this.Priority = priority;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (hopLimit != default) ___h.Add(hopLimit.GetHashCode());
                if (priority != default) ___h.Add(priority.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public byte HopLimit { get; }
        public byte Priority { get; }

        public static RelayOption Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(RelayOption? left, RelayOption? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(RelayOption? left, RelayOption? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is RelayOption)) return false;
            return this.Equals((RelayOption)other);
        }
        public bool Equals(RelayOption? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.HopLimit != target.HopLimit) return false;
            if (this.Priority != target.Priority) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<RelayOption>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in RelayOption value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.HopLimit != 0)
                    {
                        propertyCount++;
                    }
                    if (value.Priority != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.HopLimit != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.HopLimit);
                }
                if (value.Priority != 0)
                {
                    w.Write((uint)1);
                    w.Write(value.Priority);
                }
            }

            public RelayOption Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                byte p_hopLimit = 0;
                byte p_priority = 0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                p_hopLimit = r.GetUInt8();
                                break;
                            }
                        case 1:
                            {
                                p_priority = r.GetUInt8();
                                break;
                            }
                    }
                }

                return new RelayOption(p_hopLimit, p_priority);
            }
        }
    }

    internal sealed partial class HelloMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<HelloMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<HelloMessage> Formatter { get; }
        public static HelloMessage Empty { get; }

        static HelloMessage()
        {
            HelloMessage.Formatter = new ___CustomFormatter();
            HelloMessage.Empty = new HelloMessage(global::System.Array.Empty<ProtocolVersion>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxProtocolVersionsCount = 32;

        public HelloMessage(ProtocolVersion[] protocolVersions)
        {
            if (protocolVersions is null) throw new global::System.ArgumentNullException("protocolVersions");
            if (protocolVersions.Length > 32) throw new global::System.ArgumentOutOfRangeException("protocolVersions");

            this.ProtocolVersions = new global::Omnix.DataStructures.ReadOnlyListSlim<ProtocolVersion>(protocolVersions);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in protocolVersions)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<ProtocolVersion> ProtocolVersions { get; }

        public static HelloMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(HelloMessage? left, HelloMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(HelloMessage? left, HelloMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is HelloMessage)) return false;
            return this.Equals((HelloMessage)other);
        }
        public bool Equals(HelloMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.ProtocolVersions, target.ProtocolVersions)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<HelloMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in HelloMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.ProtocolVersions.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.ProtocolVersions.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.ProtocolVersions.Count);
                    foreach (var n in value.ProtocolVersions)
                    {
                        w.Write((ulong)n);
                    }
                }
            }

            public HelloMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                ProtocolVersion[] p_protocolVersions = global::System.Array.Empty<ProtocolVersion>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_protocolVersions = new ProtocolVersion[length];
                                for (int i = 0; i < p_protocolVersions.Length; i++)
                                {
                                    p_protocolVersions[i] = (ProtocolVersion)r.GetUInt64();
                                }
                                break;
                            }
                    }
                }

                return new HelloMessage(p_protocolVersions);
            }
        }
    }

    internal sealed partial class ProfileMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<ProfileMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<ProfileMessage> Formatter { get; }
        public static ProfileMessage Empty { get; }

        static ProfileMessage()
        {
            ProfileMessage.Formatter = new ___CustomFormatter();
            ProfileMessage.Empty = new ProfileMessage(global::System.ReadOnlyMemory<byte>.Empty, OmniAddress.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxIdLength = 32;

        public ProfileMessage(global::System.ReadOnlyMemory<byte> id, OmniAddress address)
        {
            if (id.Length > 32) throw new global::System.ArgumentOutOfRangeException("id");
            if (address is null) throw new global::System.ArgumentNullException("address");

            this.Id = id;
            this.Address = address;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (!id.IsEmpty) ___h.Add(global::Omnix.Base.Helpers.ObjectHelper.GetHashCode(id.Span));
                if (address != default) ___h.Add(address.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public global::System.ReadOnlyMemory<byte> Id { get; }
        public OmniAddress Address { get; }

        public static ProfileMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(ProfileMessage? left, ProfileMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(ProfileMessage? left, ProfileMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is ProfileMessage)) return false;
            return this.Equals((ProfileMessage)other);
        }
        public bool Equals(ProfileMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.BytesOperations.SequenceEqual(this.Id.Span, target.Id.Span)) return false;
            if (this.Address != target.Address) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<ProfileMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in ProfileMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (!value.Id.IsEmpty)
                    {
                        propertyCount++;
                    }
                    if (value.Address != OmniAddress.Empty)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (!value.Id.IsEmpty)
                {
                    w.Write((uint)0);
                    w.Write(value.Id.Span);
                }
                if (value.Address != OmniAddress.Empty)
                {
                    w.Write((uint)1);
                    OmniAddress.Formatter.Serialize(ref w, value.Address, rank + 1);
                }
            }

            public ProfileMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                global::System.ReadOnlyMemory<byte> p_id = global::System.ReadOnlyMemory<byte>.Empty;
                OmniAddress p_address = OmniAddress.Empty;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                p_id = r.GetMemory(32);
                                break;
                            }
                        case 1:
                            {
                                p_address = OmniAddress.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new ProfileMessage(p_id, p_address);
            }
        }
    }

    internal sealed partial class NodeAddressesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<NodeAddressesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<NodeAddressesMessage> Formatter { get; }
        public static NodeAddressesMessage Empty { get; }

        static NodeAddressesMessage()
        {
            NodeAddressesMessage.Formatter = new ___CustomFormatter();
            NodeAddressesMessage.Empty = new NodeAddressesMessage(global::System.Array.Empty<OmniAddress>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 256;

        public NodeAddressesMessage(OmniAddress[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 256) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<OmniAddress>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<OmniAddress> Values { get; }

        public static NodeAddressesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(NodeAddressesMessage? left, NodeAddressesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(NodeAddressesMessage? left, NodeAddressesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is NodeAddressesMessage)) return false;
            return this.Equals((NodeAddressesMessage)other);
        }
        public bool Equals(NodeAddressesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<NodeAddressesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in NodeAddressesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        OmniAddress.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public NodeAddressesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                OmniAddress[] p_values = global::System.Array.Empty<OmniAddress>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new OmniAddress[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = OmniAddress.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new NodeAddressesMessage(p_values);
            }
        }
    }

    internal sealed partial class WantBroadcastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<WantBroadcastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantBroadcastCluesMessage> Formatter { get; }
        public static WantBroadcastCluesMessage Empty { get; }

        static WantBroadcastCluesMessage()
        {
            WantBroadcastCluesMessage.Formatter = new ___CustomFormatter();
            WantBroadcastCluesMessage.Empty = new WantBroadcastCluesMessage(new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxParametersCount = 8192;

        public WantBroadcastCluesMessage(global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption> parameters)
        {
            if (parameters is null) throw new global::System.ArgumentNullException("parameters");
            if (parameters.Count > 8192) throw new global::System.ArgumentOutOfRangeException("parameters");
            foreach (var n in parameters)
            {
                if (n.Key is null) throw new global::System.ArgumentNullException("n.Key");
                if (n.Value is null) throw new global::System.ArgumentNullException("n.Value");
            }

            this.Parameters = new global::Omnix.DataStructures.ReadOnlyDictionarySlim<OmniSignature, RelayOption>(parameters);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in parameters)
                {
                    if (n.Key != default) ___h.Add(n.Key.GetHashCode());
                    if (n.Value != default) ___h.Add(n.Value.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyDictionarySlim<OmniSignature, RelayOption> Parameters { get; }

        public static WantBroadcastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(WantBroadcastCluesMessage? left, WantBroadcastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(WantBroadcastCluesMessage? left, WantBroadcastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is WantBroadcastCluesMessage)) return false;
            return this.Equals((WantBroadcastCluesMessage)other);
        }
        public bool Equals(WantBroadcastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Parameters, target.Parameters)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantBroadcastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in WantBroadcastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Parameters.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Parameters.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Parameters.Count);
                    foreach (var n in value.Parameters)
                    {
                        OmniSignature.Formatter.Serialize(ref w, n.Key, rank + 1);
                        RelayOption.Formatter.Serialize(ref w, n.Value, rank + 1);
                    }
                }
            }

            public WantBroadcastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption> p_parameters = new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_parameters = new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>();
                                OmniSignature t_key = OmniSignature.Empty;
                                RelayOption t_value = RelayOption.Empty;
                                for (int i = 0; i < length; i++)
                                {
                                    t_key = OmniSignature.Formatter.Deserialize(ref r, rank + 1);
                                    t_value = RelayOption.Formatter.Deserialize(ref r, rank + 1);
                                    p_parameters[t_key] = t_value;
                                }
                                break;
                            }
                    }
                }

                return new WantBroadcastCluesMessage(p_parameters);
            }
        }
    }

    internal sealed partial class PublishBroadcastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<PublishBroadcastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishBroadcastCluesMessage> Formatter { get; }
        public static PublishBroadcastCluesMessage Empty { get; }

        static PublishBroadcastCluesMessage()
        {
            PublishBroadcastCluesMessage.Formatter = new ___CustomFormatter();
            PublishBroadcastCluesMessage.Empty = new PublishBroadcastCluesMessage(global::System.Array.Empty<BroadcastClue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public PublishBroadcastCluesMessage(BroadcastClue[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<BroadcastClue>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<BroadcastClue> Values { get; }

        public static PublishBroadcastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(PublishBroadcastCluesMessage? left, PublishBroadcastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(PublishBroadcastCluesMessage? left, PublishBroadcastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is PublishBroadcastCluesMessage)) return false;
            return this.Equals((PublishBroadcastCluesMessage)other);
        }
        public bool Equals(PublishBroadcastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishBroadcastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in PublishBroadcastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        BroadcastClue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public PublishBroadcastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                BroadcastClue[] p_values = global::System.Array.Empty<BroadcastClue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new BroadcastClue[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = BroadcastClue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new PublishBroadcastCluesMessage(p_values);
            }
        }
    }

    internal sealed partial class BroadcastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<BroadcastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<BroadcastCluesMessage> Formatter { get; }
        public static BroadcastCluesMessage Empty { get; }

        static BroadcastCluesMessage()
        {
            BroadcastCluesMessage.Formatter = new ___CustomFormatter();
            BroadcastCluesMessage.Empty = new BroadcastCluesMessage(global::System.Array.Empty<BroadcastClue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public BroadcastCluesMessage(BroadcastClue[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<BroadcastClue>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<BroadcastClue> Values { get; }

        public static BroadcastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(BroadcastCluesMessage? left, BroadcastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(BroadcastCluesMessage? left, BroadcastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is BroadcastCluesMessage)) return false;
            return this.Equals((BroadcastCluesMessage)other);
        }
        public bool Equals(BroadcastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<BroadcastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in BroadcastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        BroadcastClue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public BroadcastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                BroadcastClue[] p_values = global::System.Array.Empty<BroadcastClue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new BroadcastClue[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = BroadcastClue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new BroadcastCluesMessage(p_values);
            }
        }
    }

    internal sealed partial class WantUnicastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<WantUnicastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantUnicastCluesMessage> Formatter { get; }
        public static WantUnicastCluesMessage Empty { get; }

        static WantUnicastCluesMessage()
        {
            WantUnicastCluesMessage.Formatter = new ___CustomFormatter();
            WantUnicastCluesMessage.Empty = new WantUnicastCluesMessage(new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxParametersCount = 8192;

        public WantUnicastCluesMessage(global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption> parameters)
        {
            if (parameters is null) throw new global::System.ArgumentNullException("parameters");
            if (parameters.Count > 8192) throw new global::System.ArgumentOutOfRangeException("parameters");
            foreach (var n in parameters)
            {
                if (n.Key is null) throw new global::System.ArgumentNullException("n.Key");
                if (n.Value is null) throw new global::System.ArgumentNullException("n.Value");
            }

            this.Parameters = new global::Omnix.DataStructures.ReadOnlyDictionarySlim<OmniSignature, RelayOption>(parameters);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in parameters)
                {
                    if (n.Key != default) ___h.Add(n.Key.GetHashCode());
                    if (n.Value != default) ___h.Add(n.Value.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyDictionarySlim<OmniSignature, RelayOption> Parameters { get; }

        public static WantUnicastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(WantUnicastCluesMessage? left, WantUnicastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(WantUnicastCluesMessage? left, WantUnicastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is WantUnicastCluesMessage)) return false;
            return this.Equals((WantUnicastCluesMessage)other);
        }
        public bool Equals(WantUnicastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Parameters, target.Parameters)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantUnicastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in WantUnicastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Parameters.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Parameters.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Parameters.Count);
                    foreach (var n in value.Parameters)
                    {
                        OmniSignature.Formatter.Serialize(ref w, n.Key, rank + 1);
                        RelayOption.Formatter.Serialize(ref w, n.Value, rank + 1);
                    }
                }
            }

            public WantUnicastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption> p_parameters = new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_parameters = new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>();
                                OmniSignature t_key = OmniSignature.Empty;
                                RelayOption t_value = RelayOption.Empty;
                                for (int i = 0; i < length; i++)
                                {
                                    t_key = OmniSignature.Formatter.Deserialize(ref r, rank + 1);
                                    t_value = RelayOption.Formatter.Deserialize(ref r, rank + 1);
                                    p_parameters[t_key] = t_value;
                                }
                                break;
                            }
                    }
                }

                return new WantUnicastCluesMessage(p_parameters);
            }
        }
    }

    internal sealed partial class PublishUnicastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<PublishUnicastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishUnicastCluesMessage> Formatter { get; }
        public static PublishUnicastCluesMessage Empty { get; }

        static PublishUnicastCluesMessage()
        {
            PublishUnicastCluesMessage.Formatter = new ___CustomFormatter();
            PublishUnicastCluesMessage.Empty = new PublishUnicastCluesMessage(global::System.Array.Empty<UnicastClue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public PublishUnicastCluesMessage(UnicastClue[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<UnicastClue>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<UnicastClue> Values { get; }

        public static PublishUnicastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(PublishUnicastCluesMessage? left, PublishUnicastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(PublishUnicastCluesMessage? left, PublishUnicastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is PublishUnicastCluesMessage)) return false;
            return this.Equals((PublishUnicastCluesMessage)other);
        }
        public bool Equals(PublishUnicastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishUnicastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in PublishUnicastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        UnicastClue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public PublishUnicastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                UnicastClue[] p_values = global::System.Array.Empty<UnicastClue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new UnicastClue[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = UnicastClue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new PublishUnicastCluesMessage(p_values);
            }
        }
    }

    internal sealed partial class UnicastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<UnicastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<UnicastCluesMessage> Formatter { get; }
        public static UnicastCluesMessage Empty { get; }

        static UnicastCluesMessage()
        {
            UnicastCluesMessage.Formatter = new ___CustomFormatter();
            UnicastCluesMessage.Empty = new UnicastCluesMessage(global::System.Array.Empty<UnicastClue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public UnicastCluesMessage(UnicastClue[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<UnicastClue>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<UnicastClue> Values { get; }

        public static UnicastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(UnicastCluesMessage? left, UnicastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(UnicastCluesMessage? left, UnicastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is UnicastCluesMessage)) return false;
            return this.Equals((UnicastCluesMessage)other);
        }
        public bool Equals(UnicastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<UnicastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in UnicastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        UnicastClue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public UnicastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                UnicastClue[] p_values = global::System.Array.Empty<UnicastClue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new UnicastClue[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = UnicastClue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new UnicastCluesMessage(p_values);
            }
        }
    }

    internal sealed partial class WantMulticastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<WantMulticastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantMulticastCluesMessage> Formatter { get; }
        public static WantMulticastCluesMessage Empty { get; }

        static WantMulticastCluesMessage()
        {
            WantMulticastCluesMessage.Formatter = new ___CustomFormatter();
            WantMulticastCluesMessage.Empty = new WantMulticastCluesMessage(new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxParametersCount = 8192;

        public WantMulticastCluesMessage(global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption> parameters)
        {
            if (parameters is null) throw new global::System.ArgumentNullException("parameters");
            if (parameters.Count > 8192) throw new global::System.ArgumentOutOfRangeException("parameters");
            foreach (var n in parameters)
            {
                if (n.Key is null) throw new global::System.ArgumentNullException("n.Key");
                if (n.Value is null) throw new global::System.ArgumentNullException("n.Value");
            }

            this.Parameters = new global::Omnix.DataStructures.ReadOnlyDictionarySlim<OmniSignature, RelayOption>(parameters);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in parameters)
                {
                    if (n.Key != default) ___h.Add(n.Key.GetHashCode());
                    if (n.Value != default) ___h.Add(n.Value.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyDictionarySlim<OmniSignature, RelayOption> Parameters { get; }

        public static WantMulticastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(WantMulticastCluesMessage? left, WantMulticastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(WantMulticastCluesMessage? left, WantMulticastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is WantMulticastCluesMessage)) return false;
            return this.Equals((WantMulticastCluesMessage)other);
        }
        public bool Equals(WantMulticastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Parameters, target.Parameters)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantMulticastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in WantMulticastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Parameters.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Parameters.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Parameters.Count);
                    foreach (var n in value.Parameters)
                    {
                        OmniSignature.Formatter.Serialize(ref w, n.Key, rank + 1);
                        RelayOption.Formatter.Serialize(ref w, n.Value, rank + 1);
                    }
                }
            }

            public WantMulticastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption> p_parameters = new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_parameters = new global::System.Collections.Generic.Dictionary<OmniSignature, RelayOption>();
                                OmniSignature t_key = OmniSignature.Empty;
                                RelayOption t_value = RelayOption.Empty;
                                for (int i = 0; i < length; i++)
                                {
                                    t_key = OmniSignature.Formatter.Deserialize(ref r, rank + 1);
                                    t_value = RelayOption.Formatter.Deserialize(ref r, rank + 1);
                                    p_parameters[t_key] = t_value;
                                }
                                break;
                            }
                    }
                }

                return new WantMulticastCluesMessage(p_parameters);
            }
        }
    }

    internal sealed partial class PublishMulticastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<PublishMulticastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishMulticastCluesMessage> Formatter { get; }
        public static PublishMulticastCluesMessage Empty { get; }

        static PublishMulticastCluesMessage()
        {
            PublishMulticastCluesMessage.Formatter = new ___CustomFormatter();
            PublishMulticastCluesMessage.Empty = new PublishMulticastCluesMessage(global::System.Array.Empty<MulticastClue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public PublishMulticastCluesMessage(MulticastClue[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<MulticastClue>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<MulticastClue> Values { get; }

        public static PublishMulticastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(PublishMulticastCluesMessage? left, PublishMulticastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(PublishMulticastCluesMessage? left, PublishMulticastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is PublishMulticastCluesMessage)) return false;
            return this.Equals((PublishMulticastCluesMessage)other);
        }
        public bool Equals(PublishMulticastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishMulticastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in PublishMulticastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        MulticastClue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public PublishMulticastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                MulticastClue[] p_values = global::System.Array.Empty<MulticastClue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new MulticastClue[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = MulticastClue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new PublishMulticastCluesMessage(p_values);
            }
        }
    }

    internal sealed partial class MulticastCluesMessage : global::Omnix.Serialization.OmniPack.IOmniPackMessage<MulticastCluesMessage>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<MulticastCluesMessage> Formatter { get; }
        public static MulticastCluesMessage Empty { get; }

        static MulticastCluesMessage()
        {
            MulticastCluesMessage.Formatter = new ___CustomFormatter();
            MulticastCluesMessage.Empty = new MulticastCluesMessage(global::System.Array.Empty<MulticastClue>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public MulticastCluesMessage(MulticastClue[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<MulticastClue>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<MulticastClue> Values { get; }

        public static MulticastCluesMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(MulticastCluesMessage? left, MulticastCluesMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(MulticastCluesMessage? left, MulticastCluesMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is MulticastCluesMessage)) return false;
            return this.Equals((MulticastCluesMessage)other);
        }
        public bool Equals(MulticastCluesMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<MulticastCluesMessage>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in MulticastCluesMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        MulticastClue.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public MulticastCluesMessage Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                MulticastClue[] p_values = global::System.Array.Empty<MulticastClue>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new MulticastClue[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = MulticastClue.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new MulticastCluesMessage(p_values);
            }
        }
    }

    internal sealed partial class WantContentLocations : global::Omnix.Serialization.OmniPack.IOmniPackMessage<WantContentLocations>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantContentLocations> Formatter { get; }
        public static WantContentLocations Empty { get; }

        static WantContentLocations()
        {
            WantContentLocations.Formatter = new ___CustomFormatter();
            WantContentLocations.Empty = new WantContentLocations(new global::System.Collections.Generic.Dictionary<Clue, RelayOption>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxParametersCount = 8192;

        public WantContentLocations(global::System.Collections.Generic.Dictionary<Clue, RelayOption> parameters)
        {
            if (parameters is null) throw new global::System.ArgumentNullException("parameters");
            if (parameters.Count > 8192) throw new global::System.ArgumentOutOfRangeException("parameters");
            foreach (var n in parameters)
            {
                if (n.Key is null) throw new global::System.ArgumentNullException("n.Key");
                if (n.Value is null) throw new global::System.ArgumentNullException("n.Value");
            }

            this.Parameters = new global::Omnix.DataStructures.ReadOnlyDictionarySlim<Clue, RelayOption>(parameters);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in parameters)
                {
                    if (n.Key != default) ___h.Add(n.Key.GetHashCode());
                    if (n.Value != default) ___h.Add(n.Value.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyDictionarySlim<Clue, RelayOption> Parameters { get; }

        public static WantContentLocations Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(WantContentLocations? left, WantContentLocations? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(WantContentLocations? left, WantContentLocations? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is WantContentLocations)) return false;
            return this.Equals((WantContentLocations)other);
        }
        public bool Equals(WantContentLocations? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Parameters, target.Parameters)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<WantContentLocations>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in WantContentLocations value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Parameters.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Parameters.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Parameters.Count);
                    foreach (var n in value.Parameters)
                    {
                        Clue.Formatter.Serialize(ref w, n.Key, rank + 1);
                        RelayOption.Formatter.Serialize(ref w, n.Value, rank + 1);
                    }
                }
            }

            public WantContentLocations Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                global::System.Collections.Generic.Dictionary<Clue, RelayOption> p_parameters = new global::System.Collections.Generic.Dictionary<Clue, RelayOption>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_parameters = new global::System.Collections.Generic.Dictionary<Clue, RelayOption>();
                                Clue t_key = Clue.Empty;
                                RelayOption t_value = RelayOption.Empty;
                                for (int i = 0; i < length; i++)
                                {
                                    t_key = Clue.Formatter.Deserialize(ref r, rank + 1);
                                    t_value = RelayOption.Formatter.Deserialize(ref r, rank + 1);
                                    p_parameters[t_key] = t_value;
                                }
                                break;
                            }
                    }
                }

                return new WantContentLocations(p_parameters);
            }
        }
    }

    internal sealed partial class PublishContentLocations : global::Omnix.Serialization.OmniPack.IOmniPackMessage<PublishContentLocations>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishContentLocations> Formatter { get; }
        public static PublishContentLocations Empty { get; }

        static PublishContentLocations()
        {
            PublishContentLocations.Formatter = new ___CustomFormatter();
            PublishContentLocations.Empty = new PublishContentLocations(global::System.Array.Empty<ContentLocation>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public PublishContentLocations(ContentLocation[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<ContentLocation>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<ContentLocation> Values { get; }

        public static PublishContentLocations Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(PublishContentLocations? left, PublishContentLocations? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(PublishContentLocations? left, PublishContentLocations? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is PublishContentLocations)) return false;
            return this.Equals((PublishContentLocations)other);
        }
        public bool Equals(PublishContentLocations? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<PublishContentLocations>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in PublishContentLocations value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        ContentLocation.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public PublishContentLocations Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                ContentLocation[] p_values = global::System.Array.Empty<ContentLocation>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new ContentLocation[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = ContentLocation.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new PublishContentLocations(p_values);
            }
        }
    }

    internal sealed partial class ContentLocations : global::Omnix.Serialization.OmniPack.IOmniPackMessage<ContentLocations>
    {
        public static global::Omnix.Serialization.OmniPack.IOmniPackFormatter<ContentLocations> Formatter { get; }
        public static ContentLocations Empty { get; }

        static ContentLocations()
        {
            ContentLocations.Formatter = new ___CustomFormatter();
            ContentLocations.Empty = new ContentLocations(global::System.Array.Empty<ContentLocation>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 8192;

        public ContentLocations(ContentLocation[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 8192) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnix.DataStructures.ReadOnlyListSlim<ContentLocation>(values);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in values)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnix.DataStructures.ReadOnlyListSlim<ContentLocation> Values { get; }

        public static ContentLocations Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var reader = new global::Omnix.Serialization.OmniPack.OmniPackReader(sequence, bufferPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnix.Base.IBufferPool<byte> bufferPool)
        {
            var writer = new global::Omnix.Serialization.OmniPack.OmniPackWriter(bufferWriter, bufferPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(ContentLocations? left, ContentLocations? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(ContentLocations? left, ContentLocations? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is ContentLocations)) return false;
            return this.Equals((ContentLocations)other);
        }
        public bool Equals(ContentLocations? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnix.Base.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnix.Serialization.OmniPack.IOmniPackFormatter<ContentLocations>
        {
            public void Serialize(ref global::Omnix.Serialization.OmniPack.OmniPackWriter w, in ContentLocations value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Values.Count != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Values.Count != 0)
                {
                    w.Write((uint)0);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        ContentLocation.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
            }

            public ContentLocations Deserialize(ref global::Omnix.Serialization.OmniPack.OmniPackReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                uint propertyCount = r.GetUInt32();

                ContentLocation[] p_values = global::System.Array.Empty<ContentLocation>();

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0:
                            {
                                var length = r.GetUInt32();
                                p_values = new ContentLocation[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = ContentLocation.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new ContentLocations(p_values);
            }
        }
    }

}
