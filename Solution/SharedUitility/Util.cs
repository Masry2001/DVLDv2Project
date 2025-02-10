using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

public static class Util
{
    public static void LogError(string message,
                                [CallerMemberName] string methodName = "",
                                [CallerFilePath] string filePath = "")
    {
        // Specify the source name for the event log
        string sourceName = "DVLDv2";
        string logName = "Application";

        // Create the event source if it does not exist
        if (!EventLog.SourceExists(sourceName))
        {
            EventLog.CreateEventSource(sourceName, logName);
        }

        // Extract file name from file path
        string fileName = System.IO.Path.GetFileName(filePath);

        // Extract project name from the file path (assuming folder name is project name)
        string projectName = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(filePath));

        // Log an error event with project name, file name, and method name included
        EventLog.WriteEntry(sourceName, $"{projectName}::{fileName}::{methodName}: {message}", EventLogEntryType.Error);

        Console.WriteLine($"{projectName}::{fileName}::{methodName}: {message}");
    }


    public static string ComputeHash(string input)
    {
        //SHA is Secutred Hash Algorithm.
        // Create an instance of the SHA-256 algorithm
        using (SHA256 sha256 = SHA256.Create())
        {
            // Compute the hash value from the UTF-8 encoded input string
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert the byte array to a lowercase hexadecimal string
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }


}
