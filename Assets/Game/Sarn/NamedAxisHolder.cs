using UnityEngine;

namespace Assets.Game.Sarn {
    class NamedAxisHolder : MonoBehaviour {
        public NamedAxis axisPrefab;
        NamedAxis axis;

        public string label = "label";

        private void Awake() {
            axis = Instantiate<NamedAxis>(axisPrefab);
            axis.Text = label;

            var tr = axis.transform;
            tr.SetParent(transform);
            tr.localPosition = Vector3.zero;
            tr.localRotation = Quaternion.identity;
            tr.localScale = Vector3.one;
        }
    }
}
