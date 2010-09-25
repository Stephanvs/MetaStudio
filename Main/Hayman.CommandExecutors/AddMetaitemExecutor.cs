using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;
using Hayman.Domain;

namespace Hayman.CommandExecutors
{
    public class AddMetaitemExecutor : CommandExecutorBase<AddMetaitem>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, AddMetaitem command)
		{
			var model = context.GetById<MetaModel>(command.MetaModelId);
            model.AddMetaitem(command.MetaitemId, command.MetaitemName);
			context.Accept();
		}
	}
}
