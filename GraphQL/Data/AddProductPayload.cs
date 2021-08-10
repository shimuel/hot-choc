// using ConferencePlanner.GraphQL.Data;
using DemoDB;
using DemoDB.Entities;

namespace ConferencePlanner.GraphQL
{
    public class AddProductPayload
    {
        public AddProductPayload(Product prod)
        {
            Product = prod;
        }

        public Product Product { get; }
    }
}