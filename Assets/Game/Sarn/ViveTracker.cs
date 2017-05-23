using UnityEngine;

namespace Assets.Game.Sarn {
    public class ViveTracker : MonoBehaviour {
        static ViveTracker[] trackers = new ViveTracker[2];
        public static Transform Get(ViveTrackerType t) {
            var tracker = trackers[(int)t];
            if(tracker == null) {
                return null;
            } else {
                return tracker.GetTransform();
            }
        }

        [SerializeField]
        ViveTrackerType type = ViveTrackerType.Center;

        [SerializeField]
        Transform child = null;

        Transform GetTransform() {
            if(child != null) {
                return child;
            } else {
                return transform;
            }
        }

        private void Awake() {
            trackers[(int)type] = this;
        }

        private void OnDestroy() {
            trackers[(int)type] = null;
        }
    }
}
