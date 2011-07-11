using System;
using Ncqrs.Domain;

namespace Hayman.Ncqrs.Domain
{
    public class Association : EntityMappedByConvention
	{
        private Guid itemSourceId;
        private Guid itemTargetId;
        private string associationName;

        public Association(MetaAssociation metaAssociation, Guid associationId, Guid itemSourceId, Guid itemTargetId, string associationName)
            : base(metaAssociation, associationId)
        {
            this.itemSourceId = itemSourceId;
            this.itemTargetId = itemTargetId;
            this.associationName = associationName;
        }
	}
}
