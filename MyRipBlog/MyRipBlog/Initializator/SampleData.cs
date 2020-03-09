using System.Linq;
using MyRipBlog.Models;

namespace MyRipBlog.Initializator
{
    public static class SampleData
    {
        public static void Initialize(MyRipBlogContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(
                new User
                {
                    Username = "Admin",
                    Email = "admin@example.com",
                    Password = "admin1234"
                });
                context.SaveChanges();
            }

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new Tag { Value = "Спорт" },
                    new Tag { Value = "Мода" },
                    new Tag { Value = "Красота" },
                    new Tag { Value = "Здоровье" },
                    new Tag { Value = "Природа" },
                    new Tag { Value = "Путешествия" },
                    new Tag { Value = "Культура" },
                    new Tag { Value = "Еда" },
                    new Tag { Value = "Хобби" },
                    new Tag { Value = "Авто" },
                    new Tag { Value = "Наука" },
                    new Tag { Value = "Техника" },
                    new Tag { Value = "Животные" },
                    new Tag { Value = "Музыка" },
                    new Tag { Value = "Уроки" }
                );
                context.SaveChanges();
            }
        }
    }
}
