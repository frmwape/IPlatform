using People.IoC;
using People.Models;
using RestSharp;
using System;
using System.Net;
using ToolBox.Integration.PCubed;

namespace People.Services
{
    public class PeopleLookupService : IPeopleLookup
    {
        /// <summary>
        /// Request service to be managed across application
        
        ///  GET api/PeopleLookup/{idnumber}
        /// </summary>
        /// <param name="id">ID Number</param>
        /// <returns>Returns a PersonFormModel</returns>
        public PersonFormModel GetPersonSearch(PersonFormModel person, IRequests _requests)
        {
            person.AdocFeedBack = "";
            try
            {
               
                var url = System.Configuration.ConfigurationManager.AppSettings["ConsumerViewApiUrl"];
                var consumerViewApiUsername = System.Configuration.ConfigurationManager.AppSettings["ConsumerViewApiUsername"];
                var consumerViewApiPassword = System.Configuration.ConfigurationManager.AppSettings["ConsumerViewApiPassword"];

                RestClient client = new RestClient(url);
                client.Authenticator = new HttpBasicAuthenticator(consumerViewApiUsername, consumerViewApiPassword);

                var service = new ConsumerViewService(client);
                var query = new ConsumerViewQuery(person.SearchIdNumber);

                var responce = service.Search(query);
                if (responce.StatusCode != HttpStatusCode.OK || responce.Data.ResponseStatusCode == HttpStatusCode.NotFound)
                {
                    _requests.AddFailure();
                    if (responce.StatusCode != HttpStatusCode.OK)
                        person.AdocFeedBack = "An Internal server error occured, please try again later! ";
                    else
                        person.AdocFeedBack = "Person with id " + person.SearchIdNumber + " Not Found";
                    return person;
                }

                var personFound = responce.Data.IndividualData.Individuals.Individual[0].PCubed;

                person.IDNumber = personFound.Header.IDNumber;
                person.FirstName = personFound.Header.FirstName;
                person.Surname = personFound.Header.Surname;
                person.AddressLine1 = personFound.Detail.AddressLine1;
                person.AddressLine2 = personFound.Detail.AddressLine2;
                person.AddressPostCode = personFound.Detail.AddressPostCode;
                person.AddressProvince = personFound.Detail.AddressProvince;
                person.AddressSuburb = personFound.Detail.AddressSuburb;
                person.AddressTownCity = personFound.Detail.AddressTownCity;
                             
                _requests.AddSuccess();
                return person;

            }
            catch (Exception e)
            {
                
                _requests.AddFailure();
                person.AdocFeedBack = "External issue occured while searching for person id: " + person.SearchIdNumber + ". Error: " + e.Message;
                return person;

            }
            
        }
    }
}