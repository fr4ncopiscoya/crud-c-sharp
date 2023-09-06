using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Attributes;
using Domain.crud;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Variables
        CAlumnos alumnos = new CAlumnos();
        Attributes attributes = new Attributes();
        bool edit = false;

        private void getData()
        {
            CAlumnos cAlumnos = new CAlumnos();
            dvgDatos.DataSource = cAlumnos.Mostrar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbSexo.SelectedIndex = 0;
            btnSave.Enabled = false;
            getData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState=FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            cbSexo.Text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(edit == false)
            {
                try
                {
                    attributes.Id = txtID.Text;
                    attributes.Name = txtName.Text;
                    attributes.Lastname = txtLastName.Text;
                    attributes.Sexo = cbSexo.Text;
                    alumnos.Insertar(attributes);
                    Clear();
                    getData();
                    btnSave.Enabled = false;
                    btnNew.Enabled = true;
                    MessageBox.Show( "Se registró correctamente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex)
                {
                    MessageBox.Show( $"Se produjo el siguiente error: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if(edit == true)
            {
                try
                {
                    attributes.Id = txtID.Text;
                    attributes.Name = txtName.Text;
                    attributes.Lastname = txtLastName.Text;
                    attributes.Sexo = cbSexo.Text;
                    alumnos.Modificar(attributes);
                    Clear();
                    getData();
                    btnSave.Enabled = false;
                    btnNew.Enabled = true;
                    txtID.Enabled = true;
                    edit = false;
                    MessageBox.Show("Se actualizó correctamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo el siguiente error: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnNew.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if(dvgDatos.SelectedRows.Count > 0)
            {
                txtID.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                edit = true;

                txtID.Text = dvgDatos.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dvgDatos.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dvgDatos.CurrentRow.Cells[2].Value.ToString();
                cbSexo.Text = dvgDatos.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dvgDatos.SelectedRows.Count > 0)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Deseas eliminar a este usuario?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialog == DialogResult.Yes)
                {
                    try
                    {
                        attributes.Id = dvgDatos.CurrentRow.Cells[0].Value.ToString() ;
                        alumnos.Eliminar(attributes);
                        getData();
                        MessageBox.Show("Se eliminó correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Se produjo el siguiente error: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CAlumnos cAlumnos = new CAlumnos();
            dvgDatos.DataSource = cAlumnos.Search(txtSearch.Text);
        }
    }
}
