namespace Scenes.Scripts
{
    using UnityEngine;

    public static class Tools
    {
        public static Vector2 ToXZVector2(this Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }
        
        public static Vector3 ToXZVector3(this Vector2 v)
        {
            return new Vector3(v.x, 0, v.y);
        }
    }
}