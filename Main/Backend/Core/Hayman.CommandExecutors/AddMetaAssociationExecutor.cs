using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;
using Hayman.Domain;

namespace Hayman.CommandExecutors
{
	public class AddMetaAssociationExecutor : CommandExecutorBase<AddMetaAssociation>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, AddMetaAssociation command)
		{
			var metaModel = context.GetById<MetaModel>(command.MetaModelId);
            //metaModel.AddMetaAssociation(command.MetaAssociationId, command.MetaitemSourceId, command.MetaitemTargetId);
			context.Accept();
		}
	}
}
