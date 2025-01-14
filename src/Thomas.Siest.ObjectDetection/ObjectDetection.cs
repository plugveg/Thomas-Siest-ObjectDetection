using System.Collections.Concurrent;
using ObjectDetection;

namespace Thomas.Siest.ObjectDetection;

public class ObjectDetection
{
    public async Task<IList<ObjectDetectionResult>> DetectObjectInScenesAsync(IList<byte[]> imagesSceneData)
    {
        await Task.Delay(1000);

        var results = new ConcurrentBag<ObjectDetectionResult>();
        var tinyYolo = new Yolo();

        var tasks = imagesSceneData.Select(imageData => Task.Run(() =>
        {
            var detectionResult = tinyYolo.Detect(imageData);
            results.Add(new ObjectDetectionResult
            {
                ImageData = detectionResult.ImageData,
                Box = detectionResult.Boxes
            });
        }));

        await Task.WhenAll(tasks);

        return results.ToList();
    }
    
    public async Task<IList<ObjectDetectionResult>> DetectObjectInScenesMockAsync(IList<byte[]> imagesSceneData)
    {
        await Task.Delay(100); // Simuler un délai pour ressembler à un appel réel
        return new List<ObjectDetectionResult>
        {
            new ObjectDetectionResult
            {
                ImageData = new byte[] { 0 },
                Box = new List<BoundingBox>
                {
                    new BoundingBox
                    {
                        Dimensions = new BoundingBoxDimensions { X = 224.27759f, Y = 64.26219f, Height = 226.47531f, Width = 81.26442f },
                        Label = "bottle",
                        Confidence = 0.8861316f
                    },
                    new BoundingBox
                    {
                        Dimensions = new BoundingBoxDimensions { X = 128.21892f, Y = 83.48009f, Height = 180.8642f, Width = 75.946815f },
                        Label = "bottle",
                        Confidence = 0.7525618f
                    },
                    new BoundingBox
                    {
                        Dimensions = new BoundingBoxDimensions { X = 308.8601f, Y = 101.06335f, Height = 151.38896f, Width = 58.952698f },
                        Label = "bottle",
                        Confidence = 0.33410567f
                    }
                }
            },
            new ObjectDetectionResult
            {
                ImageData = new byte[] { 0 },
                Box = new List<BoundingBox>
                {
                    new BoundingBox
                    {
                        Dimensions = new BoundingBoxDimensions { X = 0.8776779f, Y = 196.59088f, Height = 199.99211f, Width = 158.47617f },
                        Label = "dog",
                        Confidence = 0.5492805f
                    }
                }
            }
        };
    }

}

