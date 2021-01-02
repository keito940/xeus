// <auto-generated/>
#nullable enable

namespace Omnius.Xeus.Interactors.Models
{
    public sealed partial class XeusProfile : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusProfile>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Interactors.Models.XeusProfile> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusProfile>.Formatter;
        public static global::Omnius.Xeus.Interactors.Models.XeusProfile Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusProfile>.Empty;

        static XeusProfile()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusProfile>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusProfile>.Empty = new global::Omnius.Xeus.Interactors.Models.XeusProfile(global::Omnius.Core.Cryptography.OmniHash.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public XeusProfile(global::Omnius.Core.Cryptography.OmniHash files)
        {
            this.Files = files;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (files != default) ___h.Add(files.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Cryptography.OmniHash Files { get; }

        public static global::Omnius.Xeus.Interactors.Models.XeusProfile Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Interactors.Models.XeusProfile? left, global::Omnius.Xeus.Interactors.Models.XeusProfile? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Interactors.Models.XeusProfile? left, global::Omnius.Xeus.Interactors.Models.XeusProfile? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (other is not global::Omnius.Xeus.Interactors.Models.XeusProfile) return false;
            return this.Equals((global::Omnius.Xeus.Interactors.Models.XeusProfile)other);
        }
        public bool Equals(global::Omnius.Xeus.Interactors.Models.XeusProfile? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Files != target.Files) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Interactors.Models.XeusProfile>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Interactors.Models.XeusProfile value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Files != global::Omnius.Core.Cryptography.OmniHash.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Core.Cryptography.OmniHash.Formatter.Serialize(ref w, value.Files, rank + 1);
                }
                w.Write((uint)0);
            }
            public global::Omnius.Xeus.Interactors.Models.XeusProfile Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::Omnius.Core.Cryptography.OmniHash p_files = global::Omnius.Core.Cryptography.OmniHash.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_files = global::Omnius.Core.Cryptography.OmniHash.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Interactors.Models.XeusProfile(p_files);
            }
        }
    }
    public sealed partial class XeusFileCollection : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFileCollection>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Interactors.Models.XeusFileCollection> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFileCollection>.Formatter;
        public static global::Omnius.Xeus.Interactors.Models.XeusFileCollection Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFileCollection>.Empty;

        static XeusFileCollection()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFileCollection>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFileCollection>.Empty = new global::Omnius.Xeus.Interactors.Models.XeusFileCollection(global::System.Array.Empty<global::Omnius.Xeus.Interactors.Models.XeusFile>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValuesCount = 32768;

        public XeusFileCollection(global::Omnius.Xeus.Interactors.Models.XeusFile[] values)
        {
            if (values is null) throw new global::System.ArgumentNullException("values");
            if (values.Length > 32768) throw new global::System.ArgumentOutOfRangeException("values");
            foreach (var n in values)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.Values = new global::Omnius.Core.Collections.ReadOnlyListSlim<global::Omnius.Xeus.Interactors.Models.XeusFile>(values);

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

        public global::Omnius.Core.Collections.ReadOnlyListSlim<global::Omnius.Xeus.Interactors.Models.XeusFile> Values { get; }

        public static global::Omnius.Xeus.Interactors.Models.XeusFileCollection Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Interactors.Models.XeusFileCollection? left, global::Omnius.Xeus.Interactors.Models.XeusFileCollection? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Interactors.Models.XeusFileCollection? left, global::Omnius.Xeus.Interactors.Models.XeusFileCollection? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (other is not global::Omnius.Xeus.Interactors.Models.XeusFileCollection) return false;
            return this.Equals((global::Omnius.Xeus.Interactors.Models.XeusFileCollection)other);
        }
        public bool Equals(global::Omnius.Xeus.Interactors.Models.XeusFileCollection? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Values, target.Values)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Interactors.Models.XeusFileCollection>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Interactors.Models.XeusFileCollection value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Values.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Values.Count);
                    foreach (var n in value.Values)
                    {
                        global::Omnius.Xeus.Interactors.Models.XeusFile.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                w.Write((uint)0);
            }
            public global::Omnius.Xeus.Interactors.Models.XeusFileCollection Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::Omnius.Xeus.Interactors.Models.XeusFile[] p_values = global::System.Array.Empty<global::Omnius.Xeus.Interactors.Models.XeusFile>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_values = new global::Omnius.Xeus.Interactors.Models.XeusFile[length];
                                for (int i = 0; i < p_values.Length; i++)
                                {
                                    p_values[i] = global::Omnius.Xeus.Interactors.Models.XeusFile.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Interactors.Models.XeusFileCollection(p_values);
            }
        }
    }
    public sealed partial class XeusFile : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFile>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Interactors.Models.XeusFile> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFile>.Formatter;
        public static global::Omnius.Xeus.Interactors.Models.XeusFile Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFile>.Empty;

        static XeusFile()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFile>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Interactors.Models.XeusFile>.Empty = new global::Omnius.Xeus.Interactors.Models.XeusFile(global::Omnius.Core.Cryptography.OmniHash.Empty, string.Empty, 0, global::System.Array.Empty<string>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxNameLength = 256;
        public static readonly int MaxTagsCount = 8;

        public XeusFile(global::Omnius.Core.Cryptography.OmniHash clue, string name, ulong size, string[] tags)
        {
            if (name is null) throw new global::System.ArgumentNullException("name");
            if (name.Length > 256) throw new global::System.ArgumentOutOfRangeException("name");
            if (tags is null) throw new global::System.ArgumentNullException("tags");
            if (tags.Length > 8) throw new global::System.ArgumentOutOfRangeException("tags");
            foreach (var n in tags)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
                if (n.Length > 256) throw new global::System.ArgumentOutOfRangeException("n");
            }

            this.Clue = clue;
            this.Name = name;
            this.Size = size;
            this.Tags = new global::Omnius.Core.Collections.ReadOnlyListSlim<string>(tags);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (clue != default) ___h.Add(clue.GetHashCode());
                if (name != default) ___h.Add(name.GetHashCode());
                if (size != default) ___h.Add(size.GetHashCode());
                foreach (var n in tags)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Cryptography.OmniHash Clue { get; }
        public string Name { get; }
        public ulong Size { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<string> Tags { get; }

        public static global::Omnius.Xeus.Interactors.Models.XeusFile Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Interactors.Models.XeusFile? left, global::Omnius.Xeus.Interactors.Models.XeusFile? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Interactors.Models.XeusFile? left, global::Omnius.Xeus.Interactors.Models.XeusFile? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (other is not global::Omnius.Xeus.Interactors.Models.XeusFile) return false;
            return this.Equals((global::Omnius.Xeus.Interactors.Models.XeusFile)other);
        }
        public bool Equals(global::Omnius.Xeus.Interactors.Models.XeusFile? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Clue != target.Clue) return false;
            if (this.Name != target.Name) return false;
            if (this.Size != target.Size) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Tags, target.Tags)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Interactors.Models.XeusFile>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Interactors.Models.XeusFile value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Clue != global::Omnius.Core.Cryptography.OmniHash.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Core.Cryptography.OmniHash.Formatter.Serialize(ref w, value.Clue, rank + 1);
                }
                if (value.Name != string.Empty)
                {
                    w.Write((uint)2);
                    w.Write(value.Name);
                }
                if (value.Size != 0)
                {
                    w.Write((uint)3);
                    w.Write(value.Size);
                }
                if (value.Tags.Count != 0)
                {
                    w.Write((uint)4);
                    w.Write((uint)value.Tags.Count);
                    foreach (var n in value.Tags)
                    {
                        w.Write(n);
                    }
                }
                w.Write((uint)0);
            }
            public global::Omnius.Xeus.Interactors.Models.XeusFile Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::Omnius.Core.Cryptography.OmniHash p_clue = global::Omnius.Core.Cryptography.OmniHash.Empty;
                string p_name = string.Empty;
                ulong p_size = 0;
                string[] p_tags = global::System.Array.Empty<string>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_clue = global::Omnius.Core.Cryptography.OmniHash.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                p_name = r.GetString(256);
                                break;
                            }
                        case 3:
                            {
                                p_size = r.GetUInt64();
                                break;
                            }
                        case 4:
                            {
                                var length = r.GetUInt32();
                                p_tags = new string[length];
                                for (int i = 0; i < p_tags.Length; i++)
                                {
                                    p_tags[i] = r.GetString(256);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Interactors.Models.XeusFile(p_clue, p_name, p_size, p_tags);
            }
        }
    }
}
