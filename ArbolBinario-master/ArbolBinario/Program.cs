using System;
using ArbolBinario;

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario2 arbolBinario = new ArbolBinario2();

        arbolBinario.PoblarArbol(arbolBinario.NodoRaiz);

        Console.WriteLine("Recorrido preorden antes de eliminar nodo:");
        arbolBinario.RecorridoPreordenIterativo(arbolBinario.NodoRaiz);

        Console.WriteLine("Ingrese el valor del nodo que desea eliminar:");
        object valorAEliminar = Console.ReadLine();

        arbolBinario.EliminarNodo(valorAEliminar);

        Console.WriteLine("Recorrido preorden después de eliminar nodo:");
        arbolBinario.RecorridoPreordenIterativo(arbolBinario.NodoRaiz);

        Console.ReadKey();
    }
}
