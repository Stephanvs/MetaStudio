using Hayman.Commands;
using Hayman.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace Hayman.CommandExecutors
{
	public class CreateMetaModelExecutor : CommandExecutorBase<CreateMetaModel>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, CreateMetaModel command)
		{
			var metaModel = new MetaModel(command.MetaModelId, command.MetaModelName);
			context.Accept();
		}
	}
}
