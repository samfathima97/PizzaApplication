using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace PizzaApplication
{
    public partial class PizzaApplication : Form
    {
        public PizzaApplication()
        {
            InitializeComponent();
        }



        private void Start_Button_Click(object sender, EventArgs e)
        {
            string ServerName = ServerName_TxtBox.Text;
            string TableNumber = TableNum_TxtBox.Text;

            //If else condition to ensure no null value in Server Name and Table number text box
            if (string.IsNullOrEmpty(ServerName))
            {
                MessageBox.Show("Please enter a Server Name");
            }
            if (string.IsNullOrEmpty(TableNumber))
            {
                MessageBox.Show("Please enter Table Number");
            }
            else
            {
                WelcomePanel.Visible = false;
                PicPizzaLogo1.Visible = false;
                PicPizzaLogo2.Visible = true;
                Menu_GroupBox.Visible = true;
                Actions_Panel.Visible = true;
                Order_Button.Enabled = true;
                HamPizzaQty_TxtBox.Focus();


                this.Text = ServerName + " @ table " + TableNumber;
                //Output to Table Order Summary Table
                ServerName_Label.Text = ServerName;


            }


        }


        //field variable declaration and initialization to 0

        int TotalOrder = 0;
        int TotalNumOfPizza = 0;
        decimal TotalReceipt = 0m;
        int TotalHam = 0;
        int TotalPep = 0;
        int TotalPin = 0;
        int TotalCal = 0;

        private void Order_Button_Click(object sender, EventArgs e)
        {
            //incrementing order count at every click of the Order Button
            TotalOrder++;

            Menu_GroupBox.Enabled = false;
            Order_Button.Enabled = false;
            Clear_Button.Focus();
            
            //Exception handling for 4 Pizza inputs
            try
            {

                int HamQty, PepQty, PinQty, CalQty, NumOfPizza;
                HamQty = int.Parse(HamPizzaQty_TxtBox.Text);
                try
                {
                    PepQty = int.Parse(PepperoniQty_TxtBox.Text);

                    try
                    {
                        PinQty = int.Parse(PineappleQty_TxtBox.Text);

                        try
                        {
                                                       
                            CalQty = int.Parse(CalzoniQty_TxtBox.Text);
                            Summary_GroupBox.Visible = true;
                            this.Text = "Table Summary Data";

                            NumOfPizza = HamQty + PepQty + PinQty + CalQty;

                            //Incrementing item quantity for every transaction to display total values in Company Summary table
                            TotalNumOfPizza += NumOfPizza;
                            TotalHam += HamQty;
                            TotalPep += PepQty;
                            TotalPin += PinQty;
                            TotalCal += CalQty;

                            //Declaring Pizza prices
                            decimal HamPrice, PepPrice, PinPrice, CalPrice, TotalPrice, AvgValue;
                            HamPrice = 7.99m;
                            PepPrice = 8.99m;
                            PinPrice = 9.99m;
                            CalPrice = 11.99m;

                            //Performing Total Price and Average Calculations
                            TotalPrice = (HamQty * HamPrice) + (PepQty * PepPrice) + (PinQty * PinPrice) + (CalQty * CalPrice);
                            TotalReceipt += TotalPrice;
                            AvgValue = TotalReceipt / TotalOrder;

                            //Output to Table order Summary data
                            NumPizza_Label.Text = NumOfPizza.ToString();
                            TotalReceipt_Label.Text = "\u20AC " + TotalPrice.ToString();

                            //Output to Total Pizza's sold group box labels
                            HamPizzaTotal_LabelOutput.Text = TotalHam.ToString();
                            PepperoniPizzaTotal_LabelOutput.Text = TotalPep.ToString();
                            PineapplePizzaTotal_LabelOutput.Text = TotalPin.ToString();
                            CalzoniTotal_LabelOutput.Text = TotalCal.ToString();

                            //Output to Company Summary Labels
                            TotalTransaction_LabelOutput.Text = TotalOrder.ToString();
                            TotalPizzaOrdered_LabelOutput.Text = TotalNumOfPizza.ToString();
                            TotalCompanyReceipt_LabelOutput.Text = "\u20AC " + TotalReceipt.ToString();
                            AvgTransaction_LabelOutput.Text = "\u20AC " + AvgValue.ToString("0.00");

                            Summary_Button.Enabled = true;

                        }

                        catch
                        {
                            MessageBox.Show("Please enter numerical data for Calzoni Pizza", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Menu_GroupBox.Enabled = true;
                            CalzoniQty_TxtBox.Focus();
                            CalzoniQty_TxtBox.SelectAll();
                            Summary_GroupBox.Visible = false;
                            Order_Button.Enabled = true;


                        }
                    }
                    catch

                    {
                        MessageBox.Show("Please enter numerical data for Pineapple Pizza", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Menu_GroupBox.Enabled = true;
                        PineappleQty_TxtBox.Focus();
                        PineappleQty_TxtBox.SelectAll();
                        Summary_GroupBox.Visible = false;
                        Order_Button.Enabled = true;

                    }
                }

                catch
                {
                    MessageBox.Show("Please enter numerical data for Pepproni Pizza", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Menu_GroupBox.Enabled = true;
                    PepperoniQty_TxtBox.Focus();
                    PepperoniQty_TxtBox.SelectAll();
                    Summary_GroupBox.Visible = false;
                    Order_Button.Enabled = true;


                }
            }
            catch
            {
                MessageBox.Show("Please enter numerical data for Ham's Pizza", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Menu_GroupBox.Enabled = true;
                HamPizzaQty_TxtBox.Focus();
                HamPizzaQty_TxtBox.SelectAll();
                Summary_GroupBox.Visible = false;
                Order_Button.Enabled = true;

            }
        }
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            //Controlling visibility of panels
            Menu_GroupBox.Visible = false;
            Menu_GroupBox.Enabled = true;
            CompanySummary_GroupBox.Visible = false;
            TotalSale_GroupBox.Visible = false;
            PicPizzaLogo2.Visible = false;
            Actions_Panel.Visible = false;
            Summary_GroupBox.Visible = false;
            WelcomePanel.Visible = true;
            PicPizzaLogo1.Visible = true;
            PicPizzaLogo2.Visible = false;
            HamPizzaQty_TxtBox.Text = "0";
            PepperoniQty_TxtBox.Text = "0";
            PineappleQty_TxtBox.Text = "0";
            CalzoniQty_TxtBox.Text = "0";
            ServerName_TxtBox.Text = "";
            TableNum_TxtBox.Text = "";
            this.Text = "Welcome to PizzaBorthan";
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Summary_Button_Click(object sender, EventArgs e)
        {
                //Controlling visbility of panels
                this.Text = "Company Summary data";
                Menu_GroupBox.Visible = false;
                TotalSale_GroupBox.Visible = true;
                Summary_GroupBox.Visible = false;
                CompanySummary_GroupBox.Visible = true;
                Order_Button.Enabled = false;
                Clear_Button.Focus();
                HamPizzaTotal_LabelOutput.Enabled = false;
                PepperoniPizzaTotal_LabelOutput.Enabled = false;
                PineapplePizzaTotal_LabelOutput.Enabled = false;
                CalzoniTotal_LabelOutput.Enabled = false;
        }
     
    }
}
