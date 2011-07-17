using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
    [Serializable]
    public class ModelCreated : SourcedEvent
    {
        public Guid ModelId { get; private set; }
        public String ModelName { get; private set; }

        public ModelCreated(Guid modelId, String modelName)
        {
            ModelId = modelId;
            ModelName = modelName;
        }
    }
}
