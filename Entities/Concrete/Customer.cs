using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
    }
}
/*
 CustomerID
CompanyName
 */