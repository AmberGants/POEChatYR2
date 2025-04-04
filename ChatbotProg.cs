using System;

class Program
{
    static SpeechService speechService = new SpeechService();

    static void Main(string[] args)
    {
    
    }
            //Create cybersecurity-themed symbol
        static void DisplayAsciiArt()
        {
            string asciiArt = @"
   ____ _           _                       _       _             
  / ___| |__   __ _| |_ ___ _ __ ___   __ _| | __ _| |_ ___  _ __ 
 | |   | '_ \ / _` | __/ _ \ '_ ` _ \ / _` | |/ _` | __/ _ \| '__|
 | |___| | | | (_| | ||  __/ | | | | | (_| | | (_| | || (_) | |   
  \____|_| |_|\__,_|\__\___|_| |_| |_|\__,_|_|\__,_|\__\___/|_|   
                                                                 
";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }
}