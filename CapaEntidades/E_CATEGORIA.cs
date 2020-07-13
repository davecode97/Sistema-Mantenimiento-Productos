using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_CATEGORIA
    {
        private int _IdCategoria;
        private string _CodigoCategoria;
        private string _NombreCategoria;
        private string _DescripcionCategoria;

       
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string CodigoCategoria { get => _CodigoCategoria; set => _CodigoCategoria = value; }
        public string NombreCategoria { get => _NombreCategoria; set => _NombreCategoria = value; }
        public string DescripcionCategoria { get => _DescripcionCategoria; set => _DescripcionCategoria = value; }
    }
}
