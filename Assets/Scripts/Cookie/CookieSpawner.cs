using UnityEngine;

public class CookieSpawner : MonoBehaviour {
    
    public float Cooldown;

    public ObjectPool CookiePool;
    public Transform Target;
    public float minimumHeight;
    public float maximumHeight;
    public float minimumWidth;
    public float maximumWidth;

    float _time;

    void Update() {
        _time += Time.deltaTime;
        if (_time < Cooldown) return;
        LaunchCookie();
        _time = 0;
    }

    void LaunchCookie() {
        GameObject cookie = CookiePool.GetObject();
        CookiePool.ReturnAfter(cookie, 5f);
    }

}
