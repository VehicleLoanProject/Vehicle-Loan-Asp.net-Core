using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public decimal? ExshowroomPrice { get; set; }
        public decimal? OnroadPrice { get; set; }
        public int? CustomerId { get; set; }

        
    }
}
