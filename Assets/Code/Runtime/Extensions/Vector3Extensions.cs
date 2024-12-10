using UnityEngine;

namespace Code.Runtime.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 AddX(this Vector3 vector3, float x)
        {
            return vector3.SetX(vector3.x + x);
        }
    }
}