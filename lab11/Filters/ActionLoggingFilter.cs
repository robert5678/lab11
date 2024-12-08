using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace lab11.Filters
{
    public class ActionLoggingFilter : IActionFilter
    {
        private readonly string logFilePath = "action_log.txt";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logMessage = $"Method: {actionName}, Access Time: {timestamp}{Environment.NewLine}";

            File.AppendAllText(logFilePath, logMessage);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
