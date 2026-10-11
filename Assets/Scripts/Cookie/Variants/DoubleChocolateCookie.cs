using UnityEngine;

[CreateAssetMenu(menuName = "Cookie Ability/Double Chocolate Cookie")]
public class DoubleChocolateCookie : CookieVariant {

    //==============================================================================================//
    //==============================================================================================//

    public Sprite DoubleChocolateCookieSprite;
    public Sprite ChocolateChipCookieSprite;

    //==============================================================================================//
    //==============================================================================================//

    override public void Activate(Cookie self) {
        SpriteRenderer spriteRenderer = self.GetComponent<SpriteRenderer>();
        ObjectPool CookiePool = GetCookiePool(self);
    
        self.Health -= 1;
        if (self.Health == 1) {
            spriteRenderer.sprite = ChocolateChipCookieSprite;
        } else {
            spriteRenderer.sprite = DoubleChocolateCookieSprite;
            CookiePool.ReturnObject(self.gameObject);
            self.SpawnBookies();
        } 
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
