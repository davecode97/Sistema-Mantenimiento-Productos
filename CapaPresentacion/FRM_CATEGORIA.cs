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
    public partial class FRM_CATEGORIA : Form
    {
        E_CATEGORIA objEntidad = new E_CATEGORIA();
        N_CATEGORIA objNegocio = new N_CATEGORIA();

        private string IdCategoria;
        private bool Editarse = false;


        public FRM_CATEGORIA()
        {
            InitializeComponent();
        }

        #region CERRAR FORMULARIO
        private void cerrarFormulario_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region MINIMIZAR FORMULARIO
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region BUSQUEDA EN TIEMPO REAL
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }
        #endregion

        #region FORMLOAD
        private void FRM_CATEGORIA_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
        }
        #endregion

        #region ACOMODO DE COLUMNAS
        public void accionesTabla()
        {
            tablaCategoria.Columns[0].Visible = false;
            tablaCategoria.Columns[1].Width = 60;
            tablaCategoria.Columns[2].Width = 170;

            tablaCategoria.ClearSelection();
        }
        #endregion

        #region MOTRAR TABLA
        public void mostrarBuscarTabla(string buscar)
        { 
            tablaCategoria.DataSource = objNegocio.ListandoCategoria(buscar);
        }

        #endregion

        #region LIMPIAR CAJAS
        public void LimpiarCajas()
        {
            Editarse = false;

            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtNombre.Focus();
        }
        #endregion

        #region BTN NUEVO LIMPIAR
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }
        #endregion

        #region BTN EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editarse = true;
            if(tablaCategoria.SelectedRows.Count>0) 
            {
                IdCategoria = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
        #endregion

        #region BTN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                lbNombreCategoria.Visible = false;
                mostrarBuscarTabla("");

                if (txtDescripcion.Text == "")
                {
                    txtDescripcion.Text = "SIN DESCRIPCION";
                    mostrarBuscarTabla("");

                    // Guardar SIN DESCRIPCION
                    if (Editarse == false)
                    {
                        try
                        {
                            objEntidad.NombreCategoria = txtNombre.Text.ToUpper().Trim();
                            objEntidad.DescripcionCategoria = txtDescripcion.Text.ToUpper().Trim();

                            objNegocio.InsertandoCategoria(objEntidad);
                            mostrarBuscarTabla("");
                            LimpiarCajas();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("NO SE PUDO GUARDAR EL REGISTRO " + ex);
                        }
                    }
                    // Editar SIN DESCRIPCION
                    if (Editarse == true)
                    {
                        try
                        {
                            objEntidad.IdCategoria = Convert.ToInt32(IdCategoria);
                            objEntidad.NombreCategoria = txtNombre.Text.ToUpper();
                            objEntidad.DescripcionCategoria = txtDescripcion.Text.ToUpper();

                            objNegocio.EditandoCategoria(objEntidad);
                            MessageBox.Show("Se edito el registro");
                            mostrarBuscarTabla("");
                            LimpiarCajas();

                            Editarse = false;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("NO SE PUDO EDITAR EL REGISTRO " + ex);
                        }
                    }
                }
                else
                {
                    // Guardar CON DISCRIPCION
                    if (Editarse == false)
                    {
                        try
                        {
                            objEntidad.NombreCategoria = txtNombre.Text.ToUpper().Trim();
                            objEntidad.DescripcionCategoria = txtDescripcion.Text.ToUpper().Trim();

                            objNegocio.InsertandoCategoria(objEntidad);
                            mostrarBuscarTabla("");
                            LimpiarCajas();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("NO SE PUDO GUARDAR EL REGISTRO " + ex);
                        }
                    }
                    // Editar SIN DESCRIPCION
                    if (Editarse == true)
                    {
                        try
                        {
                            objEntidad.IdCategoria = Convert.ToInt32(IdCategoria);
                            objEntidad.NombreCategoria = txtNombre.Text.ToUpper();
                            objEntidad.DescripcionCategoria = txtDescripcion.Text.ToUpper();

                            objNegocio.EditandoCategoria(objEntidad);
                            MessageBox.Show("Se edito el registro");
                            mostrarBuscarTabla("");
                            LimpiarCajas();

                            Editarse = false;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("NO SE PUDO EDITAR EL REGISTRO " + ex);
                        }
                    }
                }
            }
            else
            {
                msgErrorNombre();
            }
           
        }
        #endregion

        #region ERROR NOMBRE
        private void msgErrorNombre()
        {
            lbNombreCategoria.Visible = true;
        }
        #endregion

        #region BTN ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count > 0)
            {
                objEntidad.IdCategoria = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se ha eliminado correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que deseas eliminar");
            }
        }
        #endregion

        #region PLACEHOLDER BUSCAR
        private void  txtBuscar_Enter(object sender, EventArgs e)
        {
            if(txtBuscar.Text == "Buscar...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
                mostrarBuscarTabla("");
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if(txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar...";
                txtBuscar.ForeColor = Color.Gray;
                mostrarBuscarTabla("");
            }
        }
        #endregion

        private void tablaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
