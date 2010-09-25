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
            MetaitemDto rootItem = new MetaitemDto { Name = "Root item" };

            MetaitemDto childItem1 = new MetaitemDto { Name = "Child item 1" };
            MetaAssociationDto association1 = new MetaAssociationDto { Target = childItem1, Type = MetaAssociationTypeDto.Reference };
            rootItem.Associations.Add(association1);

            MetaitemDto childItem2 = new MetaitemDto { Name = "Child item 2" };
            MetaAssociationDto association2 = new MetaAssociationDto { Target = childItem2, Type = MetaAssociationTypeDto.Reference };
            childItem1.Associations.Add(association2);

            MetaitemDto childItem3 = new MetaitemDto { Name = "Child item 3" };
            MetaAssociationDto association3 = new MetaAssociationDto { Target = childItem3, Type = MetaAssociationTypeDto.Reference };
            rootItem.Associations.Add(association3);

            MetaitemDto childItem4 = new MetaitemDto { Name = "Child item 4" };
            MetaAssociationDto association4 = new MetaAssociationDto { Target = childItem4, Type = MetaAssociationTypeDto.Reference };
            childItem3.Associations.Add(association4);

            MetaitemDto childItem5 = new MetaitemDto { Name = "Child item 5" };
            MetaAssociationDto association5 = new MetaAssociationDto { Target = childItem5, Type = MetaAssociationTypeDto.Reference };
            childItem3.Associations.Add(association5);

            MetaitemDto childItem6 = new MetaitemDto { Name = "Child item 6" };
            MetaAssociationDto association6 = new MetaAssociationDto { Target = childItem6, Type = MetaAssociationTypeDto.Reference };
            childItem3.Associations.Add(association6);
                                    
            MetaModelDto metaModel = new MetaModelDto { Name = "My meta model", RootItem = rootItem };
            
            MetaModelResponse response = new MetaModelResponse { MetaModel = metaModel };
            return response;
        }

        #endregion
    }
}
