using System;
using System.ServiceModel;

namespace DomainModelService.ServiceInterface.MessageContracts
{
    [MessageContract(IsWrapped = false)]
    public class MetaModelRequest
    {
        [MessageBodyMember()]
        public string Name { get; set; }
    }
}