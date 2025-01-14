using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Thomas.Siest.ObjectDetection.Tests
{
    public class ObjectDetectionUnitTest
    {
        [Fact]
        public async Task ObjectShouldBeDetectedCorrectly()
        {
            var executingPath = GetExecutingPath();
            var imageScenesData = new List<byte[]>();

            foreach (var imagePath in Directory.EnumerateFiles(Path.Combine(executingPath, "Scenes")))
            {
                var imageBytes = await File.ReadAllBytesAsync(imagePath);
                imageScenesData.Add(imageBytes);
            }

            var detectObjectInScenesResults = await new ObjectDetection().DetectObjectInScenesAsync(imageScenesData);

            Assert.Equal(
                "[{\"Dimensions\":{\"X\":224.27759,\"Y\":64.26219,\"Height\":226.47531,\"Width\":81.26442},\"Label\":\"bottle\",\"Confidence\":0.8861316}," +
                "{\"Dimensions\":{\"X\":128.21892,\"Y\":83.48009,\"Height\":180.8642,\"Width\":75.946815},\"Label\":\"bottle\",\"Confidence\":0.7525618}," +
                "{\"Dimensions\":{\"X\":308.8601,\"Y\":101.06335,\"Height\":151.38896,\"Width\":58.952698},\"Label\":\"bottle\",\"Confidence\":0.33410567}]",
                JsonSerializer.Serialize(detectObjectInScenesResults[0].Box)
            );

            Assert.Equal(
                "[{\"Dimensions\":{\"X\":0.8776779,\"Y\":196.59088,\"Height\":199.99211,\"Width\":158.47617},\"Label\":\"dog\",\"Confidence\":0.5492805}]",
                JsonSerializer.Serialize(detectObjectInScenesResults[1].Box)
            );
        }

        private static string GetExecutingPath()
        {
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var executingPath = Path.GetDirectoryName(executingAssemblyPath);
            return executingPath;
        }
    }
}