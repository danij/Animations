namespace Animations

type public AnimationLength = 
    | FrameCount of int
    | Seconds of float

type public AnimationProperties = 
    struct
        val Width: int
        val Height: int
        val Length: AnimationLength
        val Fps: float

        new (width: int, height: int, length: AnimationLength, fps: float) = { Width = width; Height = height; Length = length; Fps = fps }
    end

