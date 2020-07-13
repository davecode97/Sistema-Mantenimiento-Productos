using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_MARCA
    {
        private int _IdMarca;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;

        public int IdMarca
        {
            get { return _IdMarca; }
            set { _IdMarca = value; }
        }

        public string CodigoMarca
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string NombreMarca
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string DescripcionMarca
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

    }
}
