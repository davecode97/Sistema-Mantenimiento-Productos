using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using System.Data.SqlClient;
using System.Configuration;
using CapaDatos;

namespace CapaNegocio
{
    public class N_CATEGORIA
    {
        D_CATEGORIA objDato = new D_CATEGORIA();

        #region BUSQUEDA
        public List<E_CATEGORIA>ListandoCategoria(string Buscar)
        {
            return objDato.ListarCategoria(Buscar);
        }
        #endregion

        #region INSERCION
        public void InsertandoCategoria(E_CATEGORIA Categoria)
        {
            objDato.InsertarCategoria(Categoria);
        }
        #endregion

        #region EDITAR
        public void EditandoCategoria(E_CATEGORIA Categoria)
        {
            objDato.EditarCategoria(Categoria);
        }
        #endregion

        #region Eliminar
        public void EliminandoCategoria(E_CATEGORIA Categoria)
        {
            objDato.EliminarCategoria(Categoria);
        }
        #endregion
    }
}
