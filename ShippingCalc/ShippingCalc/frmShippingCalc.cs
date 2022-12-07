using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShippingCalc
{
    public partial class frmShippingCalc : Form
    {
        public frmShippingCalc()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        { 
            //DECLARATIONS
            double weight;
            double distance;
            double shippingCharge;
            double shippingRate;
            string caption=""; //Error handling messagebox title
            MessageBoxIcon MessageIcon = MessageBoxIcon.Error; //Changing icon in error handling

            try
            {
                //DATA VALIDATION & INITIALIZATION
                if (!double.TryParse(txtWeight.Text, out weight))
                {
                    caption = "Invalid Data: Weight";
                    MessageIcon = MessageBoxIcon.Error;
                    txtWeight.Focus();
                    txtWeight.SelectAll();
                    throw new Exception("Please enter Valid number in Weight input field!");
                }
                else
                {
                    //CONTROL WEIGHT DATA LIMIT BETWEEN 1-20
                    if (weight.CompareTo(1) < 0 || weight.CompareTo(20) > 0)
                    {
                        caption = "Data Limit: Weight";
                        MessageIcon = MessageBoxIcon.Warning;
                        txtWeight.Focus();
                        txtWeight.SelectAll();
                        throw new Exception("Weight must be in between 1 - 20 kg.");
                    }
                }

                if (!double.TryParse(txtDistance.Text, out distance))
                {
                    caption = "Invalid Data: Distance";
                    MessageIcon = MessageBoxIcon.Error;
                    txtDistance.Focus();
                    txtDistance.SelectAll();
                    throw new Exception("Please enter Valid number in distance input field!");
                }
                else
                {
                    if (distance.CompareTo(10) < 0 || distance.CompareTo(3000) > 0)
                    {
                        caption = "Data Limit: Distance";
                        MessageIcon = MessageBoxIcon.Warning;
                        txtDistance.Focus();
                        txtDistance.SelectAll();
                        throw new Exception("Distance must be in between 10 - 3000 miles.");
                    }
                }

                //CONDITIONAL PARAMETERS FOR SHIPPING CHARGE
                if (weight.CompareTo(2) <= 0) //if weight is less than 2kg, rate is 0.01
                {
                    shippingRate = 0.01;
                }
                else if (weight.CompareTo(6) <= 0) //if  weight is less than 6 kg, rate is 0.015
                {
                    shippingRate = 0.015;
                }else if (weight.CompareTo(10) <= 0) //if  weight is less than 10 kg, rate is 0.020
                {
                    shippingRate = 0.02;
                }
                else if (weight.CompareTo(20) <= 0) //if  weight is less than 20 kg, rate is 0.025
                {
                    shippingRate = 0.025;
                }
                else //In case if weight limit change, we need to alert user and keep max. rate.
                {
                    shippingRate = 0.025;
                    caption = "Warning : Shipping Rate";
                    MessageIcon = MessageBoxIcon.Warning;
                    txtWeight.Focus();
                    txtWeight.SelectAll();
                    throw new Exception("Shipping Rate out of shipping weight limit");
                }
                
                //FINAL CALCULATION
                shippingCharge = distance * shippingRate;

                //DISPLAY ON SCREEN WITH PROPER FORMATTING
                lblShippingCharge.Text = String.Concat("$",string.Format("{0:0.##}",shippingCharge));
                MessageBox.Show("Process Completed!","information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                lblShippingCharge.Text = null;
                MessageBox.Show(ex.Message, caption,MessageBoxButtons.OK, MessageIcon);
            }

        }
    }
}
