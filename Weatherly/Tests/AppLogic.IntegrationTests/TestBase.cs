using System.Threading.Tasks;
using NUnit.Framework;

namespace Weatherly.AppLogic.IntegrationTests
{
    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            // dummy, must change in following commit
            await Task.Delay(500);
        }
    }
}
