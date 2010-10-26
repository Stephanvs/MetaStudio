using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;
using Hayman.Domain;

namespace Hayman.CommandExecutors
{
    public class AddMetaItemExecutor : CommandExecutorBase<AddMetaItem>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, AddMetaItem command)
		{
            var metaModel = context.GetById<MetaModel>(command.MetaModelId);
            metaModel.AddMetaItem(command.MetaItemId, command.MetaItemName);
			context.Accept();
		}
	}
}
