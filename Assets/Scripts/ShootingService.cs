using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingService : MonoBehaviour {
    
    public ObjectPool CookiePool;
    public float HitRadius;

    void OnShoot(InputValue value) {
        if (!value.isPressed) return;
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, HitRadius);
        foreach (Collider2D hit in hits) {
            Cookie cookie = hit.GetComponent<Cookie>();
            cookie.Shot = true;
            CookiePool.ReturnObject(hit.gameObject);
        }
    }
}
