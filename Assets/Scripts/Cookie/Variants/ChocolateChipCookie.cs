using UnityEngine;

[CreateAssetMenu(menuName = "Cookie Ability/Chocolate Chip Cookie")]
public class ChocolateChipCookie : CookieVariant {

    //==============================================================================================//
    //==============================================================================================//
    
    public override void Activate(Cookie self) {
        ObjectPool CookiePool = GetCookiePool(self);
        CookiePool.ReturnObject(self.gameObject);
        self.SpawnBookies();
    }

    //==============================================================================================//
    //==============================================================================================//
}
