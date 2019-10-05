using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralitaPolimorfismo;

namespace CentralitaWindowsForms
{
  public partial class FrmCentralita : Form
  {
    Centralita telefonica = new Centralita();
    public enum tipoOrdenamiento { DuracionAscendente, DuracionDescendente, TipoLlamadaAscendente, TipoLlamadaDescendente }
    public FrmCentralita()
    {
      InitializeComponent();
      foreach (tipoOrdenamiento t in Enum.GetValues(typeof(tipoOrdenamiento)))
      {
        cboOrdenamiento.Items.Add(t);
      }
      cboOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      LlamadaLocal llamadaLocal = new LlamadaLocal();

      DialogResult dialogResult = llamadaLocal.ShowDialog();

      if (dialogResult == DialogResult.OK)
      {
        this.telefonica += llamadaLocal.local;

        lstVisor.Items.Clear();

        foreach (CentralitaPolimorfismo.Llamada llamada in this.telefonica.llamadas)
        {
          lstVisor.Items.Add(llamada.ToString());
        }
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      LlamadaProvincial llamadaProvincial = new LlamadaProvincial();

      DialogResult dialogResult = llamadaProvincial.ShowDialog();

      if (dialogResult == DialogResult.OK)
      {
        this.telefonica += llamadaProvincial.provincial;

        lstVisor.Items.Clear();

        foreach (CentralitaPolimorfismo.Llamada llamada in this.telefonica.llamadas)
        {
          lstVisor.Items.Add(llamada.ToString());
        }
      }
    }

    private void cboOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
    {
      int type = this.cboOrdenamiento.SelectedIndex;

      switch(type)
      {
        case 1:
          this.telefonica.llamadas.Sort(CentralitaPolimorfismo.Llamada.OrdenarPorDuracionAsc);
          break;
        case 2:
          this.telefonica.llamadas.Sort(CentralitaPolimorfismo.Llamada.OrdenarPorDuracionDesc);
          break;
      }
    }
  }
}
