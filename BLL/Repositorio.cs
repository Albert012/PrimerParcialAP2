using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Repositorio<T>: IRepository<T> where T : class
    {
        public bool Guardar(T entity)
        {
            bool paso = false;

            return paso;
        }

        public bool Modificar(T entity)
        {
            bool paso = false;

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;

            return paso;
        }

        public T Buscar(int id)
        {
            T entity = null;

            return entity;
        }

        public List<T> GetList(Expression<Func<T,bool>>expression)
        {
            List<T> list = null;

            return list;
        }




    }
}
