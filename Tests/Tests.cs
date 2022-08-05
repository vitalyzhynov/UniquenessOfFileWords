using NUnit.Framework;
using TestAppSimCorp;

namespace UniquessHelperTests
{
    [TestFixture]
    class Tests
    {
        private UniquenessHelper _uniquenessHelper;

        [SetUp]
        public void SetUp()
        {
            _uniquenessHelper = new UniquenessHelper();
        }

        [Test]
        public void IsUniquenessHelper_CalcSimple_IsCorrect()
        {
            var result = _uniquenessHelper.CalcOccurencesSafe("Go do that, thing that.! you do so well");

            Assert.AreEqual(result.Count, 7);
            Assert.AreEqual(result["go"], 1);
            Assert.AreEqual(result["do"], 2);
            Assert.AreEqual(result["that"], 2);
            Assert.AreEqual(result["thing"], 1);
            Assert.AreEqual(result["you"], 1);
            Assert.AreEqual(result["so"], 1);
            Assert.AreEqual(result["well"], 1);
        }

        [Test]
        public void IsUniquenessHelper_CalcNewLines_IsCorrect()
        {
            var result = _uniquenessHelper.CalcOccurencesSafe(@"Go do that,                     thing that.! you
                
do so well");

            Assert.AreEqual(result.Count, 7);
            Assert.AreEqual(result["go"], 1);
            Assert.AreEqual(result["do"], 2);
            Assert.AreEqual(result["that"], 2);
            Assert.AreEqual(result["thing"], 1);
            Assert.AreEqual(result["you"], 1);
            Assert.AreEqual(result["so"], 1);
            Assert.AreEqual(result["well"], 1);
        }

        [Test]
        public void IsUniquenessHelper_CalcRealText_IsCorrect()
        {
            var result = _uniquenessHelper.CalcOccurencesSafe(@"In this novel - a story of irreconcilable loves and infidelities - 
Milan Kundera addresses himself to the nature of twentieth-century 'Being' In a world in which lives are shaped by irrevocable
choices and by fortuitous events, a world in which everything occurs but once, existence seems to lose its substance, its 
weight. We feel, says the novelist, 'the unbearable lightness of being' - not only as the consequence of our private acts but
also in the public sphere, and the two inevitably intertwine.we");

            Assert.AreEqual(result.Count, 61);
        }

        [Test]
        public void IsUniquenessHelper_CalcUncorrectData_ReturnsEmptyCollection()
        {
            var result1 = _uniquenessHelper.CalcOccurencesSafe("");
            var result2 = _uniquenessHelper.CalcOccurencesSafe(null);
            var result3 = _uniquenessHelper.CalcOccurencesSafe(",.,.,.:;");

            Assert.AreEqual(result1.Count, 0);
            Assert.AreEqual(result2.Count, 0);
            Assert.AreEqual(result3.Count, 0);
        }
    }
}
