﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ControladorEspecialidad
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre ,DniEspecialidad from Especialidades");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.DniEspecialidad = (int)datos.Lector["DniEspecialidad"];
                    lista.Add(aux);


                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool EspecialidadExistente(string nombre)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Especialidades where Nombre = @Nombre");
            Ad.setearParametro("@Nombre", nombre);

            try
            {
                Ad.ejecutarLectura();
                if (Ad.Lector.Read())
                {
                    return (int)Ad.Lector[0] > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

            return false;
        }

        public void InsertarEspecialidad(Especialidad especialidad)
        {

            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Especialidades (Nombre , DniEspecialidad) values (@Nombre, @DniEspecialidad)");
            Ad.setearParametro("@Nombre", especialidad.Nombre);
            Ad.setearParametro("@DniEspecialidad", especialidad.DniEspecialidad);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }


        }


    }
}