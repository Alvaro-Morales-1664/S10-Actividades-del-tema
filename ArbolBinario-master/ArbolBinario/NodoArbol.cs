using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    internal class NodoArbol
    {
        public NodoArbol? RamaIzquierda { get; set; }

        public object? Informacion { get; set; }

        public NodoArbol? RamaDerecha { get; set; }
        public NodoArbol()
        {
            RamaIzquierda = null;
            Informacion = null;
            RamaDerecha = null;
        }

        public NodoArbol(object? informacion)
        {
            RamaIzquierda = null;
            Informacion = informacion;
            RamaDerecha = null;
        }
    }
}
