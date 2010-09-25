using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainModelService.ServiceInterface.DataContracts
{
    [DataContract()]
    public class MetaitemDto
    {
        [DataMember()]
        public string Name { get; set; }

        [DataMember]
        public MetaAssociationDtoList Associations { get; set; }

        public MetaitemDto()
        {
            Associations = new MetaAssociationDtoList();
        }
    }
}