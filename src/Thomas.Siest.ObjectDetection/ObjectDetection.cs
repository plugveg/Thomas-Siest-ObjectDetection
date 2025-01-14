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
}