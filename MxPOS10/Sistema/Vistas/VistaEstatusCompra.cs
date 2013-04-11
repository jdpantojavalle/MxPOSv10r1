using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxPOS10.Sistema.Vistas
{
    public class VistaEstatusCompra
    {

        private int _IDEstatusCompra;

        public int IDEstatusCompra
        {
            get { return _IDEstatusCompra; }
            set { _IDEstatusCompra = value; }
        }

        //private bool _RegistroActivo;

        //public bool RegistroActivo
        //{
        //    get { return _RegistroActivo; }
        //    set { _RegistroActivo = value; }
        //}

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Leyenda;

        public string Leyenda
        {
            get { return _Leyenda; }
            set { _Leyenda = value; }
        }
    }
}