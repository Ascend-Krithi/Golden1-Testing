using System;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Utilities
{
    public static class RetryHelper
    {
        public static T ExecuteWithRetry<T>(Func<T> action, int maxAttempts = 3, int delayMs = 1000)
        {
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    LogHelper.Debug($"Attempt {attempt} of {maxAttempts}");
                    return action();
                }
                catch (Exception ex)
                {
                    if (attempt == maxAttempts)
                    {
                        LogHelper.Error($"All {maxAttempts} attempts failed", ex);
                        throw;
                    }
                    
                    LogHelper.Warning($"Attempt {attempt} failed, retrying in {delayMs}ms...");
                    System.Threading.Thread.Sleep(delayMs);
                }
            }
            
            throw new InvalidOperationException("Should not reach here");
        }

        public static void ExecuteWithRetry(Action action, int maxAttempts = 3, int delayMs = 1000)
        {
            ExecuteWithRetry(() =>
            {
                action();
                return true;
            }, maxAttempts, delayMs);
        }
    }
}
