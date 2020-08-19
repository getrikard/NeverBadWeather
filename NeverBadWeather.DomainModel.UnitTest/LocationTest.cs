using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    public class LocationTest
    {
        [Test]
        public void TestIsWithinInside()
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

        [Test]
        public void TestIsWithinOutside()
        {
            // arrange
            var corner1 = new Location(0, 0);
            var corner2 = new Location(1, 1);

            var location1 = new Location(4, 0.5f);
            var location2 = new Location(0.5f, 5);
            var location3 = new Location(3, 3);

            // act
            var isWithin1 = location1.IsWithin(corner1, corner2);
            var isWithin2 = location2.IsWithin(corner1, corner2);
            var isWithin3 = location3.IsWithin(corner1, corner2);

            // assert
            Assert.IsFalse(isWithin1);
            Assert.IsFalse(isWithin2);
            Assert.IsFalse(isWithin3);
        }

        [Test]
        public void TestDistanceFrom()
        {
            // arrange
            var corner1 = new Location(0, 0);
            var corner2 = new Location(0, 1);

            // act
            var distance = corner1.GetDistanceFrom(corner2);

            // assert
            Assert.AreEqual(1.0, distance);
        }
    }
}