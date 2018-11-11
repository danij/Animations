open System

open Animations
open Animations.Output

let createSampleAnimation(): unit = 

    using (new RawFrameOutput("frame-{0:0000}.raw")) (fun output ->

        let animation = new Animation(800, 600, FrameCount(10), 2.0, output)
        animation.Run()
    )

[<EntryPoint>]
let main argv =

    createSampleAnimation()
    0
