using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CustomExceptionHelper
    {

        #region "Private Methods"

        public static CustomException InitializationFaultException(Exception exception, string title)
        {
            return new CustomException
            {
                Title = title,
                ExceptionMessage = exception.Message,
                InnerException =
                                exception.InnerException != null ? exception.InnerException.ToString() : string.Empty,
                StackTrace = exception.StackTrace
            };
        }

        #endregion
    }
}
