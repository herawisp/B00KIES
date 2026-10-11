using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {

    //==============================================================================================//
    //==============================================================================================//

    [Header("Buttons")]
    public Button UpgradeTabButton;
    public Button CookieTabButton;

    [Header("Images")]
    public Image UpgradeTabImage;
    public Image CookieTabImage;
    public Sprite UpgradeTabSelectedSprite;
    public Sprite UpgradeTabUnselectedSprite;
    public Sprite CookieTabSelectedSprite;
    public Sprite CookieTabUnselectedSprite;

    [Header("Tab Panels")]
    public GameObject UpgradePanel;
    public GameObject CookiePanel;

    //==============================================================================================//
    //==============================================================================================//

    public void TriggerUpgradeTab() {
        if (UpgradePanel.activeInHierarchy) {
            UpgradeTabImage.sprite = UpgradeTabUnselectedSprite;
            UpgradePanel.SetActive(false);
        } else {
            UpgradeTabImage.sprite = UpgradeTabSelectedSprite;
            CookieTabImage.sprite = CookieTabUnselectedSprite;
            CookiePanel.SetActive(false);
            UpgradePanel.SetActive(true);
        }
    }

    public void TriggerCookieTab() {
        if (CookiePanel.activeInHierarchy) {
            CookieTabImage.sprite = CookieTabUnselectedSprite;
            CookiePanel.SetActive(false);
        } else {
            CookieTabImage.sprite = CookieTabSelectedSprite;
            UpgradeTabImage.sprite = UpgradeTabUnselectedSprite;
            UpgradePanel.SetActive(false);
            CookiePanel.SetActive(true);
        }
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
