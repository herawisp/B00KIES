using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour {

    public Image Image;
    public GameObject BooCoinImage;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI UpgradeText;
    public Button UpgradeButton;
    public Upgrade Upgrade;

    void Start() {
        UpgradeButton.onClick.AddListener(OnUpgradeClicked);
        UpdateUI();
    }

    void UpdateUI() {
        bool maxed = Upgrade.CurrentLevel >= Upgrade.MaxLevel;
        string levelText = maxed ? "MAX" : Upgrade.CurrentLevel.ToString();

        Image.sprite = Upgrade.Sprite;
        TitleText.text = $"{Upgrade.DisplayName} (Lv {levelText})";
        DescriptionText.text = Upgrade.Description;
        UpgradeButton.interactable = !maxed;
        UpgradeText.text = maxed ? "MAX" : Upgrade.GetCost().ToString();
        BooCoinImage.SetActive(!maxed);
    }

    void OnUpgradeClicked() {
        Upgrade.UpgradeLevel();
        UpdateUI();
    }
}
