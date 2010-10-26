using System;
using DomainModelService.ServiceInterface.MessageContracts;
using DomainModelService.ServiceInterface.DataContracts;

namespace DomainModelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DomainModelService" in code, svc and config file together.
    public class DomainModelService : IDomainModelService
    {
        #region IDomainModelService Members

        public MetaModelResponse GetMetaModel(MetaModelRequest request)
        {
            MetaItemDto rootItem = new MetaItemDto { Name = "Root item" };

            MetaItemDto childItem1 = new MetaItemDto { Name = "Child item 1" };
            MetaAssociationDto association1 = new MetaAssociationDto { Target = childItem1, Type = MetaAssociationTypeDto.Reference };
            rootItem.Associations.Add(association1);

            MetaItemDto childItem2 = new MetaItemDto { Name = "Child item 2" };
            MetaAssociationDto association2 = new MetaAssociationDto { Target = childItem2, Type = MetaAssociationTypeDto.Reference };
            childItem1.Associations.Add(association2);

            MetaItemDto childItem3 = new MetaItemDto { Name = "Child item 3" };
            MetaAssociationDto association3 = new MetaAssociationDto { Target = childItem3, Type = MetaAssociationTypeDto.Reference };
            rootItem.Associations.Add(association3);

            MetaItemDto childItem4 = new MetaItemDto { Name = "Child item 4" };
            MetaAssociationDto association4 = new MetaAssociationDto { Target = childItem4, Type = MetaAssociationTypeDto.Reference };
            childItem3.Associations.Add(association4);

            MetaItemDto childItem5 = new MetaItemDto { Name = "Child item 5" };
            MetaAssociationDto association5 = new MetaAssociationDto { Target = childItem5, Type = MetaAssociationTypeDto.Reference };
            childItem3.Associations.Add(association5);

            MetaItemDto childItem6 = new MetaItemDto { Name = "Child item 6" };
            MetaAssociationDto association6 = new MetaAssociationDto { Target = childItem6, Type = MetaAssociationTypeDto.Reference };
            childItem3.Associations.Add(association6);
                                    
            MetaModelDto metaModel = new MetaModelDto { Name = "My meta model", RootItem = rootItem };
            
            MetaModelResponse response = new MetaModelResponse { MetaModel = metaModel };
            return response;
        }

        #endregion
    }
}
