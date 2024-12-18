using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharoEgitimKampi301.DataAccessLayer.Abstract
{
    // Product veri tabanı işlemleri için kullanılacak interface
    public interface IProductDal:IGenericDal<Product>
    {
    }
}
