using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria_Logica_Negocio;

namespace AppVista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsul_Click(object sender, EventArgs e)
        {
            ConsultarP();
        }
        private void ConsultarP()
        {
            try {
                string Id =txtId.Text;
                LogicaNegocio nn = new LogicaNegocio();
                nn.Identificacion1 = Id;
                if (!nn.ConsultarP())
                {
                    MessageBox.Show(nn.Error1);
                    nn = null;
                    return;
                }
                    if (nn.ObjReader.HasRows)
                    {
                        nn.ObjReader.Read();
                        txtName.Text = nn.ObjReader.GetString(1);
                        txtApell.Text = nn.ObjReader.GetString(2);
                        txtEdad.Text = nn.ObjReader.GetInt32(3).ToString();

                        nn.ObjReader.Close();
                    }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert();
        }
        private void Insert()
        {
            try {
                LogicaNegocio nn = new LogicaNegocio();
                string Id = txtId.Text;
                string Name = txtName.Text;
                string Apell = txtApell.Text;
                int Edad = Convert.ToInt32(txtEdad.Text);
                nn.Identificacion1 = Id;
                nn.Nombre1 = Name;
                nn.Apellido1 = Apell;
                nn.Edad1 = Edad;
                if (!nn.Registrar())
                {
                    MessageBox.Show(nn.Error1);
                    nn = null;
                    return;
                }
                MessageBox.Show("Se ha Registrado correctamente");
                nn = null;
                return;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            try
            {
                LogicaNegocio nn = new LogicaNegocio();
                string Id = txtId.Text;
                string Name = txtName.Text;
                string Apell = txtApell.Text;
                int Edad = Convert.ToInt32(txtEdad.Text);
                nn.Identificacion1 = Id;
                nn.Nombre1 = Name;
                nn.Apellido1 = Apell;
                nn.Edad1 = Edad;
                if (!nn.Actualizar())
                {
                    MessageBox.Show(nn.Error1);
                    nn = null;
                    return;
                }
                MessageBox.Show("Se ha Actualizado correctamente");
                nn = null;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void Eliminar()
        {
            try
            {
                string Id = txtId.Text;
                LogicaNegocio nn = new LogicaNegocio();
                nn.Identificacion1 = Id;
                if (!nn.Eliminar())
                {
                    MessageBox.Show(nn.Error1);
                    nn = null;
                    return;
                }
                MessageBox.Show("Se ha eliminado correctamente");
                nn = null;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        private bool LlenarGrid()
        {
            LogicaNegocio nr = new LogicaNegocio();
            if (!nr.Listar(VistaGrid))
            {
                MessageBox.Show(nr.Error1);
                nr = null;
                return false;
            }
            nr = null;
            return true;
        }
    }
}
