using Monies.Database.Extensions;
using System;

namespace Monies.Cons
{
    public static class Settings
    {
        private readonly static string CS = "U2VydmVyPXZwcy5kc3p5bWFuc2tpLnBsO1BvcnQ9NTQzMjtEYXRhYmFzZT1waW5pb25kejtVc2VyIElkPXBpbmlvbmR6O1Bhc3N3b3JkPXswfTs=";
        public static string GetConnString()
        {
            if(System.IO.File.Exists("pass.txt"))
            {
                return string.Format(CS.B64Decode(), System.IO.File.ReadAllText("pass.txt").Trim());
            }

            Console.WriteLine("Provide DB password (press ESC to exit):");
            var key = ConsoleKey.Backspace;
            var pass = "";
            var length = 0;
            while(key != ConsoleKey.Enter && length < 64)
            {
                var cki = Console.ReadKey(true);
                if(cki.Key == ConsoleKey.Escape)
                    System.Environment.Exit(0);
                if(cki.Key == ConsoleKey.Backspace)
                {
                    if(pass.Length == 1)
                        pass = "";
                    else if(pass.Length > 0)
                    {
                        pass = pass.Substring(0, pass.Length - 1);
                    }
                }
                else if(cki.Key == ConsoleKey.Enter)
                    break;
                else
                {
                    pass += cki.KeyChar.ToString();
                    length++;
                }
                key = cki.Key;
            }

            if(string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Entered password was empty. Maybe look out for new line character in paste?");
                System.Environment.Exit(0);
            }
            
            return string.Format(CS.B64Decode(), pass);
        }
    }
}