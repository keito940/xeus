using Omnius.Core.Cryptography;
using Omnius.Core.Network;
using Omnius.Xeus.Engines.Models;

#nullable enable

namespace Omnius.Xeus.Engines.Mediators.Internal.Models
{
    internal enum CkadMediatorVersion : sbyte
    {
        Unknown = 0,
        Version1 = 1,
    }
    internal sealed partial class ResourceLocation : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation>.Formatter;
        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation>.Empty;

        static ResourceLocation()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation>.Empty = new global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation(ResourceTag.Empty, global::System.Array.Empty<NodeProfile>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxNodeProfilesCount = 8192;

        public ResourceLocation(ResourceTag resourceTag, NodeProfile[] nodeProfiles)
        {
            if (resourceTag is null) throw new global::System.ArgumentNullException("resourceTag");
            if (nodeProfiles is null) throw new global::System.ArgumentNullException("nodeProfiles");
            if (nodeProfiles.Length > 8192) throw new global::System.ArgumentOutOfRangeException("nodeProfiles");
            foreach (var n in nodeProfiles)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.ResourceTag = resourceTag;
            this.NodeProfiles = new global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile>(nodeProfiles);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (resourceTag != default) ___h.Add(resourceTag.GetHashCode());
                foreach (var n in nodeProfiles)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public ResourceTag ResourceTag { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile> NodeProfiles { get; }

        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation)) return false;
            return this.Equals((global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation)other);
        }
        public bool Equals(global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.ResourceTag != target.ResourceTag) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.NodeProfiles, target.NodeProfiles)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.ResourceTag != ResourceTag.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Xeus.Engines.Models.ResourceTag.Formatter.Serialize(ref w, value.ResourceTag, rank + 1);
                }
                if (value.NodeProfiles.Count != 0)
                {
                    w.Write((uint)2);
                    w.Write((uint)value.NodeProfiles.Count);
                    foreach (var n in value.NodeProfiles)
                    {
                        global::Omnius.Xeus.Engines.Models.NodeProfile.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                ResourceTag p_resourceTag = ResourceTag.Empty;
                NodeProfile[] p_nodeProfiles = global::System.Array.Empty<NodeProfile>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_resourceTag = global::Omnius.Xeus.Engines.Models.ResourceTag.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                var length = r.GetUInt32();
                                p_nodeProfiles = new NodeProfile[length];
                                for (int i = 0; i < p_nodeProfiles.Length; i++)
                                {
                                    p_nodeProfiles[i] = global::Omnius.Xeus.Engines.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation(p_resourceTag, p_nodeProfiles);
            }
        }
    }
    internal sealed partial class CkadMediatorHelloMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage>.Formatter;
        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage>.Empty;

        static CkadMediatorHelloMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage>.Empty = new global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage(global::System.Array.Empty<CkadMediatorVersion>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxVersionsCount = 32;

        public CkadMediatorHelloMessage(CkadMediatorVersion[] versions)
        {
            if (versions is null) throw new global::System.ArgumentNullException("versions");
            if (versions.Length > 32) throw new global::System.ArgumentOutOfRangeException("versions");

            this.Versions = new global::Omnius.Core.Collections.ReadOnlyListSlim<CkadMediatorVersion>(versions);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in versions)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<CkadMediatorVersion> Versions { get; }

        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Versions, target.Versions)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Versions.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Versions.Count);
                    foreach (var n in value.Versions)
                    {
                        w.Write((long)n);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                CkadMediatorVersion[] p_versions = global::System.Array.Empty<CkadMediatorVersion>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_versions = new CkadMediatorVersion[length];
                                for (int i = 0; i < p_versions.Length; i++)
                                {
                                    p_versions[i] = (CkadMediatorVersion)r.GetInt64();
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorHelloMessage(p_versions);
            }
        }
    }
    internal sealed partial class CkadMediatorProfileMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage>.Formatter;
        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage>.Empty;

        static CkadMediatorProfileMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage>.Empty = new global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage(global::System.ReadOnlyMemory<byte>.Empty, NodeProfile.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxIdLength = 32;

        public CkadMediatorProfileMessage(global::System.ReadOnlyMemory<byte> id, NodeProfile nodeProfile)
        {
            if (id.Length > 32) throw new global::System.ArgumentOutOfRangeException("id");
            if (nodeProfile is null) throw new global::System.ArgumentNullException("nodeProfile");

            this.Id = id;
            this.NodeProfile = nodeProfile;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (!id.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(id.Span));
                if (nodeProfile != default) ___h.Add(nodeProfile.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public global::System.ReadOnlyMemory<byte> Id { get; }
        public NodeProfile NodeProfile { get; }

        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Id.Span, target.Id.Span)) return false;
            if (this.NodeProfile != target.NodeProfile) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (!value.Id.IsEmpty)
                {
                    w.Write((uint)1);
                    w.Write(value.Id.Span);
                }
                if (value.NodeProfile != NodeProfile.Empty)
                {
                    w.Write((uint)2);
                    global::Omnius.Xeus.Engines.Models.NodeProfile.Formatter.Serialize(ref w, value.NodeProfile, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::System.ReadOnlyMemory<byte> p_id = global::System.ReadOnlyMemory<byte>.Empty;
                NodeProfile p_nodeProfile = NodeProfile.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_id = r.GetMemory(32);
                                break;
                            }
                        case 2:
                            {
                                p_nodeProfile = global::Omnius.Xeus.Engines.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorProfileMessage(p_id, p_nodeProfile);
            }
        }
    }
    internal sealed partial class CkadMediatorDataMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage>.Formatter;
        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage>.Empty;

        static CkadMediatorDataMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage>.Empty = new global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage(global::System.Array.Empty<NodeProfile>(), global::System.Array.Empty<ResourceLocation>(), global::System.Array.Empty<ResourceTag>(), global::System.Array.Empty<ResourceLocation>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxPushNodeProfilesCount = 256;
        public static readonly int MaxPushResourceLocationsCount = 256;
        public static readonly int MaxWantResourceLocationsCount = 256;
        public static readonly int MaxGiveResourceLocationsCount = 256;

        public CkadMediatorDataMessage(NodeProfile[] pushNodeProfiles, ResourceLocation[] pushResourceLocations, ResourceTag[] wantResourceLocations, ResourceLocation[] giveResourceLocations)
        {
            if (pushNodeProfiles is null) throw new global::System.ArgumentNullException("pushNodeProfiles");
            if (pushNodeProfiles.Length > 256) throw new global::System.ArgumentOutOfRangeException("pushNodeProfiles");
            foreach (var n in pushNodeProfiles)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (pushResourceLocations is null) throw new global::System.ArgumentNullException("pushResourceLocations");
            if (pushResourceLocations.Length > 256) throw new global::System.ArgumentOutOfRangeException("pushResourceLocations");
            foreach (var n in pushResourceLocations)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (wantResourceLocations is null) throw new global::System.ArgumentNullException("wantResourceLocations");
            if (wantResourceLocations.Length > 256) throw new global::System.ArgumentOutOfRangeException("wantResourceLocations");
            foreach (var n in wantResourceLocations)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (giveResourceLocations is null) throw new global::System.ArgumentNullException("giveResourceLocations");
            if (giveResourceLocations.Length > 256) throw new global::System.ArgumentOutOfRangeException("giveResourceLocations");
            foreach (var n in giveResourceLocations)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.PushNodeProfiles = new global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile>(pushNodeProfiles);
            this.PushResourceLocations = new global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation>(pushResourceLocations);
            this.WantResourceLocations = new global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceTag>(wantResourceLocations);
            this.GiveResourceLocations = new global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation>(giveResourceLocations);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in pushNodeProfiles)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in pushResourceLocations)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in wantResourceLocations)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in giveResourceLocations)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile> PushNodeProfiles { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation> PushResourceLocations { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceTag> WantResourceLocations { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation> GiveResourceLocations { get; }

        public static global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage? left, global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.PushNodeProfiles, target.PushNodeProfiles)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.PushResourceLocations, target.PushResourceLocations)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.WantResourceLocations, target.WantResourceLocations)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.GiveResourceLocations, target.GiveResourceLocations)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.PushNodeProfiles.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.PushNodeProfiles.Count);
                    foreach (var n in value.PushNodeProfiles)
                    {
                        global::Omnius.Xeus.Engines.Models.NodeProfile.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.PushResourceLocations.Count != 0)
                {
                    w.Write((uint)2);
                    w.Write((uint)value.PushResourceLocations.Count);
                    foreach (var n in value.PushResourceLocations)
                    {
                        global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.WantResourceLocations.Count != 0)
                {
                    w.Write((uint)3);
                    w.Write((uint)value.WantResourceLocations.Count);
                    foreach (var n in value.WantResourceLocations)
                    {
                        global::Omnius.Xeus.Engines.Models.ResourceTag.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.GiveResourceLocations.Count != 0)
                {
                    w.Write((uint)4);
                    w.Write((uint)value.GiveResourceLocations.Count);
                    foreach (var n in value.GiveResourceLocations)
                    {
                        global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                NodeProfile[] p_pushNodeProfiles = global::System.Array.Empty<NodeProfile>();
                ResourceLocation[] p_pushResourceLocations = global::System.Array.Empty<ResourceLocation>();
                ResourceTag[] p_wantResourceLocations = global::System.Array.Empty<ResourceTag>();
                ResourceLocation[] p_giveResourceLocations = global::System.Array.Empty<ResourceLocation>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_pushNodeProfiles = new NodeProfile[length];
                                for (int i = 0; i < p_pushNodeProfiles.Length; i++)
                                {
                                    p_pushNodeProfiles[i] = global::Omnius.Xeus.Engines.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 2:
                            {
                                var length = r.GetUInt32();
                                p_pushResourceLocations = new ResourceLocation[length];
                                for (int i = 0; i < p_pushResourceLocations.Length; i++)
                                {
                                    p_pushResourceLocations[i] = global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 3:
                            {
                                var length = r.GetUInt32();
                                p_wantResourceLocations = new ResourceTag[length];
                                for (int i = 0; i < p_wantResourceLocations.Length; i++)
                                {
                                    p_wantResourceLocations[i] = global::Omnius.Xeus.Engines.Models.ResourceTag.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 4:
                            {
                                var length = r.GetUInt32();
                                p_giveResourceLocations = new ResourceLocation[length];
                                for (int i = 0; i < p_giveResourceLocations.Length; i++)
                                {
                                    p_giveResourceLocations[i] = global::Omnius.Xeus.Engines.Mediators.Internal.Models.ResourceLocation.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Engines.Mediators.Internal.Models.CkadMediatorDataMessage(p_pushNodeProfiles, p_pushResourceLocations, p_wantResourceLocations, p_giveResourceLocations);
            }
        }
    }
}
