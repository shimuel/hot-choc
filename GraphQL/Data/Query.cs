using System.Linq;
using HotChocolate;
// using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore; //for include
using DemoDB;
using DemoDB.Entities;

namespace ConferencePlanner.GraphQL
{
    public class Query
    {
        // public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) =>
        //     context.Speakers;
        public System.Collections.Generic.IList<DemoDB.Entities.Category> GetCategories([Service] IUnitOfWork uow) {
            var cats = uow.GetRepositoryAsync<Category>().GetListAsync(
                //predicate: i=> i.CategoryId == 5,
                index: 2,
                size:3,
                include: q => q.Include(j => j.Products)).Result;
            
            return cats.Items;
        }

        public IQueryable<Product> GetCProducts([Service] NorthwindbContext context) =>
            context.Products;

    }
}