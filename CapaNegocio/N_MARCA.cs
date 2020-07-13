using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaEntidades;


namespace CapaNegocio
{
    public class N_MARCA
    {
        D_MARCA objMarca = new D_MARCA();

        #region LISTANDO MARCA
        public List<E_MARCA>ListandoMarca(string BUSCAR)
        {
            return objMarca.listarMarca(BUSCAR);
        }
        #endregion

        #region INSERTANDO MARCA
        public void Insertando(E_MARCA Marca)
        {
            objMarca.InsertarMarca(Marca);
        }
        #endregion

        #region EDITANDO MARCA
        public void Editando(E_MARCA Marca)
        {
            objMarca.EditarMarca(Marca);
        }
        #endregion

        #region ELIMINANDO MARCA
        public void Eliminando(E_MARCA Marca)
        {
            objMarca.EliminarMarca(Marca);
        }
        #endregion
    }
}
