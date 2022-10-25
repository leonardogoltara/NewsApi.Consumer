using System.Text;

namespace NewsApi.Consumer.API.ExtensionsMethods
{
    public static class ExceptionMethods
    {
        public static string GetCompleteMessage(this Exception exception)
        {
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.AppendLine(exception.Message);

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                errorMessage.AppendLine(exception.Message);
            }

            return errorMessage.ToString();
        }
    }
}
