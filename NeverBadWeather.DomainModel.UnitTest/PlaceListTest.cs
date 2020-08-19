using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    class PlaceListTest
    {
        [Test]
        public void TestGetClosestPlace()
        {
            // arrange
            var placeList = PlaceList.Instance;
            var places = new[]
            {
                new Place("", "", "Larvik", "", new Location(1, 2)),
                new Place("", "", "Sandefjord", "", new Location(2, 3)),
            };
            placeList.Load(places);
            var location1 = new Location(1.1f, 1.2f);
            var location2 = new Location(3, 2);

            // act
            var closestPlace1 = placeList.GetClosestPlace(location1);
            var closestPlace2 = placeList.GetClosestPlace(location2);

            // assert
            Assert.AreEqual("Larvik", closestPlace1.City);
            Assert.AreEqual("Sandefjord", closestPlace2.City);
        }
    }
}
