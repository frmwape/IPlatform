using People.Models;

namespace People.IoC
{
    public interface IPeopleLookup 
    {
        PersonFormModel GetPersonSearch(PersonFormModel person, IRequests _requests);
    }
}
