using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Models
{
    public class IdentityDocumentsModel
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long identityId { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string imagepath { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime InsertedOn { get; set; }

        public int? CustomerId { get; set; }
        public virtual ApplicantDetailsModel Customer { get; set; }


    }
}

