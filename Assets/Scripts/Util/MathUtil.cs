using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtil {
    public static Vector3 Clamp(this Vector3 pos, Rect rect) {
        return new Vector3(
            Mathf.Clamp(pos.x, rect.xMin, rect.xMax),
            Mathf.Clamp(pos.y, rect.yMin, rect.yMax),
            pos.z);
    }

    public static Rect Expand(this Rect rect, float expand) {
        rect.xMin -= expand;
        rect.yMin -= expand;
        rect.xMax += expand;
        rect.yMax += expand;
        return rect;
    }
}
