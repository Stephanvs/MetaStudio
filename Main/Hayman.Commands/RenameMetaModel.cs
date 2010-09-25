using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	public class RenameMetaModel : CommandBase
	{
        public string NewMetaModelName { get; private set; }

        public RenameMetaModel(string newMetaModelName)
		{
			NewMetaModelName = newMetaModelName;
		}
	}
}