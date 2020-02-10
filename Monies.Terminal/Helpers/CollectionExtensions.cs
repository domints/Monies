using System.Collections.Generic;

namespace Monies.Terminal
{
    public static class CollectionExtensions
    {
        public static T NullPeek<T>(this Stack<T> stack)
        {
            if(stack.Count == 0)
                return default(T);

            return stack.Peek();
        }
    }
}