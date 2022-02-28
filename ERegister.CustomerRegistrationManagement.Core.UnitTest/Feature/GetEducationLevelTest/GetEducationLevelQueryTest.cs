using ERegister.CustomerRegistrationManagement.Core.Domain.Entities;
using ERegister.CustomerRegistrationManagement.Core.Features.GetEductationLevel.Query;
using ERegister.CustomerRegistrationManagement.Core.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using Xunit;

namespace ERegister.CustomerRegistrationManagement.Core.UnitTest.Feature.GetEducationLevelTest
{
    public class GetEducationLevelQueryTest : BaseDbContext
    {
        public GetEducationLevelQueryTest()
        {
            _dbContext.EducationLevels.AddRange(ListEducationLevels());
            _dbContext.SaveChangesAsync(new CancellationToken());
            
        }

        public List<EducationLevel> ListEducationLevels()
        {
            return new List<EducationLevel>
            {
                new EducationLevel{ Id = 1 , Name = "High School" },
                new EducationLevel { Id = 2 , Name = "Secondary High School" },
                new EducationLevel { Id = 3, Name = "BE" }
            };
        }

        [Fact]
        public async Task GetEducationLevelHandler_Should_Return_List_of_GetEducationLevelDtos()
        {
            var handler = new GetEducationLevelQueryHandler(_dbContext,_mapper);

            var actualResult = await handler.Handle(new GetEducationLevelQuery(),It.IsAny<CancellationToken>());

            actualResult.Should().HaveCountGreaterThan(2);
            actualResult.Should().NotBeNull();

            
        }

        //[Fact]
        //public async Task GetEducationLevelHandler_Should_Return_Values()
        //{
        //    var data = new List<EducationLevel>
        //    {
        //        new EducationLevel { Id = 1,Name = "High School" },
        //        new EducationLevel { Id = 2,Name = "Secondary High School" },
        //        new EducationLevel { Id = 3,Name = "BE" }
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<EducationLevel>>();

        //    mockSet.As<IDbAsyncEnumerable<EducationLevel>>()
        //        .Setup(m => m.GetAsyncEnumerator())
        //        .Returns(new TestDbAsyncEnumerator<EducationLevel>(data.GetEnumerator()));

        //    mockSet.As<IQueryable<EducationLevel>>()
        //        .Setup(m => m.Provider)
        //        .Returns(new TestDbAsyncQueryProvider<EducationLevel>(data.Provider));

        //    mockSet.As<IQueryable<EducationLevel>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<EducationLevel>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<EducationLevel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    mockSet.As<IAsyncEnumerable<EducationLevel>>().Setup(x => x.GetEnumerator()).Returns(new TestAsyncEnumerator<T>(TestData.GetEnumerator()));
        //    mockSet.As<IQueryable<EducationLevel>>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<T>(TestData.Provider));
        //    mockSet.As<IQueryable<EducationLevel>>().Setup(x => x.Expression).Returns(TestData.Expression);
        //    mockSet.As<IQueryable<EducationLevel>>().Setup(x => x.ElementType).Returns(TestData.ElementType);
        //    mockSet.As<IQueryable<EducationLevel>>().Setup(x => x.GetEnumerator()).Returns(TestData.GetEnumerator());

        //    var mockDbContext = new Mock<IERegisterDbContext>();
        //    mockDbContext.Setup(x => x.EducationLevels).Returns(mockSet.Object);

        //    var result = await mockDbContext.Object.EducationLevels.ToListAsync();
        //}

        //// Return a DbSet of the specified generic type with support for async operations
        //public static Mock<DbSet<T>> GetDbSet<T>(IQueryable<T> TestData) where T : class
        //{
        //    var MockSet = new Mock<DbSet<T>>();
        //    MockSet.As<IAsyncEnumerable<T>>().Setup(x => x.GetAsyncEnumerator(It.IsAnyType<CancellationToken>()))
        //        .Returns(new TestAsyncEnumerator<T>(TestData.GetEnumerator()));
        //    MockSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<T>(TestData.Provider));
        //    MockSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(TestData.Expression);
        //    MockSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(TestData.ElementType);
        //    MockSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(TestData.GetEnumerator());
        //    return MockSet;
        //}


    }
}
