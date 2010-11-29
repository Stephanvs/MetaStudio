﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("HaymanReadModelModel", "FK_MetaAssociation_MetaItemSource", "MetaItem", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Hayman.ReadModel.Sql.MetaItem), "MetaAssociation", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Hayman.ReadModel.Sql.MetaAssociation), true)]
[assembly: EdmRelationshipAttribute("HaymanReadModelModel", "FK_MetaAssociation_MetaItemTarget", "MetaItem", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Hayman.ReadModel.Sql.MetaItem), "MetaAssociation", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Hayman.ReadModel.Sql.MetaAssociation), true)]
[assembly: EdmRelationshipAttribute("HaymanReadModelModel", "FK_MetaItem_MetaModel", "MetaModel", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Hayman.ReadModel.Sql.MetaModel), "MetaItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Hayman.ReadModel.Sql.MetaItem), true)]

#endregion

namespace Hayman.ReadModel.Sql
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class HaymanReadModelEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new HaymanReadModelEntities object using the connection string found in the 'HaymanReadModelEntities' section of the application configuration file.
        /// </summary>
        public HaymanReadModelEntities() : base("name=HaymanReadModelEntities", "HaymanReadModelEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HaymanReadModelEntities object.
        /// </summary>
        public HaymanReadModelEntities(string connectionString) : base(connectionString, "HaymanReadModelEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HaymanReadModelEntities object.
        /// </summary>
        public HaymanReadModelEntities(EntityConnection connection) : base(connection, "HaymanReadModelEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<MetaAssociation> MetaAssociations
        {
            get
            {
                if ((_MetaAssociations == null))
                {
                    _MetaAssociations = base.CreateObjectSet<MetaAssociation>("MetaAssociations");
                }
                return _MetaAssociations;
            }
        }
        private ObjectSet<MetaAssociation> _MetaAssociations;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<MetaItem> MetaItems
        {
            get
            {
                if ((_MetaItems == null))
                {
                    _MetaItems = base.CreateObjectSet<MetaItem>("MetaItems");
                }
                return _MetaItems;
            }
        }
        private ObjectSet<MetaItem> _MetaItems;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<MetaModel> MetaModels
        {
            get
            {
                if ((_MetaModels == null))
                {
                    _MetaModels = base.CreateObjectSet<MetaModel>("MetaModels");
                }
                return _MetaModels;
            }
        }
        private ObjectSet<MetaModel> _MetaModels;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the MetaAssociations EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToMetaAssociations(MetaAssociation metaAssociation)
        {
            base.AddObject("MetaAssociations", metaAssociation);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the MetaItems EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToMetaItems(MetaItem metaItem)
        {
            base.AddObject("MetaItems", metaItem);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the MetaModels EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToMetaModels(MetaModel metaModel)
        {
            base.AddObject("MetaModels", metaModel);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HaymanReadModelModel", Name="MetaAssociation")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class MetaAssociation : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new MetaAssociation object.
        /// </summary>
        /// <param name="metaAssociationId">Initial value of the MetaAssociationId property.</param>
        /// <param name="metaItemSourceId">Initial value of the MetaItemSourceId property.</param>
        /// <param name="metaItemTargetId">Initial value of the MetaItemTargetId property.</param>
        /// <param name="deleted">Initial value of the Deleted property.</param>
        public static MetaAssociation CreateMetaAssociation(global::System.Guid metaAssociationId, global::System.Guid metaItemSourceId, global::System.Guid metaItemTargetId, global::System.Boolean deleted)
        {
            MetaAssociation metaAssociation = new MetaAssociation();
            metaAssociation.MetaAssociationId = metaAssociationId;
            metaAssociation.MetaItemSourceId = metaItemSourceId;
            metaAssociation.MetaItemTargetId = metaItemTargetId;
            metaAssociation.Deleted = deleted;
            return metaAssociation;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid MetaAssociationId
        {
            get
            {
                return _MetaAssociationId;
            }
            set
            {
                if (_MetaAssociationId != value)
                {
                    OnMetaAssociationIdChanging(value);
                    ReportPropertyChanging("MetaAssociationId");
                    _MetaAssociationId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MetaAssociationId");
                    OnMetaAssociationIdChanged();
                }
            }
        }
        private global::System.Guid _MetaAssociationId;
        partial void OnMetaAssociationIdChanging(global::System.Guid value);
        partial void OnMetaAssociationIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid MetaItemSourceId
        {
            get
            {
                return _MetaItemSourceId;
            }
            set
            {
                OnMetaItemSourceIdChanging(value);
                ReportPropertyChanging("MetaItemSourceId");
                _MetaItemSourceId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MetaItemSourceId");
                OnMetaItemSourceIdChanged();
            }
        }
        private global::System.Guid _MetaItemSourceId;
        partial void OnMetaItemSourceIdChanging(global::System.Guid value);
        partial void OnMetaItemSourceIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid MetaItemTargetId
        {
            get
            {
                return _MetaItemTargetId;
            }
            set
            {
                OnMetaItemTargetIdChanging(value);
                ReportPropertyChanging("MetaItemTargetId");
                _MetaItemTargetId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MetaItemTargetId");
                OnMetaItemTargetIdChanged();
            }
        }
        private global::System.Guid _MetaItemTargetId;
        partial void OnMetaItemTargetIdChanging(global::System.Guid value);
        partial void OnMetaItemTargetIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                OnDeletedChanging(value);
                ReportPropertyChanging("Deleted");
                _Deleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Deleted");
                OnDeletedChanged();
            }
        }
        private global::System.Boolean _Deleted;
        partial void OnDeletedChanging(global::System.Boolean value);
        partial void OnDeletedChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HaymanReadModelModel", "FK_MetaAssociation_MetaItemSource", "MetaItem")]
        public MetaItem MetaItemSource
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemSource", "MetaItem").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemSource", "MetaItem").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<MetaItem> MetaItemSourceReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemSource", "MetaItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemSource", "MetaItem", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HaymanReadModelModel", "FK_MetaAssociation_MetaItemTarget", "MetaItem")]
        public MetaItem MetaItemTarget
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemTarget", "MetaItem").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemTarget", "MetaItem").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<MetaItem> MetaItemTargetReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemTarget", "MetaItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<MetaItem>("HaymanReadModelModel.FK_MetaAssociation_MetaItemTarget", "MetaItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HaymanReadModelModel", Name="MetaItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class MetaItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new MetaItem object.
        /// </summary>
        /// <param name="metaItemId">Initial value of the MetaItemId property.</param>
        /// <param name="metaItemName">Initial value of the MetaItemName property.</param>
        /// <param name="metaModelId">Initial value of the MetaModelId property.</param>
        public static MetaItem CreateMetaItem(global::System.Guid metaItemId, global::System.String metaItemName, global::System.Guid metaModelId)
        {
            MetaItem metaItem = new MetaItem();
            metaItem.MetaItemId = metaItemId;
            metaItem.MetaItemName = metaItemName;
            metaItem.MetaModelId = metaModelId;
            return metaItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid MetaItemId
        {
            get
            {
                return _MetaItemId;
            }
            set
            {
                if (_MetaItemId != value)
                {
                    OnMetaItemIdChanging(value);
                    ReportPropertyChanging("MetaItemId");
                    _MetaItemId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MetaItemId");
                    OnMetaItemIdChanged();
                }
            }
        }
        private global::System.Guid _MetaItemId;
        partial void OnMetaItemIdChanging(global::System.Guid value);
        partial void OnMetaItemIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MetaItemName
        {
            get
            {
                return _MetaItemName;
            }
            set
            {
                OnMetaItemNameChanging(value);
                ReportPropertyChanging("MetaItemName");
                _MetaItemName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MetaItemName");
                OnMetaItemNameChanged();
            }
        }
        private global::System.String _MetaItemName;
        partial void OnMetaItemNameChanging(global::System.String value);
        partial void OnMetaItemNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid MetaModelId
        {
            get
            {
                return _MetaModelId;
            }
            set
            {
                OnMetaModelIdChanging(value);
                ReportPropertyChanging("MetaModelId");
                _MetaModelId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MetaModelId");
                OnMetaModelIdChanged();
            }
        }
        private global::System.Guid _MetaModelId;
        partial void OnMetaModelIdChanging(global::System.Guid value);
        partial void OnMetaModelIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HaymanReadModelModel", "FK_MetaAssociation_MetaItemSource", "MetaAssociation")]
        public EntityCollection<MetaAssociation> IncomingMetaAssociations
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<MetaAssociation>("HaymanReadModelModel.FK_MetaAssociation_MetaItemSource", "MetaAssociation");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<MetaAssociation>("HaymanReadModelModel.FK_MetaAssociation_MetaItemSource", "MetaAssociation", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HaymanReadModelModel", "FK_MetaAssociation_MetaItemTarget", "MetaAssociation")]
        public EntityCollection<MetaAssociation> OutgoingMetaAssociations
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<MetaAssociation>("HaymanReadModelModel.FK_MetaAssociation_MetaItemTarget", "MetaAssociation");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<MetaAssociation>("HaymanReadModelModel.FK_MetaAssociation_MetaItemTarget", "MetaAssociation", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HaymanReadModelModel", "FK_MetaItem_MetaModel", "MetaModel")]
        public MetaModel MetaModel
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaModel>("HaymanReadModelModel.FK_MetaItem_MetaModel", "MetaModel").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaModel>("HaymanReadModelModel.FK_MetaItem_MetaModel", "MetaModel").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<MetaModel> MetaModelReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<MetaModel>("HaymanReadModelModel.FK_MetaItem_MetaModel", "MetaModel");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<MetaModel>("HaymanReadModelModel.FK_MetaItem_MetaModel", "MetaModel", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HaymanReadModelModel", Name="MetaModel")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class MetaModel : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new MetaModel object.
        /// </summary>
        /// <param name="metaModelId">Initial value of the MetaModelId property.</param>
        /// <param name="metaModelName">Initial value of the MetaModelName property.</param>
        /// <param name="deleted">Initial value of the Deleted property.</param>
        public static MetaModel CreateMetaModel(global::System.Guid metaModelId, global::System.String metaModelName, global::System.Boolean deleted)
        {
            MetaModel metaModel = new MetaModel();
            metaModel.MetaModelId = metaModelId;
            metaModel.MetaModelName = metaModelName;
            metaModel.Deleted = deleted;
            return metaModel;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid MetaModelId
        {
            get
            {
                return _MetaModelId;
            }
            set
            {
                if (_MetaModelId != value)
                {
                    OnMetaModelIdChanging(value);
                    ReportPropertyChanging("MetaModelId");
                    _MetaModelId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MetaModelId");
                    OnMetaModelIdChanged();
                }
            }
        }
        private global::System.Guid _MetaModelId;
        partial void OnMetaModelIdChanging(global::System.Guid value);
        partial void OnMetaModelIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MetaModelName
        {
            get
            {
                return _MetaModelName;
            }
            set
            {
                OnMetaModelNameChanging(value);
                ReportPropertyChanging("MetaModelName");
                _MetaModelName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MetaModelName");
                OnMetaModelNameChanged();
            }
        }
        private global::System.String _MetaModelName;
        partial void OnMetaModelNameChanging(global::System.String value);
        partial void OnMetaModelNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                OnDeletedChanging(value);
                ReportPropertyChanging("Deleted");
                _Deleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Deleted");
                OnDeletedChanged();
            }
        }
        private global::System.Boolean _Deleted;
        partial void OnDeletedChanging(global::System.Boolean value);
        partial void OnDeletedChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HaymanReadModelModel", "FK_MetaItem_MetaModel", "MetaItem")]
        public EntityCollection<MetaItem> MetaItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<MetaItem>("HaymanReadModelModel.FK_MetaItem_MetaModel", "MetaItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<MetaItem>("HaymanReadModelModel.FK_MetaItem_MetaModel", "MetaItem", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}