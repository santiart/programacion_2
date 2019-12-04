﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdminPersonas
{
    public partial class FrmVisorDataTable : frmVisorPersona
    {
        DataTable dt;

        public FrmVisorDataTable(DataTable dat):base()
        {
            try
            {
                dt = dat;
                //DataRow dr;
                this.ActualizarLista();
                foreach(DataRow fila in this.Dt.Rows)
                {
                    this.ListaPersonas.Add(new Entidades.Persona(fila["nombre"].ToString(), fila["apellido"].ToString(), int.Parse(fila["edad"].ToString())));
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public DataTable Dt
        {
            get { return this.dt; }
        }

        public void ActualizarLista()
        {
            this.lstVisor.Items.Clear();
            foreach(DataRow d in dt.Rows)
            {
                //MessageBox.Show(d.RowState.ToString());
                if(d.RowState != DataRowState.Deleted)
                {
                    this.lstVisor.Items.Add($"{d[0]} - {d[1]} - {d[2]} - {d[3]}");
                }
                else
                {
                    //this.lstVisor.Items.
                    MessageBox.Show("sos adoptado");
                }
            }
        }

        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersona frm = new frmPersona();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    this.ListaPersonas.Add(frm.Persona);
                    DataRow dr = this.dt.NewRow();
                    dr["nombre"] = frm.Persona.nombre;
                    dr["apellido"] = frm.Persona.apellido;
                    dr["edad"] = frm.Persona.edad;
                    this.dt.Rows.Add(dr);
                    this.ActualizarLista();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString(),"Excepcion del metodo agregar");
            }
        }

        protected override void btnModificar_Click(object sender, EventArgs e)
        {
            DataRow dr = this.dt.Rows[this.lstVisor.SelectedIndex];
            frmPersona frm = new frmPersona(new Entidades.Persona(dr["nombre"].ToString(), dr["apellido"].ToString(),int.Parse(dr["edad"].ToString())));
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                dr["nombre"] = frm.Persona.nombre;
                dr["apellido"] = frm.Persona.apellido;
                dr["edad"] = frm.Persona.edad;
            }
            this.ActualizarLista();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstVisor.SelectedIndex >= 0)
                {
                    this.dt.Rows[this.lstVisor.SelectedIndex].Delete();                   
                    this.ActualizarLista();
                }
            }
            catch(Exception)
            {
                //MessageBox.Show(exc.ToString(), "Excepcion del metodo elimninar");
            }
        }
    }
}