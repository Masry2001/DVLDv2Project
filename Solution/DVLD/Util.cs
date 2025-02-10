using System;
using System.Runtime.CompilerServices;

public class Util
{
	public Util()
	{
        static void LogError(string message, [CallerMemberName] string methodName = "")
        {
            // this use using System.Runtime.CompilerServices;

            // Log Events To Event Viewer
            // Specify the source name for the event log
            string sourceName = "DVLDv2";
            string LogName = "Application";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, LogName);
            }

            // Log an error event with method name included
            EventLog.WriteEntry(sourceName, $"{methodName}: {message}", EventLogEntryType.Error);
            Console.WriteLine("${methodName}: {message}");
        }

    }
}
