using System;

namespace SynCartCustomList;

/// <summary>
/// Main Class
/// </summary>
class Program
{
    /// <summary>
    /// Main Method to Start the Application
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        
        Operation.LoadDefaultData();
        Operation.MainMenu();
    }
}