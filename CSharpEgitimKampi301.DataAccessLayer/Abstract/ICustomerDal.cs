using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    // Customer veri tabanı işlemleri için kullanılacak interface
    public interface ICustomerDal : IGenericDal<Customer>
    {
    }
}
