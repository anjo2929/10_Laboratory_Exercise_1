using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _0_Laboratory_Exercise_1.Class1;

namespace _0_Laboratory_Exercise_1
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
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

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new StringFormatException("Product name must contain only letters.");
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^\d+$"))
                throw new NumberFormatException("Quantity must be a positive integer.");
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d+(\.\d{1,2})?)$"))
                throw new CurrencyFormatException("Selling price must be a valid decimal number.");
            return Convert.ToDouble(price);
        }    


        private void frmAddProduct_Load_1(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }
        private BindingSource showProductList = new BindingSource();

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = Product_Name(txtProductName.Text);
                string category = cbCategory.Text;
                string mfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                string expDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                string description = richTxtDescription.Text;
                int quantity = Quantity(txtQuantity.Text);
                double price = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(productName, category, mfgDate, expDate, price, quantity, description));

                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
