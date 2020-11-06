//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSourceSamples
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    public partial class Order_Detail : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    	protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        int _OrderID;
        public int OrderID 
        {
            get { return _OrderID; }
            set
            {
                _OrderID = value;
                OnPropertyChanged("OrderID");
            }
        }
        int _ProductID;
        public int ProductID 
        {
            get { return _ProductID; }
            set
            {
                _ProductID = value;
                OnPropertyChanged("ProductID");
            }
        }
        decimal _UnitPrice;
        public decimal UnitPrice 
        {
            get { return _UnitPrice; }
            set
            {
                _UnitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }
        short _Quantity;
        public short Quantity 
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        float _Discount;
        public float Discount 
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
                OnPropertyChanged("Discount");
            }
        }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
