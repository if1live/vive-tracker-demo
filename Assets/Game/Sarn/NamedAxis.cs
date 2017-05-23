using UnityEngine;

namespace Assets.Game.Sarn {
    class NamedAxis : MonoBehaviour {
        [SerializeField]
        string label = "Label";

        void Start() {
            this.Text = label;
        }

        public string Text
        {
            get { return this.label; }
            set
            {
                this.label = value;

                var tms = GetComponentsInChildren<TextMesh>();
                foreach (var tm in tms) {
                    tm.text = value;
                }
            }
        }

        public void SetVisible(bool b) {
            var rs = GetComponentsInChildren<Renderer>();
            foreach(var r in rs) {
                r.enabled = b;
            }
        }
    }
}
