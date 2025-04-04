using System;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Linq;
using System.Threading;

class Program
{
    static SpeechService speechService = new SpeechService();

    static void Main(string[] args)
    {
        DisplayAsciiArt(); //Call the display art method
TypeWithDelay("Welcome to the Cybersecurity Awareness Bot.\n", ConsoleColor.Cyan);
speechService.Speak("Welcome to the Cybersecurity Awareness Bot.");
DisplaySectionDivider(); //Call the section divider method
StartChatbot(); //Call the start chatbot method
        
    }
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
    //Add borders to the code
static void DisplaySectionDivider()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("═════════════════════════════════════════════════════════════");
    Console.ResetColor();
}
    static void TypeWithDelay(string text, ConsoleColor color, int delay = 50)
{
    Console.ForegroundColor = color;
    foreach (char c in text)
    {
        Console.Write(c);
        Thread.Sleep(delay); // Typing effect
    }
    Console.ResetColor();
}
//Text-base greeting, user interaction and symbols
    static void StartChatbot()
{
    string name = "";
    //Ask the user for their name and personalise responses
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("✏️  What is your name? ");
        Console.ResetColor();
        name = Console.ReadLine();

        if (Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
        {
            break;
        }
        else
        {
            TypeWithDelay("❌ Invalid input! Please enter a valid name (letters and spaces only, no numbers or special characters).\n", ConsoleColor.Red);
        }
    }

    TypeWithDelay($"✅ Welcome {name} to the Cybersecurity Awareness Bot.\nWRITE 'quit' TO EXIT\n", ConsoleColor.Cyan);
    speechService.Speak($"Welcome {name} to the Cybersecurity Awareness Bot.");
    DisplaySectionDivider();

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"💬 {name}, what would you like to know? ");
        Console.ResetColor();
        string userInput = Console.ReadLine();
        string normalizedInput = NormalizeInput(userInput);

        if (normalizedInput.Contains("what can i ask you about"))
        {
            TypeWithDelay("📜 You can ask me about password safety, phishing, and safe browsing.\n", ConsoleColor.Yellow);
        }
        else if (normalizedInput.Equals("quit"))
        {
            TypeWithDelay($"🚪 Thank you for chatting, {name}! Stay safe online.\n", ConsoleColor.Green);
            break;
        }
        else if (string.IsNullOrWhiteSpace(userInput))
        {
            TypeWithDelay("🤔 I didn't quite understand that. Could you rephrase?\n", ConsoleColor.Red);
        }
        else
        {
            // BASIC RESPONCE SYSTEM 
            //Questions a user might ask
            switch (normalizedInput)
            {
                case var input when input.Contains("what's your purpose"):
                    Console.WriteLine("You can ask me about password safety, phishing, and safe browsing.");
                    break;
                case var input when input.Contains("how can i create a strong password"):
                    Console.WriteLine("Use a mix of letters, numbers, and symbols, and avoid using easily guessable information.");
                    break;
                case var input when input.Contains("what is phishing and how can i avoid it"):
                    Console.WriteLine("Phishing is a scam where attackers impersonate legitimate entities to steal personal information. Always verify the source before clicking links.");
                    break;
                case var input when input.Contains("how can i browse the internet safely"):
                    Console.WriteLine("Use secure websites (look for HTTPS), avoid public Wi-Fi for sensitive transactions, and keep your software updated.");
                    break;
                case var input when input.Contains("tell me about password safety"):
                    Console.WriteLine("Always use strong passwords, change them regularly, and never share them.");
                    break;
                case var input when input.Contains("what is phishing"):
                    Console.WriteLine("Phishing is a method used by cybercriminals to trick you into giving them your personal information.");
                    break;
                case var input when input.Contains("how to browse safely"):
                    Console.WriteLine("Use secure websites (https), avoid public Wi-Fi for sensitive transactions, and keep your software updated.");
                    break;
                default:
                    Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                    break;
            }
        }
    }
}
    //Validate input 
    static string NormalizeInput(string input)
    {
        return Regex.Replace(input.ToLower(), "[^a-z0-9 ]", ""); //It ignores special characters and numbers
                                                                 //It converts everthing to lower
        
    }
}
