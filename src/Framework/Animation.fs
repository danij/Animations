namespace Animations

open Animations.Output
open SkiaSharp
open System
open System.Runtime.InteropServices

type public Animation(properties: AnimationProperties, backgroundColor: SKColor, output: IVideoOutput) =

    let frame = new Frame(properties.Width, properties.Height)
    let frameCount = 
        match properties.Length with
            | FrameCount count -> count
            | Seconds seconds -> int (Math.Ceiling(seconds * properties.Fps))
    let imageInfo = new SKImageInfo(properties.Width, properties.Height, SKColorType.Bgra8888)

    let DrawOnCurrentFrame(callback: SKCanvas -> unit): unit =

        let pinnedBytes = GCHandle.Alloc(frame.Bytes, GCHandleType.Pinned)
        using (SKSurface.Create(imageInfo, pinnedBytes.AddrOfPinnedObject(), frame.BytesPerRow)) (fun surface ->
        
            let canvas = surface.Canvas
            canvas.Clear(backgroundColor)
            callback(canvas)
        )
        pinnedBytes.Free()

    let RenderFrame(index: int): unit =

        DrawOnCurrentFrame(fun canvas -> ())

    member public this.Run(): unit = 

        for i = 0 to frameCount - 1 do
            RenderFrame(i)
            output.Write(frame)
