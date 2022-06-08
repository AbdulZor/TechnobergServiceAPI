namespace TechnobergService.Controllers
{
    public class SyncApiResponse
    {
        public SyncApiResponse(ResultType result, string message)
        {
            Result = result;
            Message = message;
        }

        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
