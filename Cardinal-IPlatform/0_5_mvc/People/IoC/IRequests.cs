namespace People.IoC
{
    public interface IRequests
    {
        int Successes { get; }
        int Failures { get; }

        void AddSuccess();
        void AddFailure();
    }
}