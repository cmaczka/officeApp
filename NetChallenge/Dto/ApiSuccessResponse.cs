namespace NetChallenge.Dto
{
    public class ApiSuccessResponse<T>
    {
        public ApiSuccessResponse()
        {
        }

        public int Status { get; set; }
        public T Data { get; set; }
    }
}