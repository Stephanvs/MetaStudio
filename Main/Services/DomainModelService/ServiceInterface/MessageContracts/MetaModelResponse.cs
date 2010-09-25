using System;
using DomainModelService.ServiceInterface.DataContracts;
using System.ServiceModel;

namespace DomainModelService.ServiceInterface.MessageContracts
{
    [MessageContract(IsWrapped = false)]
    public class MetaModelResponse
    {
        [MessageBodyMember()]
        public MetaModelDto MetaModel { get; set; }
    }
}