namespace NetChallenge.Abstractions
{
    public interface IValidate<T>
    {
        void Validate(T request);
    }
}