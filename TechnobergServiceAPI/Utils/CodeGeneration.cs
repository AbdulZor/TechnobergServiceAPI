namespace TechnobergServiceAPI.Utils
{
    public class CodeGeneration
    {
        public static Guid CreateActivationCode()
        {
            return Guid.NewGuid();
        }
    }
}
