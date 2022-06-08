namespace TechnobergService.Controllers
{
    public enum ResultType
    {
        Allow, Deny
        //TODO:: Can be extended if asynchronous authentication is implemented,
        //by also notifying that the push notification is pushed or that it failed to push
    }
}