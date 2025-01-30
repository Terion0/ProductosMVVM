using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductosMVVM.Models.Dataclasses
{

    public class Categoria
    {
        private int id;
        private string nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        override public string ToString()
        {
            return  Nombre + "\n" +
                   " Id: " + Id;

        }
    }

}
