using Domain.Models;

namespace Infrastructure.Db
{
    public class Context
    {
        public async Task<Organization> GetOrganization(int id)
        {
             return Organizations.FirstOrDefault(org => org.Id == id);
        }

        private static List<Organization> Organizations =
            new List<Organization>()
            {
                new Organization()
                {
                    Id = 1,
                    Name = "Test1",
                },
                new Organization()
                {
                    Id = 2,
                    Name = "Test2",
                },
                new Organization()
                {
                    Id = 3,
                    Name = "Test3",
                },
                new Organization()
                {
                    Id = 4,
                    Name = "Test4",
                },
                new Organization()
                {
                    Id = 5,
                    Name = "Test5",
                }
            };
    }
}
