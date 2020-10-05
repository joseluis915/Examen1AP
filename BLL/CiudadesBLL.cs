using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Examen1AP.DAL;
using Examen1AP.Entidades;

namespace Examen1AP.BLL
{
    public class CiudadesBLL
    {
        //EXISTE
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Ciudades.Any(d => d.CiudadId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        //INSERTAR
        private static bool Insertar(Ciudades ciudades)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Ciudades.Add(ciudades);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //MODIFICAR
        public static bool Modificar(Ciudades ciudades)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(ciudades).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //GUARDAR
        public static bool Guardar(Ciudades ciudades)
        {
            if (!Existe(ciudades.CiudadId))
                return Insertar(ciudades);
            else
                return Modificar(ciudades);
        }

        //ELIMINAR
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var ciudades = contexto.Ciudades.Find(id);
                if (ciudades != null)
                {
                    contexto.Ciudades.Remove(ciudades);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //BUSCAR
        public static Ciudades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ciudades ciudades;
            try
            {
                ciudades = contexto.Ciudades.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ciudades;
        }
        //GETLIST
        public static List<Ciudades> GetList(Expression<Func<Ciudades, bool>> criterio)
        {
            List<Ciudades> lista = new List<Ciudades>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ciudades.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}