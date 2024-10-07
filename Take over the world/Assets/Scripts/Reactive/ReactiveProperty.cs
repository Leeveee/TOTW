using System;
using UnityEngine;

namespace Reactive
{
    [Serializable]
    public class ReactiveProperty<T>
    {
        [SerializeField]
        protected T _value;
        public event Action<T> OnChanged;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }

        public ReactiveProperty()
        {
            _value = default;
        }

        public ReactiveProperty(T value)
        {
            _value = value;
        }

        public void SetSilent(T value) => _value = value;

        private void EditorOnValueChanged()
        {
            OnChanged?.Invoke(_value);
        }
    }
}