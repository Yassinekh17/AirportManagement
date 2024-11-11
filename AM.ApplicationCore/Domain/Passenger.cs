using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        [StringLength(7)] //coté interface
        public string PassportNumber { get; set; }
        [MinLength(3, ErrorMessage ="MIN LENGTH IS 3")] //coté BDD
        [MaxLength(25, ErrorMessage="MAX LENGTH IS 25")]
        
        public FullName FullName { get; set; }
        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage ="Invalid phone number")]
        public int TelNumber {  get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }


        public override string? ToString()
        {
            return "FirstName: "+ FullName.FirstName+ " LastName: "+ FullName.LastName+ " BirthDate: "+BirthDate;
        }
        public bool checkProfile (string nom, string prenom)
        {
            return this.FullName.FirstName.Equals(prenom)&&this.FullName.LastName.Equals(nom);
        }
        public bool checkProfile(string nom, string prenom, string email)
        {
            return this.FullName.FirstName.Equals(prenom) && this.FullName.LastName.Equals(nom)&& this.EmailAdress.Equals(email);
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am Passenger");
        }
    }
}
