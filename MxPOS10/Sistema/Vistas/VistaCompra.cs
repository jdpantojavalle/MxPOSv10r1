using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxPOS10.Sistema.Vistas
{
    public class VistaCompra
    {
        private int _IDCompra;

        public int IDCompra
        {
            get { return _IDCompra; }
            set { _IDCompra = value; }
        }

        private int _IDProveedor;

        public int IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }

        private int _IDEStatusCompra;

        public int IDEStatusCompra
        {
            get { return _IDEStatusCompra; }
            set { _IDEStatusCompra = value; }
        }

        private string _Dumb;

        public string Dumb 
        {
            get { return _Dumb; }
            set { _Dumb = value; }
        }

        private string _Folio;

        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private string _Serie;

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private double _Subtotal;

        public double Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private double _Descuento;

        public double Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private string _MotivoDescuento;
        
        public string MotivoDescuento
        {
            get { return _MotivoDescuento; }
            set { _MotivoDescuento = value; }
        }

        private double _IVA;

        public double IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }
        private double _Total;

        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
    }
}