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
        //public MetaitemDto Source { get; set; }

        [DataMember()]
        public MetaitemDto Target { get; set; }
    }
}
