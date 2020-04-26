using PowerTrader.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace PowerTrader.Model
{
    public class PriceData
    {
        public DataRequest DataRequest {get; private set;}
        public ObservableCollection<DataBar> SecurityPriceData {get; set; }
        public List<IIndicator> Indicators {get; set; }
        


        #region  C O N S T R U C T O R
        public PriceData(DataRequest dataRequest)
        {
            DataRequest = dataRequest;
            SecurityPriceData = new ObservableCollection<DataBar>();
            SecurityPriceData.CollectionChanged += PriceData_CollectionChanged;
        }

        public PriceData()
        {

        }

        public delegate void PriceDataChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e);
        public event PriceDataChangedEventHandler PriceDataChanged;
        protected virtual void OnPriceDataChanged(NotifyCollectionChangedEventArgs e)
        {
            if (PriceDataChanged != null)
            {
                PriceDataChanged(this, e);
            }
        }


        private void PriceData_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPriceDataChanged(e);
        }

        
        #endregion  C O N S T R U C T O R




    }

    



}
