using Hayman.Commands;
using Hayman.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace Hayman.CommandExecutors
{
    public class DeleteMetaAssociationExecutor : CommandExecutorBase<DeleteMetaAssociation>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, DeleteMetaAssociation command)
		{
            var metaAssociation = context.GetById<MetaAssociation>(command.MetaAssociationId);
            metaAssociation.Delete();
			context.Accept();
		}
	}
}
