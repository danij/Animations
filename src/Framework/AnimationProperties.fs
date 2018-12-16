namespace Animations

open System

type public AnimationLength =
    | FrameCount of int
    | TimeLength of TimeSpan

type public AnimationTimePoint =
    | Start
    | End
    | Frame of int
    | Time of TimeSpan

type public AnimationProperties = 
    struct
        val Width: int
        val Height: int
        val Length: AnimationLength
        val Fps: float

        new (width: int, height: int, length: AnimationLength, fps: float) = { Width = width; Height = height; Length = length; Fps = fps }
    end

module PropertyHelpers = 

    let GetFrameNumber(timepoint: AnimationTimePoint, properties: AnimationProperties) = 
        match timepoint with
            | Start -> 0
            | End -> System.Int32.MaxValue
            | Frame frameNumber -> frameNumber
            | Time time -> int(time.TotalSeconds * properties.Fps)
