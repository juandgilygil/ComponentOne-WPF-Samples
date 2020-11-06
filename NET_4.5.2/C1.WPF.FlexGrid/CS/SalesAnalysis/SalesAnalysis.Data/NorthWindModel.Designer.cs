﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace SalesAnalysis.Data
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class NORTHWNDEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new NORTHWNDEntities object using the connection string found in the 'NORTHWNDEntities' section of the application configuration file.
        /// </summary>
        public NORTHWNDEntities() : base("name=NORTHWNDEntities", "NORTHWNDEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NORTHWNDEntities object.
        /// </summary>
        public NORTHWNDEntities(string connectionString) : base(connectionString, "NORTHWNDEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NORTHWNDEntities object.
        /// </summary>
        public NORTHWNDEntities(EntityConnection connection) : base(connection, "NORTHWNDEntities")
        {
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
        public ObjectSet<Invoice> Invoices
        {
            get
            {
                if ((_Invoices == null))
                {
                    _Invoices = base.CreateObjectSet<Invoice>("Invoices");
                }
                return _Invoices;
            }
        }
        private ObjectSet<Invoice> _Invoices;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Invoices EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToInvoices(Invoice invoice)
        {
            base.AddObject("Invoices", invoice);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Invoice")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Invoice : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Invoice object.
        /// </summary>
        /// <param name="customerName">Initial value of the CustomerName property.</param>
        /// <param name="salesperson">Initial value of the Salesperson property.</param>
        /// <param name="orderID">Initial value of the OrderID property.</param>
        /// <param name="shipperName">Initial value of the ShipperName property.</param>
        /// <param name="productID">Initial value of the ProductID property.</param>
        /// <param name="productName">Initial value of the ProductName property.</param>
        /// <param name="unitPrice">Initial value of the UnitPrice property.</param>
        /// <param name="quantity">Initial value of the Quantity property.</param>
        /// <param name="discount">Initial value of the Discount property.</param>
        public static Invoice CreateInvoice(global::System.String customerName, global::System.String salesperson, global::System.Int32 orderID, global::System.String shipperName, global::System.Int32 productID, global::System.String productName, global::System.Decimal unitPrice, global::System.Int16 quantity, global::System.Single discount)
        {
            Invoice invoice = new Invoice();
            invoice.CustomerName = customerName;
            invoice.Salesperson = salesperson;
            invoice.OrderID = orderID;
            invoice.ShipperName = shipperName;
            invoice.ProductID = productID;
            invoice.ProductName = productName;
            invoice.UnitPrice = unitPrice;
            invoice.Quantity = quantity;
            invoice.Discount = discount;
            return invoice;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipName
        {
            get
            {
                return _ShipName;
            }
            set
            {
                OnShipNameChanging(value);
                ReportPropertyChanging("ShipName");
                _ShipName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipName");
                OnShipNameChanged();
            }
        }
        private global::System.String _ShipName;
        partial void OnShipNameChanging(global::System.String value);
        partial void OnShipNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipAddress
        {
            get
            {
                return _ShipAddress;
            }
            set
            {
                OnShipAddressChanging(value);
                ReportPropertyChanging("ShipAddress");
                _ShipAddress = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipAddress");
                OnShipAddressChanged();
            }
        }
        private global::System.String _ShipAddress;
        partial void OnShipAddressChanging(global::System.String value);
        partial void OnShipAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipCity
        {
            get
            {
                return _ShipCity;
            }
            set
            {
                OnShipCityChanging(value);
                ReportPropertyChanging("ShipCity");
                _ShipCity = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipCity");
                OnShipCityChanged();
            }
        }
        private global::System.String _ShipCity;
        partial void OnShipCityChanging(global::System.String value);
        partial void OnShipCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipRegion
        {
            get
            {
                return _ShipRegion;
            }
            set
            {
                OnShipRegionChanging(value);
                ReportPropertyChanging("ShipRegion");
                _ShipRegion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipRegion");
                OnShipRegionChanged();
            }
        }
        private global::System.String _ShipRegion;
        partial void OnShipRegionChanging(global::System.String value);
        partial void OnShipRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipPostalCode
        {
            get
            {
                return _ShipPostalCode;
            }
            set
            {
                OnShipPostalCodeChanging(value);
                ReportPropertyChanging("ShipPostalCode");
                _ShipPostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipPostalCode");
                OnShipPostalCodeChanged();
            }
        }
        private global::System.String _ShipPostalCode;
        partial void OnShipPostalCodeChanging(global::System.String value);
        partial void OnShipPostalCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipCountry
        {
            get
            {
                return _ShipCountry;
            }
            set
            {
                OnShipCountryChanging(value);
                ReportPropertyChanging("ShipCountry");
                _ShipCountry = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipCountry");
                OnShipCountryChanged();
            }
        }
        private global::System.String _ShipCountry;
        partial void OnShipCountryChanging(global::System.String value);
        partial void OnShipCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                OnCustomerIDChanging(value);
                ReportPropertyChanging("CustomerID");
                _CustomerID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CustomerID");
                OnCustomerIDChanged();
            }
        }
        private global::System.String _CustomerID;
        partial void OnCustomerIDChanging(global::System.String value);
        partial void OnCustomerIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                if (_CustomerName != value)
                {
                    OnCustomerNameChanging(value);
                    ReportPropertyChanging("CustomerName");
                    _CustomerName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("CustomerName");
                    OnCustomerNameChanged();
                }
            }
        }
        private global::System.String _CustomerName;
        partial void OnCustomerNameChanging(global::System.String value);
        partial void OnCustomerNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String City
        {
            get
            {
                return _City;
            }
            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }
        private global::System.String _City;
        partial void OnCityChanging(global::System.String value);
        partial void OnCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region
        {
            get
            {
                return _Region;
            }
            set
            {
                OnRegionChanging(value);
                ReportPropertyChanging("Region");
                _Region = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region");
                OnRegionChanged();
            }
        }
        private global::System.String _Region;
        partial void OnRegionChanging(global::System.String value);
        partial void OnRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                OnPostalCodeChanging(value);
                ReportPropertyChanging("PostalCode");
                _PostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PostalCode");
                OnPostalCodeChanged();
            }
        }
        private global::System.String _PostalCode;
        partial void OnPostalCodeChanging(global::System.String value);
        partial void OnPostalCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Salesperson
        {
            get
            {
                return _Salesperson;
            }
            set
            {
                if (_Salesperson != value)
                {
                    OnSalespersonChanging(value);
                    ReportPropertyChanging("Salesperson");
                    _Salesperson = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Salesperson");
                    OnSalespersonChanged();
                }
            }
        }
        private global::System.String _Salesperson;
        partial void OnSalespersonChanging(global::System.String value);
        partial void OnSalespersonChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                if (_OrderID != value)
                {
                    OnOrderIDChanging(value);
                    ReportPropertyChanging("OrderID");
                    _OrderID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OrderID");
                    OnOrderIDChanged();
                }
            }
        }
        private global::System.Int32 _OrderID;
        partial void OnOrderIDChanging(global::System.Int32 value);
        partial void OnOrderIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                OnOrderDateChanging(value);
                ReportPropertyChanging("OrderDate");
                _OrderDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OrderDate");
                OnOrderDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> RequiredDate
        {
            get
            {
                return _RequiredDate;
            }
            set
            {
                OnRequiredDateChanging(value);
                ReportPropertyChanging("RequiredDate");
                _RequiredDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RequiredDate");
                OnRequiredDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _RequiredDate;
        partial void OnRequiredDateChanging(Nullable<global::System.DateTime> value);
        partial void OnRequiredDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return _ShippedDate;
            }
            set
            {
                OnShippedDateChanging(value);
                ReportPropertyChanging("ShippedDate");
                _ShippedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShippedDate");
                OnShippedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ShipperName
        {
            get
            {
                return _ShipperName;
            }
            set
            {
                if (_ShipperName != value)
                {
                    OnShipperNameChanging(value);
                    ReportPropertyChanging("ShipperName");
                    _ShipperName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("ShipperName");
                    OnShipperNameChanged();
                }
            }
        }
        private global::System.String _ShipperName;
        partial void OnShipperNameChanging(global::System.String value);
        partial void OnShipperNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                if (_ProductID != value)
                {
                    OnProductIDChanging(value);
                    ReportPropertyChanging("ProductID");
                    _ProductID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ProductID");
                    OnProductIDChanged();
                }
            }
        }
        private global::System.Int32 _ProductID;
        partial void OnProductIDChanging(global::System.Int32 value);
        partial void OnProductIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                if (_ProductName != value)
                {
                    OnProductNameChanging(value);
                    ReportPropertyChanging("ProductName");
                    _ProductName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("ProductName");
                    OnProductNameChanged();
                }
            }
        }
        private global::System.String _ProductName;
        partial void OnProductNameChanging(global::System.String value);
        partial void OnProductNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                if (_UnitPrice != value)
                {
                    OnUnitPriceChanging(value);
                    ReportPropertyChanging("UnitPrice");
                    _UnitPrice = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UnitPrice");
                    OnUnitPriceChanged();
                }
            }
        }
        private global::System.Decimal _UnitPrice;
        partial void OnUnitPriceChanging(global::System.Decimal value);
        partial void OnUnitPriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                if (_Quantity != value)
                {
                    OnQuantityChanging(value);
                    ReportPropertyChanging("Quantity");
                    _Quantity = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Quantity");
                    OnQuantityChanged();
                }
            }
        }
        private global::System.Int16 _Quantity;
        partial void OnQuantityChanging(global::System.Int16 value);
        partial void OnQuantityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Single Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                if (_Discount != value)
                {
                    OnDiscountChanging(value);
                    ReportPropertyChanging("Discount");
                    _Discount = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Discount");
                    OnDiscountChanged();
                }
            }
        }
        private global::System.Single _Discount;
        partial void OnDiscountChanging(global::System.Single value);
        partial void OnDiscountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> ExtendedPrice
        {
            get
            {
                return _ExtendedPrice;
            }
            set
            {
                OnExtendedPriceChanging(value);
                ReportPropertyChanging("ExtendedPrice");
                _ExtendedPrice = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ExtendedPrice");
                OnExtendedPriceChanged();
            }
        }
        private Nullable<global::System.Decimal> _ExtendedPrice;
        partial void OnExtendedPriceChanging(Nullable<global::System.Decimal> value);
        partial void OnExtendedPriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Freight
        {
            get
            {
                return _Freight;
            }
            set
            {
                OnFreightChanging(value);
                ReportPropertyChanging("Freight");
                _Freight = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Freight");
                OnFreightChanged();
            }
        }
        private Nullable<global::System.Decimal> _Freight;
        partial void OnFreightChanging(Nullable<global::System.Decimal> value);
        partial void OnFreightChanged();

        #endregion

    
    }

    #endregion

    
}
