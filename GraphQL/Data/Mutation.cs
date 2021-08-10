using System.Threading.Tasks;
// using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using DemoDB;
using DemoDB.Entities;

namespace ConferencePlanner.GraphQL
{
    public class Mutation
    {
        // public async Task<AddSpeakerPayload> AddSpeakerAsync(
        //     AddSpeakerInput input,
        //     [Service] ApplicationDbContext context)
        // {
        //     var speaker = new Speaker
        //     {
        //         Name = input.Name,
        //         Bio = input.Bio,
        //         WebSite = input.WebSite
        //     };

        //     context.Speakers.Add(speaker);
        //     await context.SaveChangesAsync();

        //     return new AddSpeakerPayload(speaker);
        // }

        public async Task<AddCategoryPayload> AddCategoryAsync(
            AddCategoryInput input,
            [Service] IUnitOfWork uow)
        {
            var cat = new Category
            {
                CategoryName = input.CategoryName,
                Description = input.CategoryDescription
            };
            uow.GetRepositoryAsync<Category>().AddAsync(cat);
            uow.SaveChanges();
            // context.Categories.Add(cat);
            // await context.SaveChangesAsync();

            return new AddCategoryPayload(cat);
        }
    }
}