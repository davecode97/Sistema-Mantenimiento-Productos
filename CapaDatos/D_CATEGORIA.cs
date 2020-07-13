using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_CATEGORIA
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        #region SP_BUSCARCATEGORIA
        public List<E_CATEGORIA>ListarCategoria(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            // REGISTROS DE LOS ATRIBUTOS CATEGORIA
            List<E_CATEGORIA> Listar = new List<E_CATEGORIA>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_CATEGORIA
                {
                    IdCategoria = LeerFilas.GetInt32(0),
                    CodigoCategoria = LeerFilas.GetString(1),
                    NombreCategoria  = LeerFilas.GetString(2),
                    DescripcionCategoria = LeerFilas.GetString(3)
                });
            }

            conexion.Close();
            LeerFilas.Close();

            return Listar;
        }
        #endregion

        #region SP_INSERTARCATEGORIA
        public void InsertarCategoria(E_CATEGORIA Categoria)
        {

            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA",conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
                                                    // Objeto de comunicacion
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.DescripcionCategoria);
            
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        #endregion

        #region SP_EDITARCATEGORIA
        public void EditarCategoria(E_CATEGORIA Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.DescripcionCategoria);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        #endregion

        #region SP_ELIMINARCATEGORIA
        public void EliminarCategoria(E_CATEGORIA Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IdCategoria);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        #endregion
    }
}
