using System;
using Ncqrs.Eventing.Sourcing.Snapshotting;
using System.Collections.Generic;

namespace Hayman.Domain.Snapshotting
{
    public class MetaModelSnapshot : Snapshot
    {
        public string MetaModelName { get; set; }
        public IList<MetaItem> MetaItems { get; set; }
        public bool Deleted { get; set; }
    }
}
