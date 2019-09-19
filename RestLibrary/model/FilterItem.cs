using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.model
{
    public class FilterItem
    {
        private int _lowQuantity;
        private int _highQuantity;


        public FilterItem()
        {
        }


        public FilterItem(int lowQuantity, int highQuantity)
        {
            _lowQuantity = lowQuantity;
            _highQuantity = highQuantity;
        }


        public int HighQuantity
        {
            get { return _highQuantity; }
            set { _highQuantity = value; }
        }

        public int LowQuantity
        {
            get { return _lowQuantity; }
            set { _lowQuantity = value; }
        }

        public override string ToString()
        {
            return $"{nameof(HighQuantity)}: {HighQuantity}, {nameof(LowQuantity)}: {LowQuantity}";
        }
    }
}
