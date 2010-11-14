using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainModelService.ServiceInterface.DataContracts
{
    [DataContract()]
    public class MetaItemDto
    {
        [DataMember()]
        public string Name { get; set; }

        [DataMember]
        public MetaAssociationDtoList Associations { get; set; }

        public MetaItemDto()
        {
            Associations = new MetaAssociationDtoList();
        }
    }
}