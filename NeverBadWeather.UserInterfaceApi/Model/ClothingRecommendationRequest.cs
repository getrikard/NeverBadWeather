using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeverBadWeather.DomainModel;

namespace NeverBadWeather.UserInterfaceApi.Model
{
    public class ClothingRecommendationRequest
    {
        public byte HourFrom { get; set; }
        public byte HourTo { get; set; }
        public float Latitude{ get; set; }
        public float Longitude { get; set; }

        public DomainModel.ClothingRecommendationRequest ToDomainModel()
        {
            var timeFrom = DateTime.Now;
            if (HourFrom < timeFrom.Hour) timeFrom = timeFrom.AddDays(1);
            timeFrom = timeFrom.AddHours(HourFrom - timeFrom.Hour);
            timeFrom = timeFrom.AddMinutes(-timeFrom.Minute);
            var timeTo = timeFrom.AddHours(HourTo - timeFrom.Hour);
            if (timeTo < timeFrom) timeTo = timeTo.AddDays(1);
            return new DomainModel.ClothingRecommendationRequest(
                new TimePeriod(timeFrom, timeTo), new Location(Latitude, Longitude) );
        }
    }
}
