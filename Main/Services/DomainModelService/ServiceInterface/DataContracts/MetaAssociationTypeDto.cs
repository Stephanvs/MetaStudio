using System;
using System.Runtime.Serialization;

namespace DomainModelService.ServiceInterface.DataContracts
{
    [DataContract()]
    public enum MetaAssociationTypeDto
    {
        [EnumMember]
        Subtyping,
        [EnumMember]
        Reference
    }
}
