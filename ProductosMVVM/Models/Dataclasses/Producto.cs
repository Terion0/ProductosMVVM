using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Producto 
    {
        private int id;
        private string nombre;
        private string descripcion;
        private double precio;
        private int idCategoria;
        private string imagen;


        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get =>descripcion; set =>descripcion =value; }
        public double Precio { get =>precio; set =>precio = value; }
        public int IdCategoria { get =>idCategoria; set =>idCategoria=value; }
        public int IdProducto { get =>id; set => id=value; }
        public string Imagen { get=>imagen; set=>imagen=value; }


        override public string ToString()
        {
            return  Nombre;
                   

        }
    }

