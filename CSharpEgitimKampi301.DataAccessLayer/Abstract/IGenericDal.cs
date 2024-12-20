using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    // Genel veri tabanı işlemleri için kullanılacak interface
    public interface IGenericDal<T> where T : class
    {
        // Veri tabanına yeni bir kayıt ekleme
        void Insert(T entity);
        // Veri tabanında mevcut bir kaydı güncelleme
        void Update(T entity);
        // Veri tabanından bir kaydı silme
        void Delete(T entity);
        // Tüm kayıtları getirme
        List<T> GetAll();
        // Bir kaydı ID ile getirme
        T GetById(int id);
    }
}
