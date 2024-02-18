using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DbFirst_practice2.Models
{
    public partial class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; } = null!;
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        

        //[JsonIgnore]
        //public virtual Department DeptNoNavigation { get; set; } = null!;
    }
}
