﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Especialidad(int id, string nombre, string descripcion)
        {

            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Especialidad() { }


        public override string ToString()
        {
            return Descripcion;

        }

    }
}
