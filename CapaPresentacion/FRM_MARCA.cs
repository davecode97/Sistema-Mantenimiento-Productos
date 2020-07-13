using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
 

namespace CapaPresentacion
{
    public partial class FRM_MARCA : Form
    {
        E_MARCA objEntidad = new E_MARCA();
        N_MARCA objNegocio = new N_MARCA();

        private bool Editarse = false;
        private string IdMarca;

        public FRM_MARCA()
        {
            InitializeComponent();
        }

        #region CERRAR FORMULARIO
        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region MINIMIZAR FORMULARIO
        private void picMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region MOSTRAR TABLA
        private void MostrarBuscarTabla(string BUSCAR)
        {
            tablaMarca.DataSource = objNegocio.ListandoMarca(BUSCAR);
        }
        #endregion

        #region FORM LOAD
        private void FRM_MARCA_Load(object sender, EventArgs e)
        {
            MostrarBuscarTabla("");
            AccionesTabla();
        }
        #endregion

        #region ACOMODO DE TABLA
        private void AccionesTabla()
        {
            tablaMarca.Columns[0].Visible= false;
            tablaMarca.Columns[1].Width = 60;
            tablaMarca.Columns[2].Width = 170;

            tablaMarca.ClearSelection();
        }
        #endregion

        #region PLACEHOLDER
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;

                MostrarBuscarTabla("");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar...";
                txtBuscar.ForeColor = Color.Gray;

                MostrarBuscarTabla("");
            }
        }
        #endregion

        #region BTN EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editarse = true;

            if (tablaMarca.SelectedRows.Count > 0)
            { 
                IdMarca = tablaMarca.CurrentRow.Cells[0].Value.ToString(); //  Variable AUX
                txtCodigo.Text = tablaMarca.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaMarca.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaMarca.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa.");
            }
        }

        #endregion

        #region BTN ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaMarca.SelectedRows.Count > 0)
            {
                objEntidad.IdMarca = Convert.ToInt32(tablaMarca.CurrentRow.Cells[0].Value.ToString());
                objNegocio.Eliminando(objEntidad);

                MessageBox.Show("Se ha eliminado correctamente.");
                MostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa.");
            }
        }
        #endregion

        #region BTN NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion

        #region LIMPIAR CAJAR
        private void Limpiar()
        {
            Editarse = false;

            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
        }
        #endregion

        #region BUSQUEDA EN TIPO REAL
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarBuscarTabla(txtBuscar.Text);
        }
        #endregion

        #region BTN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                lbNombreMarca.Visible = false;
                MostrarBuscarTabla("");

                if(txtDescripcion.Text == "")
                {
                    txtDescripcion.Text = "SIN DESCRIPCION";
                    MostrarBuscarTabla("");

                    // Guardar SIN DESCRIPCION
                    if(Editarse == false)
                    {
                        try
                        {
                            objEntidad.NombreMarca = txtNombre.Text.ToUpper().Trim();
                            objEntidad.DescripcionMarca = txtDescripcion.Text.ToUpper().Trim();

                            objNegocio.Insertando(objEntidad);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("No se guardardo." + ex);
                        }
                    }

                    // Editar SIN DESCRIPCION
                    if(Editarse == false)
                    {
                        try
                        {
                            objEntidad.IdMarca = Convert.ToInt32(IdMarca); // Variable Aux
                            objEntidad.NombreMarca = txtNombre.Text.ToUpper().Trim();
                            objEntidad.DescripcionMarca = txtDescripcion.Text.ToUpper().Trim();

                            objNegocio.Editando(objEntidad);
                            MessageBox.Show("Se edito el registro");
                            MostrarBuscarTabla("");
                            Limpiar();

                            Editarse = false;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("No se edito." + ex);
                        }
                    }

                }
                else
                {
                     // Guardar CON DESCRIPCION
                     if(Editarse == false)
                    {
                        try
                        {
                            objEntidad.NombreMarca = txtNombre.Text.ToUpper().Trim();
                            objEntidad.DescripcionMarca = txtDescripcion.Text.ToUpper().Trim();

                            objNegocio.Insertando(objEntidad);
                            MessageBox.Show("Se guardo correctamente.");
                            MostrarBuscarTabla("");
                            Limpiar();

                        }catch(Exception ex)
                        {
                            MessageBox.Show("No se guardo." + ex);
                        }
                    }

                     // Editando CON DESCRIPCION
                     if(Editarse == true)
                    {
                        try
                        {
                            objEntidad.IdMarca = Convert.ToInt32(IdMarca);
                            objEntidad.NombreMarca = txtNombre.Text.ToUpper().Trim();
                            objEntidad.DescripcionMarca = txtDescripcion.Text.ToUpper().Trim();

                            objNegocio.Editando(objEntidad);
                            MostrarBuscarTabla("");
                            MessageBox.Show("Se edito correctamente.");
                            Limpiar();

                        } catch(Exception ex)
                        {
                            MessageBox.Show("Se edito correctamente." + ex);
                        }
                    }
                }

            }
            else
            {
                ErrorNombre();
            }
        }
        #endregion

        #region ErrorNombre
        private void ErrorNombre()
        {
            lbNombreMarca.Visible = true;
        }
        #endregion
    }
}
