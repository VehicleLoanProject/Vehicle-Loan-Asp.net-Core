using System;
using System.Collections.Generic;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public decimal? ExshowroomPrice { get; set; }
        public decimal? OnroadPrice { get; set; }
        public int CustomerId { get; set; }

        public virtual ApplicantDetails Customer { get; set; }
    }
}
