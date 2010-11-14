using System;
using System.Runtime.Serialization;

namespace DomainModelService.ServiceInterface.DataContracts
{
    [DataContract()]
    public class MetaModelDto
    {
        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public MetaItemDto RootItem { get; set; }
    }
}