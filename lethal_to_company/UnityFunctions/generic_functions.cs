using System;
using UnityEngine;

namespace lethal_to_company
{
    partial class hack : MonoBehaviour
    {
        private bool vector3_in_range(Vector3 point1, Vector3 point2, float tolerance)
        { // Compares two 3D points relative to each other within a tolerance
            return Vector3.Distance(point1, point2) <= tolerance;
        }
        
        private bool is_visible(GameObject target, Vector3 origin, LayerMask mask)
        { // Casts a ray to an object and returns true if the target object is hit
            Ray ray = new Ray(origin, (target.transform.position - origin).normalized);
            if (Physics.Raycast(ray, out RaycastHit hit,Single.PositiveInfinity, mask))
            {
                if (hit.collider.gameObject == target)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        
        private GameObject raycast_to_point(Vector3 pos, Vector3 origin, LayerMask mask )
        { // Casts a ray between two points and returns the first GameObject between them, from the origin side.
            Ray ray = new Ray(origin, (pos - origin).normalized);

            if (Physics.Raycast(ray, out RaycastHit hit,Single.PositiveInfinity, mask))
            {
                return hit.collider.gameObject;
            }
            return new GameObject("No Object");
        }
    }
}