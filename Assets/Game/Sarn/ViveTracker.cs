using UnityEngine;

namespace Assets.Game.Sarn {
    public class ViveTracker : MonoBehaviour {
        static ViveTracker[] trackers = new ViveTracker[2];
        public static ViveTracker Get(ViveTrackerType t) {
            var tracker = trackers[(int)t];
            if(tracker == null) {
                return null;
            }
            if (!tracker.gameObject.activeInHierarchy) {
                return null;
            }
            return tracker;
        }

        [SerializeField]
        ViveTrackerType type = ViveTrackerType.Center;

        [SerializeField]
        Transform rotation = null;

        public Vector3 LocalPosition { get { return transform.localPosition; } }
        public Quaternion LocalRotation
        {
            get
            {
                if(rotation == null) {
                    return transform.localRotation;
                }
                var q = transform.localRotation * rotation.localRotation;
                return q;
            }
        }

        public Vector3 WorldPosition { get { return transform.position; } }
        public Quaternion WorldRotation { get { return rotation.rotation; } }

        private void Awake() {
            trackers[(int)type] = this;
        }

        private void OnDestroy() {
            trackers[(int)type] = null;
        }
    }
}
