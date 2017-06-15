using System;
using System.Collections.Generic;
using System.Text;
using SampleAPI.Persistence.Inventory.Models.Deal;
using SampleAPI.Persistence.Inventory.Models.Product;
using SampleAPI.Persistence.Inventory.Models.ProductDeal;

namespace SampleAPI.Persistence.Inventory
{
    public class InventorySeed
    {
        public static List<Product> GetProducts()
        {
            var list = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Coffee Mug",
                    Description = "Holds coffee.",
                    Price = 5.99m
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Coffee Maker",
                    Description = "Makes coffee.",
                    Price = 39.99m
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Silverware",
                    Description = "8 Spoons, 8 Forks, 4 Knives",
                    Price = 19.99m
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Dinnerware",
                    Description = "4 plates, 4 bowls",
                    Price = 24.99m
                },
                new Product
                {
                    ProductId = 5,
                    Name = "10-inch Frying Pan",
                    Description = "Non-stick surface",
                    Price = 21.99m
                }
            };

            return list;
        }

        public static List<ProductDeal> GetProductDeals()
        {
            var list = new List<ProductDeal>
            {
                new ProductDeal
                {
                    ProductDealId = 1,
                    ProductId = 5,
                    DealId = 1,
                    IsActive = true
                },
                new ProductDeal
                {
                    ProductDealId = 2,
                    ProductId = 4,
                    DealId = 2,
                    IsActive = false
                }
            };


            return list;
        }

        public static List<Deal> GetDeals()
        {
            var list = new List<Deal>
            {
                new Deal
                {
                    DealId = 1,
                    Name = "10 Percent Off",
                    PercentOff = 0.10m
                },
                new Deal
                {
                    DealId = 2,
                    Name = "25 Percent Off",
                    PercentOff = 0.25m
                }
            };


            return list;
        }
    }
}
