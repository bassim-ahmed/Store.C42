using Store.Core.Entities;
using Store.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.Data
{
    public class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreDbContext _context)
        {
            if (_context.Brands.Count() == 0)
            {
                //brands
                //1-Read Data From Jason File 
                var brandsData = File.ReadAllText(@"..\Store.Repository\Data\DataSeed\brands.json");
                //beacause default path is pl 

                //2- convert jason string to list<T>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                //3-Seed data to db
                if (brands is not null && brands.Count() > 0)
                {

                    await _context.Brands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();


                }

            }
            if (_context.Types.Count() == 0)
            {
                //brands
                //1-Read Data From Jason File 
                var typesData = File.ReadAllText(@"..\Store.Repository\Data\DataSeed\types.json");
                //beacause default path is pl 

                //2- convert jason string to list<T>
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                //3-Seed data to db
                if (types is not null && types.Count() > 0)
                {

                    await _context.Types.AddRangeAsync(types);
                    await _context.SaveChangesAsync();


                }

            }
            if (_context.Products.Count() == 0)
            {
                //brands
                //1-Read Data From Jason File 
                var productsData = File.ReadAllText(@"..\Store.Repository\Data\DataSeed\products.json");
                //beacause default path is pl 

                //2- convert jason string to list<T>
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                //3-Seed data to db
                if (products is not null && products.Count() > 0)
                {

                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();


                }

            }



        }
    }
}
