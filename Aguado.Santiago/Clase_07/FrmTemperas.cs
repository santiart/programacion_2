using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_06.Entidades;

namespace Clase_07
{
    public partial class FrmTemperas : Form
    {
        Clase_06.Entidades.Tempera t;
        Clase_06.Entidades.Paleta p;
        FrmTemperas frm;
        private string tempera;

        public string MiTempera
        {
            get { return tempera; }
        }


        public FrmTemperas()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            
            foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
            {
                this.comboBox3.Items.Add(c);
            }
            this.comboBox3.SelectedItem = ConsoleColor.Magenta;
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void buttonAccept(object sender, EventArgs e)
        {
            string brand;
            string cant;
            ConsoleColor colour;

            brand = this.textBox2.Text;
            cant = this.textBox3.Text;
            colour = (ConsoleColor)this.comboBox3.SelectedItem;
            this.t = new Tempera(colour, brand, int.Parse(cant));
            MessageBox.Show(this.t);
            //this.DialogResult
            
            this.Close();

        }

        private void buttonCancel(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
