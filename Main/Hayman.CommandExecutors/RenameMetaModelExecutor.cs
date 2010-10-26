using Hayman.Commands;
using Hayman.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace Hayman.CommandExecutors
{
    public class RenameMetaModelExecutor : CommandExecutorBase<RenameMetaModel>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, RenameMetaModel command)
		{
            var metaModel = context.GetById<MetaModel>(command.MetaModelId);
            metaModel.Rename(command.NewMetaModelName);
			context.Accept();
		}
	}
}
