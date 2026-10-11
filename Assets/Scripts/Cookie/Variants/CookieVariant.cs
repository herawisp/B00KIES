using UnityEngine;

public abstract class CookieVariant : ScriptableObject {
    
    //==============================================================================================//
    //==============================================================================================//
    
    public Sprite Sprite;
    public CookieType CookieType;
    public string DisplayName;
    public string Description;
    public int Cost;
    
    public virtual void OnCookieSpawned(Cookie self) {}
    public abstract void Activate(Cookie self);

    //==============================================================================================//
    //==============================================================================================//

    protected ObjectPool GetCookiePool(Cookie self) {
        return CookieSpawner.Instance.CookiePools[(int) self.CookieType];
    }

    protected ObjectPool GetCookiePool(CookieType cookieType) {
        return CookieSpawner.Instance.CookiePools[(int) cookieType];
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
