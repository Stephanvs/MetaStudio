using System;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Commanding;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ServiceModel;
using Hayman.Commands;

namespace Hayman.CommandService
{
    [ServiceContract(Namespace = "")]
    [ServiceKnownType("GetKnownTypes")]
	public class HaymanCommandService
	{
		private static ICommandService _service;

		static HaymanCommandService()
		{
			Bootstrapper.BootUp();
			_service = Ncqrs.NcqrsEnvironment.Get<ICommandService>();
		}

        [OperationContract]
        public void Execute(IEnumerable<ICommand> commands)
        {
            try
            {
                foreach (var command in commands)
                {
                    _service.Execute(command);
                }
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            var query =
                from type in typeof(CreateMetaModel).Assembly.GetTypes()
                where typeof(ICommand).IsAssignableFrom(type)
                select type;

            return query.ToArray();
        }
    }
}
