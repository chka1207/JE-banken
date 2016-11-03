using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JE_Bank
{
    public class Provklass
    {
        public int userID { get; set; }
        public string xmldatabas { get; set; }
        public bool gjort_licens { get; set; }
        public DateTime licens { get; set; }
        public DateTime kunskap { get; set; }
        public bool godkänd_kunskap { get; set; }
    }
}