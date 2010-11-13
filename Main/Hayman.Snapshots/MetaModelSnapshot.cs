using System;
using Ncqrs.Eventing.Sourcing.Snapshotting;

namespace Hayman.Snapshots
{
    public class MetaModelSnapshot : Snapshot
    {
        public string metaModelName;
        Public IList<MetaItem> MetaItems;
        public bool Deleted { get; private set; }
    }
}
