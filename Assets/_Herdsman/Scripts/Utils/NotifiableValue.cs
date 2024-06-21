using System;

namespace Herdsman.Utils
{
    [Serializable]
    public class NotifiableValue<T> where T : struct, IEquatable<T>
    {
        public event Action<T> OnChange;
        private T _value = default;
        public T Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    OnChange?.Invoke(_value);
                }
            }
        }

        public NotifiableValue()
        {
            _value = default;
        }

        public NotifiableValue(T t)
        {
            _value = t;
        }
    }
}