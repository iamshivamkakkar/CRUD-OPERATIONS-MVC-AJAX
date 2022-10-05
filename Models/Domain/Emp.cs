using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shivam.Models.Domain
{
    public class Emp
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpAddress { get; set; }
    }
}