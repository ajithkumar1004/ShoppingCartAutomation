using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartAutomation.Common
{
    public class Session
    {
        #region Session Declaration
        private static Session _instance = null;
        private static readonly object _objectLock = new object();
        private static string _productQuantity;
        private static string _productSize;
        private static string _modelDemo;
        private static string _price;
        private static string _product;
        private static int _quantityValue;
        #endregion

        private Session()
        {
        }

        public static Session Instance
        {
            get
            {
                lock(_objectLock)
                {
                    if(_instance == null)
                    {
                        _instance = new Session();
                    }
                }
                return _instance;
            }
        }

        public string ProductQuantity
        {
            get
            {
                return _productQuantity;
            }

            set
            {
                _productQuantity = value;
            }
        }

        public string ProductSize
        {
            get
            {
                return _productSize;
            }

            set
            {
                _productSize = value;
            }
        }

        public string ModelDemo
        {
            get
            {
                return _modelDemo;
            }

            set
            {
                _modelDemo = value;
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public string Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }

        public int ProductQuantityValue
        {
            get
            {
                return _quantityValue;
            }

            set
            {
                _quantityValue = value;
            }
        }
    }
}
