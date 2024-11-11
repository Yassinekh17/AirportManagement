﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string Function { get; set; }
        public DateTime EmploymentDate { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }
        public override void PassengerType()
        {
            Console.WriteLine("I am member");

        }
    }
}
