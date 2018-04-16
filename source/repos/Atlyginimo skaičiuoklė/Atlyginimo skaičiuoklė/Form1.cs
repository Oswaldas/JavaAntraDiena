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
    public partial class Form1 : Form
    {
        //variables
        public double Atlyginimas_i_rankas;
        public double Pajamu_mokestis = 0;
        public double Sodros_sveikatos_draudimas = 0;
        public double Sodros_pensiju_draudimas = 0;
        public double Darbdavio_mokesciai = 0;
        public double Darbo_vietos_kaina;
        public double Atlyginimas_ant_popieriaus;
        public double Autorinis_atlyginimas_i_rankas = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //hiden Authors Salary In Hand
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
        //Counting Authors Salary In Hand
        private void butSkaiciuotiAtlyginimaIRankas_Click(object sender, EventArgs e)
        {
            double Atlyginimas_ant_popieriaus = 0.0;
            //variable SalaryOnPaper obtained from textbox 
            if (isDigital(tBoxAtlyginimasPop.Text))
            {
                Atlyginimas_ant_popieriaus = Convert.ToDouble(this.tBoxAtlyginimasPop.Text);
            }
            else
            {
                MessageBox.Show("Turite įvesti skaičių");
                return;
            }
            //variables obtained from the tax window
            //double Atlyginimas_ant_popieriaus = Convert.ToDouble(this.tBoxAtlyginimasPop.Text);
            double PajamuProc = Convert.ToDouble(this.tBoxPajamuProc.Text);
            double SveikatosProc = Convert.ToDouble(this.tBoxSveikatosProc.Text);
            double PensijuProc = Convert.ToDouble(this.tBoxPensijuProc.Text);
            double DarbdavioProc = Convert.ToDouble(this.tBoxDarbdavioProc.Text);
            double Papildomas_proc = Convert.ToDouble(this.tBoxAtlyginimasPop.Text) / 100;

            //Counting Fees
            if (cBoxPapildomaPensija.Checked == true)
            {
                PensijuProc += 2;
            }
            Pajamu_mokestis = Math.Round((Atlyginimas_ant_popieriaus * (PajamuProc / 100)), 2);
            Sodros_sveikatos_draudimas = Math.Round((Atlyginimas_ant_popieriaus * (SveikatosProc / 100)), 2);
            Sodros_pensiju_draudimas = Math.Round((Atlyginimas_ant_popieriaus * (PensijuProc / 100)), 2);
            Darbdavio_mokesciai = Math.Round((Atlyginimas_ant_popieriaus * (DarbdavioProc / 100)), 2);
            Atlyginimas_i_rankas = Math.Round((Atlyginimas_ant_popieriaus - (Pajamu_mokestis + Sodros_sveikatos_draudimas + Sodros_pensiju_draudimas)), 2);
            Darbo_vietos_kaina = Atlyginimas_ant_popieriaus + Darbdavio_mokesciai;

            //Procentines israiskos isvedimas
            //labelPajamuProc.Text;
            //Skaiciavimu isvedimas i label
            labelAtlyginimasIRankas.Text = Atlyginimas_i_rankas.ToString();
            labelPajamuMokestis.Text = Pajamu_mokestis.ToString();
            labelSveikatosDraudimas.Text = Sodros_sveikatos_draudimas.ToString();
            labelPensijuDraudimas.Text = Sodros_pensiju_draudimas.ToString();
            labelDarbdavioSodrai.Text = Darbdavio_mokesciai.ToString();
            labelDarboVietosKaina.Text = Darbo_vietos_kaina.ToString();
            //Procentines israiskos isvedimas
            lblPajamuProc1.Text = (PajamuProc / 100).ToString("P");
            lblSveikatosProc1.Text = (SveikatosProc / 100).ToString("P");
            lblPensijuProc1.Text = (PensijuProc / 100).ToString("P");
            lblDarbdavioProc1.Text = (DarbdavioProc / 100).ToString("P");
        }

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

        //private void cBoxPapildomaPensija_CheckedChanged(object sender, EventArgs e)

        private void butSkaiciuoti2_Click(object sender, EventArgs e)
        {
            //kintamieji
            double Autorines_pajamos_i_rankas;
            double Autoriniai_mokesciai = 0;
            double Uzsakovo_mokesciai = 0;
            double Uzsakovo_mokama_suma;
            //kintamieji gaunami is mokesciu nustatymo lango
            double Autorines_pajamos = Convert.ToDouble(this.tBoxAutorines.Text);
            double tBoxAutoriniaiProc = Convert.ToDouble(this.tBoxAutorines.Text) * Convert.ToDouble(this.tBoxAutoriniaiProc.Text) / 100;
            double tBoxUzakovoProc = Convert.ToDouble(this.tBoxAutorines.Text) * Convert.ToDouble(this.tBoxUzakovoProc.Text) / 100;
            //Autoriniu pajamu skaiciavimas
            Autorines_pajamos_i_rankas = Convert.ToDouble(this.tBoxAutorines.Text) - tBoxAutoriniaiProc;
            Uzsakovo_mokama_suma = Autorines_pajamos + tBoxUzakovoProc;
            //isvedimas
            labelAutorinesIRankas.Text = Autorines_pajamos_i_rankas.ToString();
            labelAutorinesUzsakovo.Text = Uzsakovo_mokama_suma.ToString();
        }

        private void buttonSkaiciuotiIRankas_Click(object sender, EventArgs e)
        {
            double Atlyginimas_i_rankas = 0;
            double Autorinis_atlyginimas_i_rankas = 0;
            //variable SalaryInHand obtained from textbox 
            if (IsDigital(tBoxAtlyginimasIRankas.Text) || IsDigital(tboxAutorinisIRankas.Text))
            {
                Atlyginimas_i_rankas = Convert.ToDouble(this.tBoxAtlyginimasIRankas.Text);
                Autorinis_atlyginimas_i_rankas = Convert.ToDouble(this.tboxAutorinisIRankas.Text);
            }

            else
            {
                MessageBox.Show("Turite įvesti skaičių");
                return;
            }
            //kintamieji gaunami is mokesciu nustatymo lango
            double Atlyginimas_i_rankasTBox = Convert.ToDouble(this.tBoxAtlyginimasIRankas.Text);
            double Pajamu_mokestisTBox = Convert.ToDouble(this.tBoxPajamuProc.Text);
            double Sodros_sveikatos_draudimasTBox = Convert.ToDouble(this.tBoxSveikatosProc.Text);
            double Sodros_pensiju_draudimasTBox = Convert.ToDouble(this.tBoxPensijuProc.Text);
            double Autorinis_atlyginimas_i_rankasTBox = Convert.ToDouble(this.tboxAutorinisIRankas.Text);
            double Darbdavio_mokesciaiTBox = Convert.ToDouble(this.tBoxDarbdavioProc.Text);

            // Papildomai pensijai
            if (checkBoxPensija.Checked == true)
            {
                Sodros_pensiju_draudimasTBox += 2;
            }
            if (Autorinis_atlyginimas_i_rankasTBox > 0 && Atlyginimas_i_rankasTBox > 0)
            {
                double autorines_popierius = Math.Round(Autorinis_atlyginimas_i_rankasTBox * (100 / (100 - (Pajamu_mokestisTBox + Sodros_sveikatos_draudimasTBox + Sodros_pensiju_draudimasTBox))), 2);
                double pajamu_autorines = Math.Round((autorines_popierius * (Pajamu_mokestisTBox / 100)), 2);
                double sveikatos_autorines = Math.Round((autorines_popierius * (Sodros_sveikatos_draudimasTBox / 100)), 2);
                double pensiju_autorines = Math.Round((autorines_popierius * (Sodros_pensiju_draudimasTBox / 100)), 2);

                //Mokesciu skaiciavimai su procentais 
                double atlyginimas_ant_popieriaus2 = Math.Round(Atlyginimas_i_rankasTBox * (100 / (100 - (Pajamu_mokestisTBox + Sodros_sveikatos_draudimasTBox + Sodros_pensiju_draudimasTBox))), 2);
                double pajamu_mokestis2 = Math.Round((atlyginimas_ant_popieriaus2 * (Pajamu_mokestisTBox / 100)), 2);
                double sveikatos_draudimas2 = Math.Round((atlyginimas_ant_popieriaus2 * (Sodros_sveikatos_draudimasTBox / 100)), 2);
                double pensiju_draudimas2 = Math.Round((atlyginimas_ant_popieriaus2 * (Sodros_pensiju_draudimasTBox / 100)), 2);
                Darbdavio_mokesciai = Math.Round((atlyginimas_ant_popieriaus2 * (Darbdavio_mokesciaiTBox / 100)), 2);
                Darbo_vietos_kaina = Math.Round((atlyginimas_ant_popieriaus2 + Darbdavio_mokesciai), 2);

                Atlyginimas_ant_popieriaus = atlyginimas_ant_popieriaus2 + autorines_popierius;
                Pajamu_mokestis = pajamu_autorines + pajamu_mokestis2;
                Sodros_sveikatos_draudimas = sveikatos_draudimas2 + sveikatos_autorines;
                Sodros_pensiju_draudimas = pensiju_draudimas2 + pensiju_autorines;
            }
            else if (Autorinis_atlyginimas_i_rankasTBox > 0)
            {
                Atlyginimas_ant_popieriaus = Math.Round(Autorinis_atlyginimas_i_rankasTBox * (100 / (100 - (Pajamu_mokestisTBox + Sodros_sveikatos_draudimasTBox + Sodros_pensiju_draudimasTBox))), 2);
                Pajamu_mokestis = Math.Round((Atlyginimas_ant_popieriaus * (Pajamu_mokestisTBox / 100)), 2);
                Sodros_sveikatos_draudimas = Math.Round((Atlyginimas_ant_popieriaus * (Sodros_sveikatos_draudimasTBox / 100)), 2);
                Sodros_pensiju_draudimas = Math.Round((Atlyginimas_ant_popieriaus * (Sodros_pensiju_draudimasTBox / 100)), 2);
            }

            else if (Atlyginimas_i_rankasTBox > 0)
            {
                Atlyginimas_ant_popieriaus = Math.Round(Atlyginimas_i_rankasTBox * (100 / (100 - (Pajamu_mokestisTBox + Sodros_sveikatos_draudimasTBox + Sodros_pensiju_draudimasTBox))), 2);
                Pajamu_mokestis = Math.Round((Atlyginimas_ant_popieriaus * (Pajamu_mokestisTBox / 100)), 2);
                Sodros_sveikatos_draudimas = Math.Round((Atlyginimas_ant_popieriaus * (Sodros_sveikatos_draudimasTBox / 100)), 2);
                Sodros_pensiju_draudimas = Math.Round((Atlyginimas_ant_popieriaus * (Sodros_pensiju_draudimasTBox / 100)), 2);
                Darbdavio_mokesciai = Math.Round((Atlyginimas_ant_popieriaus * (Darbdavio_mokesciaiTBox / 100)), 2);
                Darbo_vietos_kaina = Math.Round((Atlyginimas_ant_popieriaus + Darbdavio_mokesciai), 2);
            }
            //Skaiciavimu isvedimas
            lblPajamos.Text = Pajamu_mokestis.ToString();
            lblSveikatos.Text = Sodros_sveikatos_draudimas.ToString();
            lblPensiju.Text = Sodros_pensiju_draudimas.ToString();
            lblAtlyginimas.Text = Atlyginimas_ant_popieriaus.ToString();
            lblDarbdavio.Text = Darbdavio_mokesciai.ToString();
            lblDarboVieta.Text = Darbo_vietos_kaina.ToString();
            //Procentines israiskos isvedimas
            lblPajamuProc.Text = (Pajamu_mokestisTBox / 100).ToString("P");
            lblSveikatosProc.Text = (Sodros_sveikatos_draudimasTBox / 100).ToString("P");
            lblPensijuProc.Text = (Sodros_pensiju_draudimasTBox / 100).ToString("P");
            lblDarbdavioProc.Text = (Darbdavio_mokesciaiTBox / 100).ToString("P");
        }

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

        private void butReset_Click(object sender, EventArgs e)
        {
            tBoxPajamuProc.Text = "0";
            tBoxSveikatosProc.Text = "0";
            tBoxPensijuProc.Text = "0";
            tBoxDarbdavioProc.Text = "0";
            tBoxAutoriniaiProc.Text = "0";
            tBoxUzakovoProc.Text = "0";
        }

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
