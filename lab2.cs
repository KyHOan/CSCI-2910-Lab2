using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using System.Runtime.InteropServices;
using Lab1;
using System.Collections.Immutable;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VideoGame videoGame;
            List<VideoGame?> listOfGames = new List<VideoGame?>();
            Stack<VideoGame?> videoGameStack = new Stack<VideoGame?>();
            Queue<string> vdgQueue = new Queue<string>();

            //File Path that needs to be read
            string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = $"{projectRootFolder}{Path.DirectorySeparatorChar}videogames.csv";
            var videoGames = new List<VideoGame>();

            try
            {
                //Read all text from the file
                string fileContents = File.ReadAllText(filePath);

                //Print the contents of the file to the console
                Console.WriteLine("File Contents: ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured while trying to read this file, please try again");
                Console.WriteLine(ex.Message);
            }

            using (var sr = new StreamReader(filePath))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] lineData = line.Split(',');
                    VideoGame vg = new VideoGame(lineData[0].Trim(), lineData[1].Trim(), lineData[2].Trim(), lineData[3].Trim(), lineData[4].Trim(), Convert.ToDouble(lineData[5].Trim()),
                                  Convert.ToDouble(lineData[6].Trim()), Convert.ToDouble(lineData[7].Trim()), Convert.ToDouble(lineData[8].Trim()), Convert.ToDouble(lineData[9].Trim()));
                    videoGames.Add(vg);
                }

            }
            Dictionary<string, List<VideoGame>> gamesByPlatform = videoGames
            .GroupBy(game => game.Platform)
            .ToDictionary(
                group => group.Key,    // Key is the platform
                group => group.ToList() // List of games for that platform
            );

            // Now you can access games by platform
            foreach (var platform in gamesByPlatform)
            {
                Console.WriteLine($"Platform: {platform.Key}");
                foreach (var game in platform.Value)
                {
                    Console.WriteLine($"  - {game.Name}");
                }
            }
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            //View top 5 Global sell.
            // Lambda/arrow function to get the top 5 games by global sales for a given platform
            Func<string, List<VideoGame>> top5GamesByGlobalSales = (platform) =>
            {
                if (gamesByPlatform.TryGetValue(platform, out var games))
                {
                    return games.OrderByDescending(game => game.GlobalSales).Take(5).ToList();
                }
                return new List<VideoGame>();
            };

            string platformToQuery = "PS4"; // Replace with the desired platform

            // Get the top 5 games for the specified platform using the lambda function
            List<VideoGame> top5Games = top5GamesByGlobalSales(platformToQuery);

            // Display the top 5 games
            Console.WriteLine($"Top 5 Games for {platformToQuery} by Global Sales:");
            foreach (var game in top5Games)
            {
                Console.WriteLine($"{game.Name} - Global Sales: {game.GlobalSales}");
            }
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            foreach (var platform in gamesByPlatform)
            {
                Console.WriteLine($"Platform: {platform.Key}");
                List<VideoGame> top5GamesE= top5GamesByGlobalSales(platform.Key);
                foreach (var game in top5GamesE)
                {
                    Console.WriteLine($"{game.Name} - Global Sales: {game.GlobalSales}");
                }
            }
        }

    }
}