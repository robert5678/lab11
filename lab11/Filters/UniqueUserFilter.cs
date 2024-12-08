using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace lab11.Filters
{
    public class UniqueUserFilter : IActionFilter
    {
        private static readonly ConcurrentDictionary<string, bool> UniqueUsers = new();
        private readonly string logFilePath = "unique_users_log.txt";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userIP = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            if (!string.IsNullOrEmpty(userIP))
            {
                if (UniqueUsers.TryAdd(userIP, true))
                {
                    var uniqueUserCount = UniqueUsers.Count;
                    var logMessage = $"Unique User Count: {uniqueUserCount}, Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}";

                    File.AppendAllText(logFilePath, logMessage);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
