using UnityEngine;

namespace Assets.Game.Sarn {
    public class SingletonHolder<T> where T : UnityEngine.Object {
        readonly static SingletonHolder<T> _instance;
        public static SingletonHolder<T> Instance
        {
            get
            {
                if(_instance.Value == null) {
                    _instance.Refresh();
                }
                return _instance;
            }
        }

        static SingletonHolder() {
            _instance = new SingletonHolder<T>();
        }

        public T Value { get; private set; }

        SingletonHolder() {
            Refresh();
        }

        public void Refresh() {
            Value = GameObject.FindObjectOfType<T>();
        }
    }
}
