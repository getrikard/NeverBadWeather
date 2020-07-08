using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    public class LocationTest
    {
        [Test]
        public void Test1()
        {
            // arrange
            var corner1 = new Location(0, 0);
            var corner2 = new Location(1, 1);
            var location = new Location(0.5f, 0.5f);

            // act
            var isWithin = location.IsWithin(corner1, corner2);

            // assert
            Assert.IsTrue(isWithin);
        }
    }
}