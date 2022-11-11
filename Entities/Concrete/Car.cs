using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int ID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string CarName { get; set; }
        public  int ModelYear { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get;set; }
       
    }
}
