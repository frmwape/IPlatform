using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace People.Models
{
    public class PersonFormModel
    {
        [DisplayName("First name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public string Surname { get; set; }

        [DisplayName("Address line 1")]        
        public string AddressLine1 { get; set; }

        [DisplayName("Address line 2")]        
        public string AddressLine2 { get; set; }

        [DisplayName("Suburb")]        

        public string AddressSuburb { get; set; }

        [DisplayName("Town/City")]       
        public string AddressTownCity { get; set; }

        [DisplayName("Province")]
        public string AddressProvince { get; set; }
        
        [DisplayName("Postcode")]
        public string AddressPostCode { get; set; }

        [DisplayName("ID Number")]
        [Required]
        [MaxLength(13)]
        [MinLength(13)]               
        public string IDNumber { get; set; }

        [DisplayName("ID Number")]
        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string SearchIdNumber { get; set; }

        public string AdocFeedBack { get; set; }

    }
}