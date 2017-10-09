using People.IoC;

namespace People.Services
{
    public class RequestsService : IRequests
    {
        int _success = 0;
        int _failure = 0;

        public int Failures => _failure;

        public int Successes => _success;
        
        public void AddFailure() => _failure++;
        
        public void AddSuccess() => _success++;
        
    }
}