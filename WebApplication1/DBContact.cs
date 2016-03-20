using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DBContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string IdTelephone { get; set; }
        public string Address { get; set; }
    }

    public class DBTelephones
    {
        public int Id { get; set; }
        public string Telephone_Number { get; set; }
    }
}