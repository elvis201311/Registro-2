using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Media.Animation;

namespace Registro.BLL
{
    public class EstudiantesBLL
    {

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(e => e.EstudianteId == id);
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

        private static bool Insertar(Estudiantes estudiante)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Estudiantes.Add(estudiante);
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        private static bool Modificar(Estudiantes estudiante)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Entry(estudiante).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        public static bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.EstudianteId))
            {
                return Insertar(estudiante);
            }
            else
            {
                return Modificar(estudiante);
            }
        }

        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                
                var estudiante = contexto.Estudiantes.Find(id);

                if (estudiante != null)
                {
                    contexto.Estudiantes.Remove(estudiante);
                    key = contexto.SaveChanges() > 0;
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

            return key;
        }

        public static Estudiantes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Estudiantes estudiante;

            try
            {
                estudiante = contexto.Estudiantes.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return estudiante;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Estudiantes.Where(criterio).ToList();
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
        //Elvis
    }
}