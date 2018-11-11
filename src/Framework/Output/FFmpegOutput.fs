namespace Animations.Output

open Animations
open System
open System.Diagnostics

type public FFmpegOutput(destinationFilePath: string, properties: AnimationProperties) =
    
    let ffmpegProcess = new Process()

    do
        ffmpegProcess.StartInfo.FileName <- "ffmpeg"
        let argumentsFormat = "-y -f rawvideo -pix_fmt bgra -s:v {0}x{1} -r {2:F2} -i pipe:0 -dst_range 0 -pix_fmt yuv422p -crf 0 \"{3}\""
        ffmpegProcess.StartInfo.Arguments <- String.Format(argumentsFormat, properties.Width, properties.Height, 
                                                           properties.Fps, destinationFilePath)
        ffmpegProcess.StartInfo.UseShellExecute <- false
        ffmpegProcess.StartInfo.RedirectStandardInput <- true
        ffmpegProcess.Start() |> ignore

    interface IDisposable with
        member this.Dispose() = 
            ffmpegProcess.StandardInput.BaseStream.Close()
            ffmpegProcess.WaitForExit()

    member this.Write bytes =
        ffmpegProcess.StandardInput.BaseStream.Write(bytes, 0, bytes.Length)

    interface IVideoOutput with
        member this.Write frame = this.Write frame.Bytes
    