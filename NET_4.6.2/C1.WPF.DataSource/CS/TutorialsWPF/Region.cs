//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TutorialsWPF
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    public partial class Region : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    	protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public Region()
        {
            this.Territories = new ObservableCollection<Territory>();
        }
    
        int _RegionID;
        public int RegionID 
        {
            get { return _RegionID; }
            set
            {
                _RegionID = value;
                OnPropertyChanged("RegionID");
            }
        }
        string _RegionDescription;
        public string RegionDescription 
        {
            get { return _RegionDescription; }
            set
            {
                _RegionDescription = value;
                OnPropertyChanged("RegionDescription");
            }
        }
    
        public virtual ObservableCollection<Territory> Territories { get; set; }
    }
}
