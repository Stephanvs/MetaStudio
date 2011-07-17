using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class ModelRenamed : SourcedEvent
    {
        public Guid ModelId { get; private set; }
        public String NewModelName { get; private set; }

        public ModelRenamed(Guid modelId, String newModelName)
        {
            ModelId = modelId;
            NewModelName = newModelName;
        }
    }
}
