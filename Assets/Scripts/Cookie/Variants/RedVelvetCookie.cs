using UnityEngine;

[CreateAssetMenu(menuName = "Cookie Ability/Red Velvet Cookie")]
public class RedVelvetCookie : CookieVariant {

    //==============================================================================================//
    //==============================================================================================//

    public Sprite RedVelvetCookieSprite;
    public Sprite DoubleChocolateCookieSprite;
    public Sprite ChocolateChipCookieSprite;

    //==============================================================================================//
    //==============================================================================================//

    override public void Activate(Cookie self) {
        SpriteRenderer spriteRenderer = self.GetComponent<SpriteRenderer>();
        ObjectPool CookiePool = GetCookiePool(self);
    
        self.Health -= 1;
        if (self.Health == 2) {
            spriteRenderer.sprite = DoubleChocolateCookieSprite;
        } else if (self.Health == 1) {
            spriteRenderer.sprite = ChocolateChipCookieSprite;
        } else {
            spriteRenderer.sprite = RedVelvetCookieSprite;
            CookiePool.ReturnObject(self.gameObject);
            self.SpawnBookies();
        } 
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
