namespace MobileLogging.Common.Interface
{
    public interface IManneLogManager
    {
        IManneLogger GetLog([System.Runtime.CompilerServices.CallerFilePath]string callerFilePath = "");
    }
}