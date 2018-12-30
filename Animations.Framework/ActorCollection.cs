using System.Collections.Generic;
using System.Linq;

namespace Animations.Framework
{
    internal class ActorCollection
    {
        private struct ValueType
        {
            public IActor Actor;
            public int Start;
            public int Finish;
        }

        private readonly ValueType[] _actors;

        public ActorCollection(AnimationProperties properties, IEnumerable<ActorEntry> actors)
        {
            _actors = actors.Select(tuple => new ValueType
            {
                Actor = tuple.Actor,
                Start = tuple.Start.GetFrameNumber(properties),
                Finish = tuple.Finish.GetFrameNumber(properties)
            }).ToArray();
        }

        public void InvokeActors(IDrawContext context)
        {
            foreach (var item in _actors)
            {
                if ((item.Start <= context.FrameNumber) && (context.FrameNumber < item.Finish))
                {
                    item.Actor.Perform(context);
                }
            }
        }
    }
}