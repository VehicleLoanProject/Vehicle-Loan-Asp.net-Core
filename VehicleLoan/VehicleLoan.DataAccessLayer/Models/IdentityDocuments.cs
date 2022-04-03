using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLoan.DataAccessLayer.Models
{
    public class IdentityDocuments 
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long identityId { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string imagepath { get; set; }
        [Column(TypeName = "dateTime")]
        public DateTime InsertedOn { get; set; }

        public int? CustomerId { get; set; }
        public virtual ApplicantDetails Customer { get; set; }


    }
}
