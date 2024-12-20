using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    // Admin veri tabanı işlemleri için kullanılacak interface
    public interface IAdminDal : IGenericDal<Admin>
    {
    }
}
