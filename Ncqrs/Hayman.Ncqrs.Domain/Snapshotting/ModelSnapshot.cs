using System;
using Ncqrs.Eventing.Sourcing.Snapshotting;
using System.Collections.Generic;

namespace Hayman.Domain.Snapshotting
{
    public class ModelSnapshot : Snapshot
    {
        public string ModelName { get; set; }
        public IList<MetaItem> MetaItems { get; set; }
        public bool Deleted { get; set; }
    }
}
