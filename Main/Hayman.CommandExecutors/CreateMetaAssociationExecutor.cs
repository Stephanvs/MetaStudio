using Hayman.Commands;
using Hayman.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace Hayman.CommandExecutors
{
    public class CreateMetaAssociationExecutor : CommandExecutorBase<CreateMetaAssociation>
	{
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreateMetaAssociation command)
		{
            var metaAssociation = new MetaAssociation(command.MetaAssociationId, command.MetaItemSourceId, command.MetaItemTargetId);
			context.Accept();
		}
	}
}
