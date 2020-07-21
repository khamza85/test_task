using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using EntityFrameworkCore.AutoFixture.InMemory;

namespace Synel.Tests.Utils
{
    public class AutoDataWithMockAttribute : AutoDataAttribute
    {
        public AutoDataWithMockAttribute() : base(Configure)
        {
        }

        private static IFixture Configure()
        {
            var fixture = new Fixture();
            return fixture
                .Customize(new AutoMoqCustomization {ConfigureMembers = true})
                .Customize(new InMemoryContextCustomization());
        }
    }
}