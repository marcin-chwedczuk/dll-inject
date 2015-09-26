using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection {
    static class Utils {
        public static void CheckForFailure(bool failureIndicator, string message, params object[] args) {
            if (!failureIndicator)
                return;

            var userMessage = string.Format(message, args);
            var lastWinErrorMessage = string.Format("LastWinError: {0}", Marshal.GetLastWin32Error());

            var exceptionMessage = string.Format("{0} ({1})", userMessage, lastWinErrorMessage);
            throw new DLLInjectionFailedException(exceptionMessage);
        }
    }
}
