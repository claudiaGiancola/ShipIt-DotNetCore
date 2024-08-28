using System;

namespace ShipIt.Models.ApiModels
{
    public class OutboundOrderResponse : Response
    {
        private int _trucksQuantity { get; set; }
        public static void getNumberOfTrucks(float totalWeight)
        {
            double trucksNum = Convert.ToDouble(totalWeight / 2000);
            OutboundOrderResponse._trucksQuantity = Convert.ToInt32(Math.Ceiling(trucksNum));
        }

    }
}