using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeverBadWeather.DomainModel.Exception;

namespace NeverBadWeather.DomainModel
{
    public class PlaceList
    {
        private static PlaceList _instance;
        private Place[] _places;
        public static PlaceList Instance => _instance ??= new PlaceList();

        public bool IsLoaded { get; private set; }

        private PlaceList()
        {
        }

        public void Load(IEnumerable<Place> places)
        {
            _places = places.ToArray();
            IsLoaded = true;
        }

        public Place GetClosestPlace(Location location)
        {
            if (!IsLoaded) throw new PlaceListNotLoadedException();
            var deltaValue = 1;
            var min = location.CreateWithDelta(-deltaValue, -deltaValue);
            var max = location.CreateWithDelta(deltaValue, deltaValue);
            var minDistance = double.MaxValue;
            Place bestPlace = null;
            foreach (var place in _places)
            {
                if (!place.Location.IsWithin(min, max)) continue;
                var distance = place.Location.GetDistanceFrom(location);
                if (distance > minDistance) continue;
                minDistance = distance;
                bestPlace = place;
            }
            return bestPlace;
        }

    }
}
