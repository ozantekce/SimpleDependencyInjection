namespace SimpleDependencyInjection
{

    public class InjectField<T>
    {

        private T _value;
        private string _alias = null;

        public T Value { get => GetT(); set => _value = value; }

        public InjectField()
        {

        }

        public InjectField(string alias)
        {
            _alias = alias;
        }

        private T GetT()
        {
            if(_value == null || ((_value as UnityEngine.Object) == null))
            {
                _value = DependencyInjectionManager.Get<T>(_alias);
            }
            return _value;
        }

        public static explicit operator T(InjectField<T> field)
        {
            return field.GetT();
        }

    }


}

