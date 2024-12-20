using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        // Veritabanı bağlamı oluşturma
        CampContext context = new CampContext();

        // Generic DbSet tanımlama
        private readonly DbSet<T> _object;

        // Constructor - DbSet'i başlatma
        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        // Silme işlemi
        public void Delete(T entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        // Tüm verileri alma
        public List<T> GetAll()
        {
            return _object.ToList();
        }

        // Belirli bir veriyi ID ile alma
        public T GetById(int id)
        {
            return _object.Find(id);
        }

        // Ekleme işlemi
        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        // Güncelleme işlemi
        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

}
