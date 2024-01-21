using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace prog2_assignment
{
    internal class Product
    {
        private static int ProductCount = 0;
        public static int GetCount()
        {
            return ProductCount;
        }

        internal Product()
        {
            ProductCount++;
        }

        private int m_intProductId;
        private string m_stringProductName;
        private DateTime m_DateTimeManufactureDate;
        private int m_intWarranty;
        private double m_doublePrice;
        private int m_intStock;
        private int m_intGst;
        private int m_intDiscount;

        public int ProductId
        {
            get { return m_intProductId; }
            set
            {
                if (value > 0)
                    m_intProductId = value;
                else
                    throw new Exception("Must be > 0");
            }
        }
        public string ProductName
        {
            get { return m_stringProductName; }
            set
            {
                if (value.Length > 3)
                    m_stringProductName = value;
                else
                    throw new Exception(" Product name should be atleast 3 chars");
            }
        }
        public DateTime ManufactureDate
        {
            get { return m_DateTimeManufactureDate; }
            set
            {
                if (value < DateTime.Today) //check compare method
                    m_DateTimeManufactureDate = value;
                else
                    throw new Exception("ManufactureDate must be before today");
            }
        }
        public int Warranty
        {
            get { return m_intWarranty; }
            set { m_intWarranty = value; }
        }
        public double Price
        {
            get { return m_doublePrice; }
            set { m_doublePrice = value; }
        }
        public int Stock
        {
            get { return m_intStock; }
            set { m_intStock = value; }
        }
        public int Gst
        {
            get { return m_intGst; }
            set
            {
                if (value == 5 || value == 12 || value == 18 || value == 28)
                    m_intGst = value;
                else
                    throw new Exception("Gst must be 5, 12, 18, or 28");
            }
        }
        public int Discount
        {
            get { return m_intDiscount; }
            set
            {
                if (value >= 1 && value <= 30)
                    m_intDiscount = value;
                else
                    throw new Exception("Discount must be in the range 1-30");
            }
        }
        public double TotalPrice
        {
            get { return Discount * Stock; }
        }

        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Product Id " + ProductId + "\n");
            sb.Append("product Name " + ProductName + "\n");
            sb.Append("Manufacture Date " + ManufactureDate.ToLongDateString() + "\n");
            sb.Append("warranty " + Warranty + "\n");
            sb.Append("Stock " + Stock + "\n");
            sb.Append("Gst " + Gst + "\n");
            sb.Append("Tax Price " + (Price + (Gst / 100.0)) + "\n");// Price+=Gst/100
            sb.Append("Discount Price " + (Price * Discount) + "\n");// Discount = Price* Discount
            sb.Append("Total Price " + TotalPrice + "\n"); // TotalPrice = Discount * stock

            return sb.ToString();
        }

        public void Dispose()
        {
            Console.WriteLine("Release all resources here");
        }

    }
}