using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;
using Hayman.Domain;

namespace Hayman.CommandExecutors
{
    public class RemoveMetaItemExecutor : CommandExecutorBase<RemoveMetaItem>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, RemoveMetaItem command)
		{
			var metaModel = context.GetById<MetaModel>(command.MetaModelId);
            metaModel.RemoveMetaItem(command.MetaItemId);
			context.Accept();
		}
	}
}
