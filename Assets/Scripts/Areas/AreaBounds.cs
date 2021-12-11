namespace Victor.Agents.Areas
{
    using Scenes.Scripts;
    using UnityEngine;

    public class AreaBounds : MonoBehaviour
    {
        [SerializeField]
        private Transform lowerLeftBound;

        [SerializeField]
        private Transform upperRightBound;

        [SerializeField]
        private GameObject boundPrefab;

        private Vector3 Center => lowerLeftBound.position + Extend * 0.5f;

        private Vector3 Extend => upperRightBound.position - lowerLeftBound.position;

        public void CreateBounds()
        {
            CreateLeftBound();
            CreateUpperBound();
            CreateRightBound();
            CreateLowerBound();
        }

        private void CreateLeftBound()
        {
            var position = new Vector3(lowerLeftBound.position.x, 0, Center.z);
            var rotation = Quaternion.Euler(0, 90, 0);
            CreateBound(position, rotation, Extend.z);
        }

        private void CreateUpperBound()
        {
            var position = new Vector3(Center.x, 0, lowerLeftBound.position.z);
            var rotation = Quaternion.Euler(0, 0, 0);
            CreateBound(position, rotation, Extend.x);
        }

        private void CreateRightBound()
        {
            var position = new Vector3(upperRightBound.position.x, 0, Center.z);
            var rotation = Quaternion.Euler(0, -90, 0);
            CreateBound(position, rotation, Extend.z);
        }

        private void CreateLowerBound()
        {
            var position = new Vector3(Center.x, 0, upperRightBound.position.z);
            var rotation = Quaternion.Euler(0, 180, 0);
            CreateBound(position, rotation, Extend.x);
        }

        private void CreateBound(Vector3 position, Quaternion rotation, float scale)
        {
            var bound = Instantiate(boundPrefab, position, rotation, transform);
            bound.transform.localScale = new Vector3(scale, 1, 1);
        }

        private void OnDrawGizmos()
        {
            if (!lowerLeftBound || !upperRightBound) return;
            Gizmos.color = IsValid() ? Color.blue : Color.red;
            Gizmos.DrawWireCube(Center, Extend);
        }

        private bool IsValid()
        {
            var lpos = lowerLeftBound.position;
            var rpos = upperRightBound.position;
            return lpos.x < rpos.x && lpos.z < rpos.z;
        }

        public Vector3 GetRandomPoint()
        {
            var x = Random.Range(lowerLeftBound.position.x, upperRightBound.position.x);
            var z = Random.Range(lowerLeftBound.position.z, upperRightBound.position.z);
            return new Vector3(x, 0, z);
        }

        public bool IsInBounds(Vector2 position)
        {
            return (position.x > lowerLeftBound.position.x && position.y > lowerLeftBound.position.z &&
                    position.x < upperRightBound.position.x && position.y < upperRightBound.position.z);
        }
    }
}