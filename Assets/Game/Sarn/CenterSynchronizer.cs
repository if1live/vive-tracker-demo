using UnityEngine;

namespace Assets.Game.Sarn {
    /// <summary>
    /// center에 대응되는 vive tracker가 (0,0,0)을 가리키도록 강제 고정
    /// </summary>
    class CenterSynchronizer : MonoBehaviour {
        private void Update() {
            var trackerTr = ViveTracker.Get(ViveTrackerType.Center);
            if (trackerTr == null) { return; }

            var center = SingletonHolder<SteamVR_ControllerManager>.Instance.Value;
            if (center == null) { return; }
            var centerTr = center.transform;

            var trackerPos = trackerTr.WorldPosition;

            var centerLocalPos = centerTr.localPosition;
            var nextCenterLocalPos = centerLocalPos - trackerPos;

            centerTr.localPosition = nextCenterLocalPos;
        }
    }
}
