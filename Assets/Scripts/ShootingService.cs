using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingService : MonoBehaviour {
    
    public EnvironmentUI EnvironmentUI;
    public RectTransform Indicator;

    void Update()
    {
    //     float diameter = GameSettings.Instance.ShootingRadius * 2f;
    // Indicator.sizeDelta = Vector2.one * diameter / Indicator.lossyScale.x;

    //         Vector2 screenPos = Mouse.current.position.ReadValue();
    //         Vector3 worldPos = Camera.main.ScreenToWorldPoint(
    //             new Vector3(screenPos.x, screenPos.y, Mathf.Abs(Camera.main.transform.position.z)));
    //         worldPos.z = 0; // keep it on the 2D plane
    //         Indicator.position = worldPos;
    }
    void OnShoot(InputValue value) {
        if (!value.isPressed) return;
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, GameSettings.Instance.ShootingRadius);
        foreach (Collider2D hit in hits) {
            Cookie cookie = hit.GetComponent<Cookie>();
            cookie.CookieAbility.Activate(cookie);
            EnvironmentUI.Shake();
        }
    }
    
//     void OnApplicationFocus(bool hasFocus)
// {
//     if (hasFocus) Cursor.visible = false;
// }
}
