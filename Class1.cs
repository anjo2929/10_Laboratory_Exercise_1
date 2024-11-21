using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Laboratory_Exercise_1
{
    internal class Class1
    {

        public class ProductClass
        {
            private int _Quantity;
            private double _SellingPrice;
            private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

            public ProductClass(string productName, string category, string mfgDate, string expDate, double price, int quantity, string description)
            {
                this._ProductName = productName;
                this._Category = category;
                this._ManufacturingDate = mfgDate;
                this._ExpirationDate = expDate;
                this._SellingPrice = price;
                this._Quantity = quantity;
                this._Description = description;
            }

            public string ProductName { get => _ProductName; set => _ProductName = value; }
            public string Category { get => _Category; set => _Category = value; }
            public string ManufacturingDate { get => _ManufacturingDate; set => _ManufacturingDate = value; }
            public string ExpirationDate { get => _ExpirationDate; set => _ExpirationDate = value; }
            public string Description { get => _Description; set => _Description = value; }
            public int Quantity { get => _Quantity; set => _Quantity = value; }
            public double SellingPrice { get => _SellingPrice; set => _SellingPrice = value; }
        }

        public class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message) { }
        }

        public class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message) { }
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message) { }
        }

    }
}
