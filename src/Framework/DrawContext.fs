namespace Animations

open System
open SkiaSharp

type public DrawContext = 
    struct
        val Properties: AnimationProperties
        val FrameNumber: int
        val Time: TimeSpan
        val Canvas: SKCanvas

        new (properties: AnimationProperties, frameNumber: int, time: TimeSpan, canvas: SKCanvas) = 
            { Properties = properties; FrameNumber = frameNumber; Time = time; Canvas = canvas }
    end

