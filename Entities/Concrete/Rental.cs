using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        [Key]
        public int RentalID { get; set; }
        public int CarId { get; set; }
        public string CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
/*
 *RentalID
CarId
CustomerId
RentDate
ReturnDate

 */