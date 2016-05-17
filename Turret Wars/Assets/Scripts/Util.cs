using UnityEngine;
using System.Collections;

public static class Util {

    /// <summary>
    /// Returns a random world point inside the given BoxCollider
    /// </summary>
    public static Vector3 GetPointInCollider(this BoxCollider area)
    {
        var bounds = area.bounds;
        var center = bounds.center;

        var x = UnityEngine.Random.Range(center.x - bounds.extents.x, center.x + bounds.extents.x);
        var z = UnityEngine.Random.Range(center.z - bounds.extents.z, center.z + bounds.extents.z);

        return new Vector3(x, 0, z);
    }
}
