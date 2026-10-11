using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookieVariantCard : MonoBehaviour {

    public Image Image;
    public GameObject BooCoinImage;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI BuyText;
    public Button BuyButton;
    public CookieVariant CookieVariant;

    void Start() {
        BuyButton.onClick.AddListener(OnBuyClicked);
        UpdateUI();
    }

    void UpdateUI() {
        Image.sprite = CookieVariant.Sprite;
        TitleText.text = CookieVariant.DisplayName;
        DescriptionText.text = CookieVariant.Description;

        bool owned = CookieVariantService.Instance.HaveCookieVariant(CookieVariant.CookieType);
        BuyText.text = owned ? "Owned" : CookieVariant.Cost.ToString();
        BuyButton.interactable = !owned;
        BooCoinImage.SetActive(!owned);
    }

    void OnBuyClicked() {
        CookieVariantService.Instance.UnlockCookieVariant(CookieVariant.CookieType);
        UpdateUI();
    }
}
