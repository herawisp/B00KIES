using UnityEngine;

[CreateAssetMenu(menuName = "Cookie Ability/Sugar Cookie")]
public class SugarCookie : CookieVariant {

    //==============================================================================================//
    //==============================================================================================//

    public override void OnCookieSpawned(Cookie self) {
        self.SpeedMultiplier = 4f;
    }

    public override void Activate(Cookie self) {
        ObjectPool CookiePool = GetCookiePool(self);
        CookiePool.ReturnObject(self.gameObject);
        self.SpawnBookies();
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
