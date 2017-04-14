using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public class User
    {
        [Key]
        private int UserId { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Telephone { get; set; }
        private string RegistrationData { get; set; }
        private List<Advertisement> AdList { get; set; }

        public User(string firstName, string lastName, string telephone, string registrationData)
        {
            //UserId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Telephone = telephone;
            RegistrationData = registrationData;
            AdList = null;
        }
    }
}
