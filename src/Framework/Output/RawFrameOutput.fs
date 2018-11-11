namespace Animations.Output

open Animations
open System
open System.IO

type public RawFrameOutput(destinationFileFormat: string) =
    
    let mutable frameNumber: int = 0

    member this.Write(frame: Frame): unit = 
        File.WriteAllBytes(String.Format(destinationFileFormat, frameNumber), frame.Bytes)
        frameNumber <- frameNumber + 1

    interface IVideoOutput with
        member this.Dispose(): unit = ()
        member this.Write frame = this.Write frame
    