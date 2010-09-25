using System;
using System.ServiceModel;
using DomainModelService.ServiceInterface.MessageContracts;
using DomainModelService.ServiceInterface.DataContracts;

namespace DomainModelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDomainModelService
    {
        [OperationContract()]
        MetaModelResponse GetMetaModel(MetaModelRequest request); 

    }
}
