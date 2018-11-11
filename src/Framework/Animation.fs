namespace Animations

open Animations.Output
open System

type public AnimationLength = 
    | FrameCount of int
    | Seconds of float

type public Animation(width: int, height: int, length: AnimationLength, fps: float, output: IVideoOutput) =

    let frame = new Frame(width, height)
    let frameCount = 
        match length with
            | FrameCount count -> count
            | Seconds seconds -> int (Math.Ceiling(seconds * fps))

    member public this.Run(): unit = 

        for i = 0 to frameCount - 1 do
            output.Write(frame)
