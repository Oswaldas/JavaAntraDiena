using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlyginimo_skaičiuoklė
{
    //Coding and variables are in enlish, o visi formos objektai (labeliai, textboxai ir checkboxai) - pavadinti lietuviškai, kad man būtų lengviau nesusipainioti beskaičiuojant kas yra kas :) 
    public partial class Form1 : Form
    {
        //Variables
        public double SalaryInHand;
        public double IncomeTax = 0;
        public double SodraHealthInsurance = 0;
        public double SodraPensionInsurance = 0;
        public double EmployersFees = 0;
        public double WorkPlacePrice;
        public double SalaryOnPaper;
        public double AuthorsSalaryInHand = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //Method To Get Same Variables From Tax Textboxes
        private void GetPercentageTBox(out double InsurancePercent, out double HealthPercent, out double PensionPercent, out double EmployeePercent, out double AuthorsPercent, out double ClientPercent)
        {
            //Get Nulls If Textboxes Are Empty
            InsurancePercent = HealthPercent = PensionPercent = EmployeePercent = AuthorsPercent = ClientPercent = 0;
            double.TryParse(tBoxPajamuProc.Text, out InsurancePercent);
            double.TryParse(tBoxSveikatosProc.Text, out HealthPercent);
            double.TryParse(tBoxPensijuProc.Text, out PensionPercent);
            double.TryParse(tBoxDarbdavioProc.Text, out EmployeePercent);
            double.TryParse(tBoxAutoriniaiProc.Text, out AuthorsPercent);
            double.TryParse(tBoxUzakovoProc.Text, out ClientPercent);
        }
        //Counting Authors Salary In Hand
        private void butSkaiciuotiAtlyginimaIRankas_Click(object sender, EventArgs e)
        {
            //Variable SalaryOnPaper Obtained From Textbox 
            double SalaryOnPaper = 0.0;
            if (isDigital(tBoxAtlyginimasPop.Text))
            {
                SalaryOnPaper = Convert.ToDouble(this.tBoxAtlyginimasPop.Text);
            }
            else
            {
                MessageBox.Show("Turite įvesti skaičių į Atlyginimo lauką");
                return;
            }
            //Variables Obtained From The Tax Window
            double InsurancePercent, HealthPercent, PensionPercent, EmployeePercent, AuthorsPercent, ClientPercent;
            GetPercentageTBox(out InsurancePercent, out HealthPercent, out PensionPercent, out EmployeePercent, out AuthorsPercent, out ClientPercent);
            
            //Counting Fees With Additional 2% Pension
            if (cBoxPapildomaPensija.Checked == true)
            {
                PensionPercent += 2;
            }
            //Counting Fees Withoud Additional Pension
            IncomeTax = Math.Round((SalaryOnPaper * (InsurancePercent / 100)), 2);
            SodraHealthInsurance = Math.Round((SalaryOnPaper * (HealthPercent / 100)), 2);
            SodraPensionInsurance = Math.Round((SalaryOnPaper * (PensionPercent / 100)), 2);
            EmployersFees = Math.Round((SalaryOnPaper * (EmployeePercent / 100)), 2);
            SalaryInHand = Math.Round((SalaryOnPaper - (IncomeTax + SodraHealthInsurance + SodraPensionInsurance)), 2);
            WorkPlacePrice = SalaryOnPaper + EmployersFees;

            //Calculations Output To Label
            labelAtlyginimasIRankas.Text = SalaryInHand.ToString();
            labelPajamuMokestis.Text = IncomeTax.ToString();
            labelSveikatosDraudimas.Text = SodraHealthInsurance.ToString();
            labelPensijuDraudimas.Text = SodraPensionInsurance.ToString();
            labelDarbdavioSodrai.Text = EmployersFees.ToString();
            labelDarboVietosKaina.Text = WorkPlacePrice.ToString();
            //Percentage Label Output
            lblPajamuProc1.Text = (InsurancePercent / 100).ToString("P");
            lblSveikatosProc1.Text = (HealthPercent / 100).ToString("P");
            lblPensijuProc1.Text = (PensionPercent / 100).ToString("P");
            lblDarbdavioProc1.Text = (EmployeePercent / 100).ToString("P");
        }
        //Hiden Authors Salary In Hand
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gBoxAutorines.Visible = false;
            CheckState state = Autorines.CheckState;

            switch (state)
            {
                case CheckState.Checked:
                    {
                        gBoxAutorines.Visible = true;
                        break;
                    }
                case CheckState.Indeterminate:
                case CheckState.Unchecked:
                    {
                        break;
                    }
            }
        }
        //Control To Let Input Only Numbers And "."
        private bool isDigital(string input)
        {
            double n;
            bool isDigital = false;
            isDigital = double.TryParse(input, out n);
            if (n <= 0)
            {
                isDigital = false;
            }
            return isDigital;
        }
        //Counting Authors Salary In Hand
        private void butSkaiciuoti2_Click(object sender, EventArgs e)
        {
            //Variables
            double AuthorsSalaryInHand;
            double AuthorsTax = 0;
            double ClientTaxes = 0;
            double ClientsPaidAmount;

            double AuthorsIncome = 0.0;
            if (isDigital(tBoxAutorines.Text))
            {
                AuthorsIncome = Convert.ToDouble(this.tBoxAutorines.Text);
            }
            else
            {
                MessageBox.Show("Įveskite autorinių pajamų nurodytų sutartyje sumą");
                return;
            }
            //Variables Obtained From The Tax Window
            double InsurancePercent, HealthPercent, PensionPercent, EmployeePercent, AuthorsPercent, ClientPercent;
            GetPercentageTBox(out InsurancePercent, out HealthPercent, out PensionPercent, out EmployeePercent, out AuthorsPercent, out ClientPercent);
            //Counting Authors Salary
            AuthorsTax = Math.Round((AuthorsIncome * (AuthorsPercent / 100)), 2);
            AuthorsSalaryInHand = Math.Round((AuthorsIncome - AuthorsTax), 2);
            ClientTaxes = Math.Round((AuthorsIncome * (ClientPercent / 100)), 2);
            ClientsPaidAmount = AuthorsIncome + ClientTaxes;
            //Output to Labels
            labelAutorinesIRankas.Text = AuthorsSalaryInHand.ToString();
            labelAutorinesUzsakovo.Text = ClientsPaidAmount.ToString();
        }

        //Counting Salary On Paper
        private void buttonSkaiciuotiIRankas_Click(object sender, EventArgs e)
        {
            double SalaryInHand = 0;
            double AuthorsSalaryInHand = 0;
            //Variable SalaryInHand Obtained From Textbox 
            if (IsDigital(tBoxAtlyginimasIRankas.Text) || IsDigital(tboxAutorinisIRankas.Text))
            {
                SalaryInHand = 0;
                double.TryParse(tBoxAtlyginimasIRankas.Text, out SalaryInHand);
                AuthorsSalaryInHand = 0;
                double.TryParse(tboxAutorinisIRankas.Text, out AuthorsSalaryInHand);
            }
            else
            {
                MessageBox.Show("Turite įvesti skaičių į bent vieno Atlyginimo lauką");
                return;
            }
            //Variables Obtained From The Tax Window
            double InsurancePercent, HealthPercent, PensionPercent, EmployeePercent, AuthorsPercent, ClientPercent;
            GetPercentageTBox(out InsurancePercent, out HealthPercent, out PensionPercent, out EmployeePercent, out AuthorsPercent, out ClientPercent);
            // Additional Pension
            if (checkBoxPensija.Checked == true)
            {
                PensionPercent += 2;
            }
            //Counting Salary On Paper with Authors Salary
            if (AuthorsSalaryInHand > 0 && SalaryInHand > 0)
            {
                double AuthorsSalaryOnPaper = Math.Round(AuthorsSalaryInHand * (100 / (100 - (InsurancePercent + HealthPercent + PensionPercent))), 2);
                double AuthorsIncome = Math.Round((AuthorsSalaryOnPaper * (InsurancePercent / 100)), 2);
                double AuthorsHealthCare = Math.Round((AuthorsSalaryOnPaper * (HealthPercent / 100)), 2);
                double AuthorsPension = Math.Round((AuthorsSalaryOnPaper * (PensionPercent / 100)), 2);

                //Counting Salary On Paper And Then Counting Percentage From That Salary 
                double SalaryOnlyOnPaper = Math.Round(SalaryInHand * (100 / (100 - (InsurancePercent + HealthPercent + PensionPercent))), 2);
                double IncomeTax2 = Math.Round((SalaryOnlyOnPaper * (InsurancePercent / 100)), 2);
                double HealthCare2 = Math.Round((SalaryOnlyOnPaper * (HealthPercent / 100)), 2);
                double PensionInsurance2 = Math.Round((SalaryOnlyOnPaper * (PensionPercent / 100)), 2);
                EmployersFees = Math.Round((SalaryOnlyOnPaper * (EmployeePercent / 100)), 2);
                WorkPlacePrice = Math.Round((SalaryOnlyOnPaper + EmployersFees), 2);

                SalaryOnPaper = SalaryOnlyOnPaper + AuthorsSalaryOnPaper;
                IncomeTax = AuthorsIncome + IncomeTax2;
                SodraHealthInsurance = AuthorsHealthCare + HealthCare2;
                SodraPensionInsurance = AuthorsPension + PensionInsurance2;
            }
            //Counting Only Authors Salary
            else if (AuthorsSalaryInHand > 0)
            {
                SalaryOnPaper = Math.Round(AuthorsSalaryInHand * (100 / (100 - (InsurancePercent + HealthPercent + PensionPercent))), 2);
                IncomeTax = Math.Round((SalaryOnPaper * (InsurancePercent / 100)), 2);
                SodraHealthInsurance = Math.Round((SalaryOnPaper * (HealthPercent / 100)), 2);
                SodraPensionInsurance = Math.Round((SalaryOnPaper * (PensionPercent / 100)), 2);
            }
            //Counting Only Main Job Salary
            else if (SalaryInHand > 0)
            {
                SalaryOnPaper = Math.Round(SalaryInHand * (100 / (100 - (InsurancePercent + HealthPercent + PensionPercent))), 2);
                IncomeTax = Math.Round((SalaryOnPaper * (InsurancePercent / 100)), 2);
                SodraHealthInsurance = Math.Round((SalaryOnPaper * (HealthPercent / 100)), 2);
                SodraPensionInsurance = Math.Round((SalaryOnPaper * (PensionPercent / 100)), 2);
                EmployersFees = Math.Round((SalaryOnPaper * (EmployeePercent / 100)), 2);
                WorkPlacePrice = Math.Round((SalaryOnPaper + EmployersFees), 2);
            }
            //Output To Label
            lblPajamos.Text = IncomeTax.ToString();
            lblSveikatos.Text = SodraHealthInsurance.ToString();
            lblPensiju.Text = SodraPensionInsurance.ToString();
            lblAtlyginimas.Text = SalaryOnPaper.ToString();
            lblDarbdavio.Text = EmployersFees.ToString();
            lblDarboVieta.Text = WorkPlacePrice.ToString();
            //Percentage Output To Label
            lblPajamuProc.Text = (InsurancePercent / 100).ToString("P");
            lblSveikatosProc.Text = (HealthPercent / 100).ToString("P");
            lblPensijuProc.Text = (PensionPercent / 100).ToString("P");
            lblDarbdavioProc.Text = (EmployeePercent / 100).ToString("P");
        }
        //Control To Let Input Only Numbers And "."
        private bool IsDigital(string input)
        {
            double n;
            bool isDigital = false;
            isDigital = double.TryParse(input, out n);

            if (n <= 0)
            {
                isDigital = false;

            }

            return isDigital;
        }
        //Button To Reset Tax Values
        private void butReset_Click(object sender, EventArgs e)
        {
            tBoxPajamuProc.Text = tBoxSveikatosProc.Text = tBoxPensijuProc.Text = tBoxDarbdavioProc.Text = tBoxAutoriniaiProc.Text = tBoxUzakovoProc.Text = "0";
            tBoxAtlyginimasPop.Text = tBoxAutorines.Text = tBoxAtlyginimasIRankas.Text = tboxAutorinisIRankas.Text = "";
            // Reset Calculations
            labelAtlyginimasIRankas.Text = labelPajamuMokestis.Text = labelSveikatosDraudimas.Text = labelPensijuDraudimas.Text = labelDarbdavioSodrai.Text = labelDarboVietosKaina.Text = labelAutorinesIRankas.Text = labelAutorinesUzsakovo.Text = lblPajamos.Text = lblSveikatos.Text = lblPensiju.Text = lblAtlyginimas.Text = lblDarbdavio.Text = lblDarboVieta.Text = "";
            //Reset Percentage
            lblPajamuProc1.Text = lblSveikatosProc1.Text = lblPensijuProc1.Text = lblDarbdavioProc1.Text = lblPajamuProc.Text = lblSveikatosProc.Text = lblPensijuProc.Text = lblDarbdavioProc.Text = ("0.00%");
        }
        //Button To Input Tax Values Based On VMI Values in LT
        public void butInsert_Click(object sender, EventArgs e)
        {
            tBoxPajamuProc.Text = "15";
            tBoxSveikatosProc.Text = "6";
            tBoxPensijuProc.Text = "3";
            tBoxDarbdavioProc.Text = "31.18";
            tBoxAutoriniaiProc.Text = "24";
            tBoxUzakovoProc.Text = "30.48";
        }
    }
}
