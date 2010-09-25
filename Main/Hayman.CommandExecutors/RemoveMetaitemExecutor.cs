using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;
using Hayman.Domain;

namespace Hayman.CommandExecutors
{
    public class RemoveMetaitemExecutor : CommandExecutorBase<RemoveMetaitem>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, RemoveMetaitem command)
		{
			var model = context.GetById<MetaModel>(command.MetaModelId);
            model.RemoveMetaitem(command.MetaitemId);
			context.Accept();
		}
	}
}
