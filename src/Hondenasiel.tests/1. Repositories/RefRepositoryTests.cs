using NUnit.Framework;

namespace Hondenasiel.tests
{
    public class RefRepositoryTests : BaseRepositoryTest
    {
        [OneTimeSetUp]
        public void InitiallSetup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void FinalTearDown() 
        {
        
        }
    }
}