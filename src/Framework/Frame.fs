namespace Animations

type public Frame(width: int, height: int) =
    
    let bytesPerPixel = 4 //currently only BGRA is supported
    let bytes = Array.zeroCreate<byte>(width * height * bytesPerPixel)

    member this.Width = width
    member this.Height = height
    member this.BytesPerRow = width * bytesPerPixel
    member this.Bytes = bytes
