namespace Animations.Actors

open Animations

type public IActor =

    abstract member Perform : DrawContext -> unit
