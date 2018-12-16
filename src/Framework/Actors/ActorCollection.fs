namespace Animations.Actors

open Animations
open PropertyHelpers

type internal ActorCollection(properties: AnimationProperties, actors: seq<IActor * AnimationTimePoint * AnimationTimePoint>) = 
    
    let actors = 
        actors
        |> Seq.map (fun (actor, start, finish) -> actor, GetFrameNumber(start, properties), GetFrameNumber(finish, properties))
        |> List.ofSeq

    member public this.InvokeActors(context: DrawContext) = 
        
        for (actor, start, finish) in actors do

            if ((start <= context.FrameNumber) && (context.FrameNumber < finish)) then
                actor.Perform(context)
