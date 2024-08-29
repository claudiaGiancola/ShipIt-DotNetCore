using System;

namespace ShipIt.Models.ApiModels
{
    public class OutboundOrderResponse : Response
    {
        public int TrucksQuantity { get; set; }
        public OutboundOrderResponse(float totalWeight)
        {
            double trucksNum = Convert.ToDouble(totalWeight / 2000);
            TrucksQuantity = Convert.ToInt32(Math.Ceiling(trucksNum));
        }
        // public void SetTrucksQuantity(float totalWeight)
        // {
        //     double trucksNum = Convert.ToDouble(totalWeight / 2000);
        //     TrucksQuantity = Convert.ToInt32(Math.Ceiling(trucksNum));
        // }
    }

}
