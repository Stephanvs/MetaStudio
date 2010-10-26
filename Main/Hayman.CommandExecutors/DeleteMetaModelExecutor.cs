using Hayman.Commands;
using Hayman.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace Hayman.CommandExecutors
{
	public class DeleteMetaModelExecutor : CommandExecutorBase<DeleteMetaModel>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, DeleteMetaModel command)
		{
			var metaModel = context.GetById<MetaModel>(command.MetaModelId);
            metaModel.Delete();
			context.Accept();
		}
	}
}
