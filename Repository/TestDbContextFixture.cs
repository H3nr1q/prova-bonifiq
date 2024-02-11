using Microsoft.EntityFrameworkCore;

namespace ProvaPub.Repository
{
    public class TestDbContextFixture
    {
        public TestDbContext TestDbContext { get; set; }
        public TestDbContextFixture() {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase", builder => builder.EnableNullChecks(false))
                .Options;

            TestDbContext = new TestDbContext(options);
        }
    }
}
