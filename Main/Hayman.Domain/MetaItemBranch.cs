using System;
using Ncqrs.Domain;

namespace Hayman.Domain
{
    public class MetaItemBranch : EntityMappedByConvention
	{
        private Guid branchedOnMetaItemId;

        public MetaItemBranch(MetaModel metaModel, Guid metaItemBranchId, Guid branchedOnMetaItemId)
            : base(metaModel, metaItemBranchId)
        {
            this.branchedOnMetaItemId = branchedOnMetaItemId;
        }
	}
}
