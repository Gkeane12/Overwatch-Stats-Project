using System;
using System.IO;
using System.Text;

namespace OverwatchNightlyUpdaterClient
{
    internal class FileLogger
    {
        StringBuilder _errorStringbuilder = new StringBuilder();
        StringBuilder _successStringBuilder = new StringBuilder();

        internal FileLogger()
        { } 

        public void WriteError(string userName)
        {
            _errorStringbuilder.AppendLine(String.Format("Error With Profile: {0}", userName));
        }

        public void WriteSuccess(string userName)
        {
            _successStringBuilder.AppendLine(String.Format("Successfully updated Profile: {0}",userName));
        }

        public void WriteReports()
        {
            File.WriteAllText("./ErrorReport.txt", _errorStringbuilder.ToString());
            File.WriteAllText("./SuccessReport.txt", _successStringBuilder.ToString());
        }
    }
}
