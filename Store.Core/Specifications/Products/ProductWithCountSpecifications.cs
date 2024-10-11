using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications.Products
{
    public class ProductWithCountSpecifications:BaseSpecifications<Product,int>
    {
        public ProductWithCountSpecifications(ProductSpecParams productSpec) : base(

          p => (!productSpec.BrandId.HasValue || productSpec.BrandId == p.BrandId) && (!productSpec.TypeId.HasValue || productSpec.TypeId == p.TypeId))
        {
            //name price asc or pricedesc
           
        }



    }
}
