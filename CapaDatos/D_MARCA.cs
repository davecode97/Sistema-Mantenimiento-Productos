using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;

namespace CapaDatos
{
    public class D_MARCA
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        #region SP_BUSCARMARCA
        public List<E_MARCA> listarMarca(string BUSCAR)
        {
            SqlDataReader leerFilas;

            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", BUSCAR);
            leerFilas = cmd.ExecuteReader();


            // REGISTROS DE LOS ATRIUTOS DE E_MARCA
            List<E_MARCA>Listar = new List<E_MARCA>();

            while (leerFilas.Read())
            {
                Listar.Add(new E_MARCA{
                    IdMarca = leerFilas.GetInt32(0),
                    CodigoMarca = leerFilas.GetString(1),
                    NombreMarca = leerFilas.GetString(2),
                    DescripcionMarca = leerFilas.GetString(3)
                });
            }

            conexion.Close();
            leerFilas.Close();

            return Listar;
        }
        #endregion

        #region SP_INSERTARMARCA
        public void InsertarMarca(E_MARCA marca)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARMARCA",conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", marca.DescripcionMarca);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        #endregion

        #region SP_EDITARMARCA
        public void EditarMarca(E_MARCA Marca) 
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@IDMARCA",Marca.IdMarca);
            cmd.Parameters.AddWithValue("@NOMBRE", Marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.DescripcionMarca);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        #endregion

        #region SP_ELIMINARMARCA
        public void EliminarMarca(E_MARCA Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@IDMARCA", Marca.IdMarca);
            cmd.ExecuteNonQuery();

            conexion.Close();
        }
        #endregion

    }
}
