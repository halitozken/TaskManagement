using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class TaskConfig : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasData(
                new TaskModel
                {
                    Id = 1,
                    Title = "header",
                    Description = "header logo and menu",
                    StartDateTime = new DateTime(1997, 10, 09),
                    EndDateTime = new DateTime(1999, 07, 27),
                    Owner = "Halit Özken",
                    Role = "Chief Technology Officer",
                    Mentions = "Melike Demir",
                    Status = "Open",
                    Workspace = "Web Development"
                }
            );


        }
    }
}