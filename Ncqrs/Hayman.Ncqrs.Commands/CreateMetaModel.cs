using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Ncqrs.Commands
{
    [Serializable]
    [MapsToAggregateRootConstructor("Hayman.Domain.MetaModel, Hayman.Domain")]
    public class CreateMetaModel : CommandBase
    {
        public Guid MetaModelId { get; private set; }
        public string MetaModelName { get; private set; }

        public CreateMetaModel(Guid metaModelId, string metaModelName)
        {
            MetaModelId = metaModelId;
            MetaModelName = metaModelName;
        }
    }
}