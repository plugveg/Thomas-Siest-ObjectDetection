﻿using ObjectDetection;

namespace Thomas.Siest.ObjectDetection;

public record ObjectDetectionResult
{
    public byte[] ImageData { get; set; } 
    public IList<BoundingBox> Box { get; set; }
} 