namespace Animations.Output

open System
open Animations

type public IVideoOutput =
    inherit IDisposable

    abstract member Write : Frame -> unit
