using System;

namespace Animations.Framework
{
    public class ActorDelegate : IActor
    {
        public ActorDelegate(Action<IDrawContext> callback)
        {
            _callback = callback;
        }
        
        public void Perform(IDrawContext context)
        {
            _callback(context);
        }
        
        private readonly Action<IDrawContext> _callback;
    }
}