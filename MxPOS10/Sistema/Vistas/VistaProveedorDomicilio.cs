
/*
 * MxPOS 1.0
 * 
 * Elemento: VistaProveedorDomicilio
 * Tipo: Clase
 * Descripción: Representa todas las propiedades de un domicilio de proveedor
 * Desarrollado por: Juan David Pantoja Valle
 *
 * Revisión: N/A
 * Revisado por: N/A
 * 
 * Notas: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxPOS10.Sistema.Vistas
{
    public class VistaProveedorDomicilio
    {
        private int _IDDomicilio;

        public int IDDomicilio
        {
            get { return _IDDomicilio; }
            set { _IDDomicilio = value; }
        }

        private int _IDReceptor;

        public int IDReceptor
        {
            get { return _IDReceptor; }
            set { _IDReceptor = value; }
        }

        private string _Calle;

        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }

        private string _NoExterior;

        public string NoExterior
        {
            get { return _NoExterior; }
            set { _NoExterior = value; }
        }

        private string _NoInterior;

        public string NoInterior
        {
            get { return _NoInterior; }
            set { _NoInterior = value; }
        }

        private string _Colonia;

        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }

        private string _Localidad;

        public string Localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }

        private string _Referencia;

        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        private string _Municipio;

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Pais;

        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
        }

        private string _CodigoPostal;

        public string CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }
    }
}