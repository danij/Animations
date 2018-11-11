open Animations
open Animations.Output
open SkiaSharp

let createSampleAnimation(): unit = 

    let properties = new AnimationProperties(width = 800, height = 600, length = FrameCount(10), fps = 2.0)

    using (new FFmpegOutput("animation.mp4", properties)) (fun output ->

        let animation = new Animation(properties, SKColors.AliceBlue, output)
        animation.Run()
    )

[<EntryPoint>]
let main argv =

    createSampleAnimation()
    0
