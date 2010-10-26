using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	public class RenameMetaModel : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public string NewMetaModelName { get; private set; }

        public RenameMetaModel(Guid metaModelId, string newMetaModelName)
		{
            MetaModelId = metaModelId;
			NewMetaModelName = newMetaModelName;
		}
	}
}