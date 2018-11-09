using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }


        //Brauchen wir nur zum ausgeben normal überschreibt man toString nicht
        public override string ToString() =>
            $"Person(id:{Id}, FirstName:{FirstName}, LastName:{LastName}, DateOfBirth:{DateOfBirth:yyyy-MM-dd})";
    }
}
