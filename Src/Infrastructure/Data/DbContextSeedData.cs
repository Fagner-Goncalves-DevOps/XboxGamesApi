using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Infrastructure.Data
{
    public class DbContextSeedData
    {
        public static async Task SeedAsync(SqlDbContext context, ILoggerFactory loggerFactory) 
        {
            try
            {
                if (!context.ProdutoGenero.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/genero.json");

                    var brands = JsonSerializer.Deserialize<List<ProdutoGenero>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProdutoGenero.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.ProdutoTipo.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/tipos.json");

                    var types = JsonSerializer.Deserialize<List<ProdutoTipo>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProdutoTipo.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.Produto.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/produtos.json");

                    var products = JsonSerializer.Deserialize<List<Produto>>(productsData);

                    foreach (var item in products)
                    {
                        context.Produto.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                //if (!context.DeliveryMethods.Any())
                //{
                //    var deliveryData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");

                //    var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);

                //    foreach (var item in DeliveryMethods)
                //    {
                //        context.DeliveryMethods.Add(item);
                //    }

                //    await context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DbContextSeedData>();
                logger.LogError(ex.Message);
            }

        }


    }
}
