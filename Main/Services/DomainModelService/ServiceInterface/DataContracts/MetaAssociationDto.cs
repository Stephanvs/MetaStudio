using System;
using System.Runtime.Serialization;

namespace DomainModelService.ServiceInterface.DataContracts
{
    [DataContract()]
    public class MetaAssociationDto
    {
        [DataMember()]
        public MetaAssociationTypeDto Type { get; set; }

        //[DataMember()]
        //public MetaItemDto Source { get; set; }

        [DataMember()]
        public MetaItemDto Target { get; set; }
    }
}
