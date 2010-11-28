using System;
using System.ServiceModel;
using Hayman.Commands;
using Ncqrs.Commanding;

namespace Hayman.CommandService
{
    [ServiceContract]
    [ServiceKnownType(typeof(CreateMetaModel))]
    [ServiceKnownType(typeof(RenameMetaModel))]
    [ServiceKnownType(typeof(DeleteMetaModel))]
    [ServiceKnownType(typeof(CreateMetaAssociation))]
    [ServiceKnownType(typeof(DeleteMetaAssociation))]
    [ServiceKnownType(typeof(AddMetaItem))]
    [ServiceKnownType(typeof(RemoveMetaItem))]
    [ServiceKnownType(typeof(AddItem))]
    [ServiceKnownType(typeof(AddAssociation))]
    public interface IHaymanCommandService
    {
        [OperationContract]
        void ExecuteCommand(ICommand command);
    }

}