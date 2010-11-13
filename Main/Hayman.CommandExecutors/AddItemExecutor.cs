using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;
using Hayman.Domain;

namespace Hayman.CommandExecutors
{
    public class AddItemExecutor : CommandExecutorBase<AddItem>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, AddItem command)
		{
            var metaModel = context.GetById<MetaModel>(command.MetaModelId);
            metaModel.AddItem(command.MetaItemId, command.ItemId, command.ItemName);
			context.Accept();
		}
	}
}
