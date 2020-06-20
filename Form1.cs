using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get purchase amount from txtPurchase textbox object.
            double purchaseAmt = GetDouble(txtPurchase);

            // Get tax percentage value from its label element
            double percent = GetPercentAsDecimal(lblTaxPercent.Text);

            // multiply base value by percentage
            double ans = GetTotalWithTax(purchaseAmt, percent);

            // Display the total as a string.
            txtTotalDue.Text = string.Format($"{ans:C}");
            // return result
        }
        private double GetPercentAsDecimal(string inValue)
        {
            string percentage = (inValue[^1].Equals('%')) ? inValue.Remove(inValue.Length - 1, 1) : inValue;
            return double.Parse(percentage) / 100;
        }
        private double GetDouble(TextBox fromTextBox)
        {
            double purchaseAmt;
            // Ensure user enters a number
            while (double.TryParse(fromTextBox.Text, out purchaseAmt) == false)
            {
                MessageBox.Show("You must enter a number");
                // Reset text
                fromTextBox.Text = "0.0";
                fromTextBox.Focus();
            }
            return purchaseAmt;

        }
        private double GetTotalWithTax(double baseAmount, double taxPercentageAsDecimal)
        {
            return (baseAmount * taxPercentageAsDecimal) + baseAmount;
        }
    }
}
