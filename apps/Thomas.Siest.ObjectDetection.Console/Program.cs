using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Thomas.Siest.ObjectDetection;

namespace Thomas.Siest.ObjectDetection.Console
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Usage: dotnet run <path_to_scenes_directory>");
                return;
            }

            var scenesDirectory = args[0];

            if (!Directory.Exists(scenesDirectory))
            {
                System.Console.WriteLine($"Erreur : le répertoire {scenesDirectory} n'existe pas.");
                return;
            }

            var imageScenesData = new List<byte[]>();
            foreach (var imagePath in Directory.EnumerateFiles(scenesDirectory))
            {
                var imageBytes = await File.ReadAllBytesAsync(imagePath);
                imageScenesData.Add(imageBytes);
            }

            var objectDetection = new ObjectDetection();
            var detectObjectInScenesResults = await objectDetection.DetectObjectInScenesAsync(imageScenesData);

            foreach (var objectDetectionResult in detectObjectInScenesResults)
            {
                System.Console.WriteLine($"Box: {JsonSerializer.Serialize(objectDetectionResult.Box)}");
            }
        }
    }
}
