using System;
using Ncqrs.Eventing.Sourcing.Snapshotting;
using System.Collections.Generic;

namespace Hayman.Ncqrs.Domain.Snapshotting
{
    public class MetaAssociationSnapshot : Snapshot
    {
        public Guid MetaItemSourceId { get; set; }
        public Guid MetaItemTargetId { get; set; }
        public List<Association> Associations { get; set; }
        public bool Deleted { get; set; }
    }
}
