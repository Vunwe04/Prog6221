using System;
using System.IO;
using System.Media;

namespace CyberSecurityAwarenessBot
{
    public class Chatbot
    {
        public void Run()
        {
            PlayAudio();
            ShowHeader();
            WelcomeUser();
            StartChat();
        }

        // Welcome Section
        private void WelcomeUser()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nHello {name}! I will help you stay safe online.");
            Console.WriteLine("You can ask about passwords, phishing, or safe browsing.");
            Console.WriteLine("Type 'exit' to quit.\n");
            Console.ResetColor();
        }

        // Chat Loop
        private void StartChat()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("You: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Bot: Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                string response = GenerateReply(input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response);
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // Response Logic 
        private string GenerateReply(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
            {
                return "Bot: Use strong passwords with a mix of letters, numbers, and symbols.";
            }
            else if (input.Contains("phishing"))
            {
                return "Bot: Phishing scams try to trick you. Never share personal info through unknown emails.";
            }
            else if (input.Contains("link") || input.Contains("browse"))
            {
                return "Bot: Always check if a website is secure (HTTPS) before clicking links.";
            }
            else if (input.Contains("how are you"))
            {
                return "Bot: I'm doing great and ready to help!";
            }
            else if (input.Contains("purpose"))
            {
                return "Bot: My purpose is to teach you about cybersecurity awareness.";
            }
            else
            {
                return "Bot: I didn’t understand that. Please try asking differently.";
            }
        }

        // Audio
        private void PlayAudio()
        {
            try
            {
                string path = Path.Combine("assets", "greeting.wav");

                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Load();
                    player.PlaySync();
                }
                else
                {
                    Console.WriteLine("Bot: Audio file not found.");
                }
            }
            catch
            {
                Console.WriteLine("Bot: Unable to play audio greeting.");
            }
        }

        // ASCII Header 
        private void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("========================================");
            Console.WriteLine("      CYBERSECURITY AWARENESS BOT      ");
            Console.WriteLine("========================================");

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
