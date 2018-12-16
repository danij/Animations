namespace Animations

open Animations.Actors
open Animations.Output
open SkiaSharp
open System
open System.Runtime.InteropServices

type public Animation(properties: AnimationProperties, backgroundColor: SKColor, output: IVideoOutput) =

    let frame = new Frame(properties.Width, properties.Height)
    let frameCount = 
        match properties.Length with
            | FrameCount count -> count
            | TimeLength time -> int (Math.Ceiling(time.TotalSeconds * properties.Fps))

    let imageInfo = new SKImageInfo(properties.Width, properties.Height, SKColorType.Bgra8888)

    let DrawOnCurrentFrame(callback: SKCanvas -> unit): unit =

        let pinnedBytes = GCHandle.Alloc(frame.Bytes, GCHandleType.Pinned)
        using (SKSurface.Create(imageInfo, pinnedBytes.AddrOfPinnedObject(), frame.BytesPerRow)) (fun surface ->
        
            let canvas = surface.Canvas
            canvas.Clear(backgroundColor)
            callback(canvas)
        )
        pinnedBytes.Free()

    let RenderFrame(frameNumber: int, actors: ActorCollection): unit =

        DrawOnCurrentFrame(fun canvas -> 
            
            let time = TimeSpan.FromSeconds((float frameNumber) / properties.Fps)
            let context = new DrawContext(properties = properties, frameNumber = frameNumber, time = time, canvas = canvas)
            
            actors.InvokeActors(context)
        )

    member public this.Run(actors: seq<IActor * AnimationTimePoint * AnimationTimePoint>): unit = 
        
        let actorCollection = new ActorCollection(properties, actors)

        for i = 0 to frameCount - 1 do
            RenderFrame(i, actorCollection)
            output.Write(frame)
