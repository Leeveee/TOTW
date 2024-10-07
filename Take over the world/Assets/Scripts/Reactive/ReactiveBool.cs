using System;

namespace Reactive
{
    [Serializable]
    public class ReactiveBool : ReactiveProperty<bool>
    {
        public ReactiveBool(bool value) : base(value) { }

        public static implicit operator ReactiveBool(bool value) => new(value);
        public static implicit operator bool(ReactiveBool value) => value._value;
    }
}