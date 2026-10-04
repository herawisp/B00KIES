using System.Collections.Generic;
using UnityEngine;

public class ScreenUtils {

    public enum ScreenPosition {Left, Right, Top, Bottom, Middle}

    static readonly Dictionary<ScreenPosition, Vector3> _cache = new();
    
    static Vector3 ScreenToWorld(float x, float y) {
        float depth = - Camera.main.transform.position.z;    
        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, depth));
    }

    public static Vector3 GetMiddleScreenWorldPosition() {
        if (_cache.TryGetValue(ScreenPosition.Middle, out Vector3 value)) return value;
        Vector3 middleWorldPosition = ScreenToWorld(Screen.width / 2f, Screen.height / 2f);
        _cache[ScreenPosition.Middle] = middleWorldPosition;
        return middleWorldPosition;
    }

    public static Vector3 GetTopScreenWorldPosition() {
        if (_cache.TryGetValue(ScreenPosition.Top, out Vector3 value)) return value;
        Vector3 topWorldPosition = ScreenToWorld(Screen.width / 2f, Screen.height);
        _cache[ScreenPosition.Top] = topWorldPosition;
        return topWorldPosition;
    }

    public static Vector3 GetBottomScreenWorldPosition() {
        if (_cache.TryGetValue(ScreenPosition.Bottom, out Vector3 value)) return value;
        Vector3 bottomWorldPosition = ScreenToWorld(Screen.width / 2f, 0);
        _cache[ScreenPosition.Bottom] = bottomWorldPosition;
        return bottomWorldPosition;
    }

    public static Vector3 GetLeftScreenWorldPosition() {
        if (_cache.TryGetValue(ScreenPosition.Left, out Vector3 value)) return value;
        Vector3 leftWorldPosition = ScreenToWorld(0, Screen.height / 2f);
        _cache[ScreenPosition.Left] = leftWorldPosition;
        return leftWorldPosition;
    }

    public static Vector3 GetRightScreenWorldPosition() {
        if (_cache.TryGetValue(ScreenPosition.Right, out Vector3 value)) return value;
        Vector3 rightWorldPosition = ScreenToWorld(Screen.width, Screen.height / 2f);
        _cache[ScreenPosition.Right] = rightWorldPosition;
        return rightWorldPosition;
    }

    public static (Vector3, Vector3) GetVerticalScreenWorldPosition() {
        return (GetTopScreenWorldPosition(), GetBottomScreenWorldPosition());
    }

    public static (Vector3, Vector3) GetHorizontalScreenWorldPosition() {
        return (GetLeftScreenWorldPosition(), GetRightScreenWorldPosition());
    }

    public static (float, float) GetScreenSizeWorldPosition() {
        (Vector3 top, Vector3 bottom) = GetVerticalScreenWorldPosition();
        (Vector3 left, Vector3 right) = GetHorizontalScreenWorldPosition();
        return (Mathf.Abs(left.x - right.x), Mathf.Abs(top.y - bottom.y));
    }
}
