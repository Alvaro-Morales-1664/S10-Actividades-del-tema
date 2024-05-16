using System;
using System.Collections;
using System.Collections.Generic;

namespace ArbolBinario
{
    internal class ArbolBinario2
    {
        public NodoArbol? NodoRaiz { get; set; }
        private string respuesta;

        public ArbolBinario2()
        {
            NodoRaiz = null;
        }

        bool ArbolVacio() => NodoRaiz == null;

        NodoArbol CrearNodo()
        {
            NodoArbol nuevoNodo = new NodoArbol();

            if (ArbolVacio())
            {
                Console.WriteLine("Ingrese el dato para el nodo raíz: ");
                nuevoNodo.Informacion = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ingrese el dato para el nodo: ");
                nuevoNodo.Informacion = Console.ReadLine();
            }

            return nuevoNodo;
        }

        public void PoblarArbol(NodoArbol nodo)
        {
            if (ArbolVacio())
            {
                nodo = CrearNodo();
                NodoRaiz = nodo;
            }

            Console.WriteLine($"Existe nodo por la izq. de {nodo.Informacion}");
            respuesta = Console.ReadLine().ToString().Trim().ToLower();

            if (respuesta.Equals("s"))
            {
                NodoArbol nuevoNodo = new NodoArbol();
                nuevoNodo = CrearNodo();

                nodo.RamaIzquierda = nuevoNodo;

                PoblarArbol(nodo.RamaIzquierda);
            }

            Console.WriteLine($"Existe nodo por la der. de {nodo.Informacion}");
            respuesta = Console.ReadLine().ToString().Trim().ToLower();

            if (respuesta.Equals("s"))
            {
                NodoArbol nuevoNodo = new NodoArbol();
                nuevoNodo = CrearNodo();

                nodo.RamaDerecha = nuevoNodo;

                PoblarArbol(nodo.RamaDerecha);
            }
        }

        public void EliminarNodo(object valor)
        {
            NodoRaiz = Eliminar(NodoRaiz, valor);
        }

        private NodoArbol Eliminar(NodoArbol nodo, object valor)
        {
            if (nodo == null)
                return nodo;

            if (Comparer.Default.Compare(valor, nodo.Informacion) < 0)
                nodo.RamaIzquierda = Eliminar(nodo.RamaIzquierda, valor);
            else if (Comparer.Default.Compare(valor, nodo.Informacion) > 0)
                nodo.RamaDerecha = Eliminar(nodo.RamaDerecha, valor);
            else
            {
                if (nodo.RamaIzquierda == null)
                    return nodo.RamaDerecha;
                else if (nodo.RamaDerecha == null)
                    return nodo.RamaIzquierda;

                nodo.Informacion = MinValor(nodo.RamaDerecha);

                nodo.RamaDerecha = Eliminar(nodo.RamaDerecha, nodo.Informacion);
            }

            return nodo;
        }

        private object MinValor(NodoArbol nodo)
        {
            object minValor = nodo.Informacion;

            while (nodo.RamaIzquierda != null)
            {
                minValor = nodo.RamaIzquierda.Informacion;
                nodo = nodo.RamaIzquierda;
            }

            return minValor;
        }

        public void RecorridoPreordenIterativo(NodoArbol nodo)
        {
            if (nodo == null) return;

            Stack<NodoArbol> pila = new Stack<NodoArbol>();
            pila.Push(nodo);

            while (pila.Count > 0)
            {
                NodoArbol actual = pila.Pop();
                Console.WriteLine($"{actual.Informacion} > ");

                if (actual.RamaDerecha != null) pila.Push(actual.RamaDerecha);
                if (actual.RamaIzquierda != null) pila.Push(actual.RamaIzquierda);
            }
        }

        public void RecorridoInordenIterativo(NodoArbol nodo)
        {
            if (nodo == null) return;

            Stack<NodoArbol> pila = new Stack<NodoArbol>();
            NodoArbol actual = nodo;

            while (actual != null || pila.Count > 0)
            {
                while (actual != null)
                {
                    pila.Push(actual);
                    actual = actual.RamaIzquierda;
                }

                actual = pila.Pop();
                Console.WriteLine($"{actual.Informacion} > ");
                actual = actual.RamaDerecha;
            }
        }

        public void RecorridoPostordenIterativo(NodoArbol nodo)
        {
            if (nodo == null) return;

            Stack<NodoArbol> pila1 = new Stack<NodoArbol>();
            Stack<NodoArbol> pila2 = new Stack<NodoArbol>();

            pila1.Push(nodo);

            while (pila1.Count > 0)
            {
                NodoArbol actual = pila1.Pop();
                pila2.Push(actual);

                if (actual.RamaIzquierda != null) pila1.Push(actual.RamaIzquierda);
                if (actual.RamaDerecha != null) pila1.Push(actual.RamaDerecha);
            }

            while (pila2.Count > 0)
            {
                NodoArbol actual = pila2.Pop();
                Console.WriteLine($"{actual.Informacion} > ");
            }
        }
    }
}