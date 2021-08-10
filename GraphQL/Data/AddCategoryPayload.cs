// using ConferencePlanner.GraphQL.Data;
using DemoDB;
using DemoDB.Entities;

namespace ConferencePlanner.GraphQL
{
    public class AddCategoryPayload
    {
        public AddCategoryPayload(Category cat)
        {
            Category = cat;
        }

        public Category Category { get; }
    }
}