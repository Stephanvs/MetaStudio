using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class MetaModelRenamed : SourcedEvent
    {
        public String NewMetaModelName { get; set; }

        public MetaModelRenamed(String newMetaModelName)
        {
            NewMetaModelName = newMetaModelName;
        }
    }
}
