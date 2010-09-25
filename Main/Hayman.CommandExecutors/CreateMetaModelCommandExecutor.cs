using Hayman.Commands;
using Hayman.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace Hayman.CommandExecutors
{
	public class CreateMetaModelCommandExecutor : CommandExecutorBase<CreateMetaModelCommand>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, CreateMetaModelCommand command)
		{
			var model = new MetaModel(command.Name);
			context.Accept();
		}
	}
}
