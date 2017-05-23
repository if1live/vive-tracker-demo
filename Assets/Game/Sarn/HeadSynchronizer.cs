using UnityEngine;

namespace Assets.Game.Sarn {
    class HeadSynchronizer : MonoBehaviour {
        public Transform headTr = null;

        [SerializeField]
        Vector3 _offset = Vector3.zero;
        public Vector3 Offset
        {
            get { return _offset; }
        }

        private void Update() {
            var trackerTr = ViveTracker.Get(ViveTrackerType.Head);
            if(trackerTr == null) { return; }

            var pos = trackerTr.WorldPosition;

            // 트래커의 좌표와 머리 위치가 일치하지 않도록 하고싶을때
            // 좌표를 조정
            var q = trackerTr.WorldRotation;
            var m = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
            var right = m.MultiplyVector(Vector3.right);
            var up = m.MultiplyVector(Vector3.up);
            var forward = m.MultiplyVector(Vector3.forward);

            var offset = Offset;
            pos += right * offset.x;
            pos += up * offset.y;
            pos += forward * offset.z;

            headTr.position = pos;
            headTr.rotation = trackerTr.WorldRotation;
        }
    }
}
