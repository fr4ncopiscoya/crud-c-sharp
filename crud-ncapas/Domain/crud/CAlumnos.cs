using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Entities;
using Common.Attributes;

namespace Domain.crud
{
    public class CAlumnos
    {
        Alumno alumno = new Alumno();

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable();
            dt = alumno.Mostrar();
            return dt;
        }

        public void Insertar(Attributes obj)
        {
            alumno.Insertar(obj);
        }

        public void Modificar(Attributes obj)
        {
            alumno.Modificar(obj);
        }

        public void Eliminar(Attributes obj)
        {
            alumno.Eliminar(obj);
        }

        public DataTable Search(String Search)
        {
            DataTable dt = new DataTable();
            dt = alumno.Search(Search);
            return dt;
        }
    }
}
