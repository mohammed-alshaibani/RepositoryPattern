using g13lec6.Models;

namespace g13lec6.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly group13Context context;

        public GenericRepository(group13Context context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            try
            {
                var res = context.Add(entity); 
                var rowcount = context.SaveChanges();
                return res.Entity as T;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public T Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            var res = context.Set<T>().ToList();
            return res;
        }

        public T GetById(int id)
        {
            try
            {
                var res = context.Set<T>().Find(id);
                return res;
            }
            catch(Exception ex)
            {
                return default (T);
            }
        }

        public T Update(T entity)
        {
            try
            {
                var res = context.Update(entity);
                var rowcount = context.SaveChanges();
                return res.Entity as T;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
