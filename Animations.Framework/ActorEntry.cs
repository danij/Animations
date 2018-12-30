namespace Animations.Framework
{
    public class ActorEntry
    {
        public ActorEntry(IActor actor, AnimationTimePoint start, AnimationTimePoint finish)
        {
            Actor = actor;
            Start = start;
            Finish = finish;
        }

        public IActor Actor { get; }
        public AnimationTimePoint Start { get; }
        public AnimationTimePoint Finish { get; }
    }
}