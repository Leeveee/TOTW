using System;

namespace Reactive
{
    [Serializable]
    public class ReactiveInt : ReactiveProperty<int>
    {
        public ReactiveInt(int value) : base(value) { }
    }
}