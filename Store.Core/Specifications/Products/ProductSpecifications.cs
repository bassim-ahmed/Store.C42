using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications.Products
{
    public class ProductSpecifications:BaseSpecifications<Product,int>
    {
        public ProductSpecifications(int id):base(P => P.Id == id)
        {
            ApplyIncludes();

        }

        //100
        public ProductSpecifications(ProductSpecParams productSpec) : base(

            p => ( !productSpec.BrandId.HasValue || productSpec.BrandId == p.BrandId) && (!productSpec.TypeId.HasValue || productSpec.TypeId == p.TypeId))
        {
            //name price asc or pricedesc
            if (!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch (productSpec.Sort) {
                
                    case "priceAsc":
                       AddOrderBy(p=>p.Price); break;
                    case "priceDes":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }

            }
            else {
                AddOrderBy(p => p.Name);

            }

            ApplyIncludes();
            ApplyPagination(productSpec.PageSize * (productSpec.PageIndex-1),productSpec.PageSize);

        }

        private void ApplyIncludes()
        {
            Includes.Add(P=>P.Brand);
            Includes.Add(P=>P.Type);
        }
    }

}
