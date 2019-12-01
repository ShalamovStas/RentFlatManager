using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Models
{
    public class Renter
    {
        public Guid Guid{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public List<string> PersonalData{ get; set; }
        public List<string> Phones{ get; set; }
        public List<string> Photos{ get; set; }
    }

    public class Flat
    {
        public Guid Guid { get; set; }
        public string Adress { get; set; }
        public string Location { get; set; }
        public List<string> Photos { get; set; }
        public List<string> AdditionalInfo{ get; set; }
    }

    public class RentFlat
    {
        public Guid RenterGuid{ get; set; }
        public Guid FlatGuid{ get; set; }
        public List<string> Docs{ get; set; }
        public List<string> AdditionalInfo{ get; set; }
    }

    public class AppConfig
    {
        public List<string> FlatOrder { get; set; }
        public List<string> RenersOrder { get; set; }
        public List<string> RentFlatOrder { get; set; }
    }
}
