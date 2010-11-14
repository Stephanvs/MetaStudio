using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace DomainModelService.ServiceInterface.DataContracts
{
    [CollectionDataContract]
    public class MetaAssociationDtoList : List<MetaAssociationDto>
    {
    }
}