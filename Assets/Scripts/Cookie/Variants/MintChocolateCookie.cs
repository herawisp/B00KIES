using UnityEngine;

[CreateAssetMenu(menuName = "Cookie Ability/Mint Chocolate Cookie")]
public class MintChocolateCookie : CookieVariant {

    //==============================================================================================//
    //==============================================================================================//

    override public void Activate(Cookie self) {
        CookieSpawner.Instance.LaunchCookie();
        ObjectPool CookiePool = GetCookiePool(self);
        CookiePool.ReturnObject(self.gameObject);
        self.SpawnBookies();
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
