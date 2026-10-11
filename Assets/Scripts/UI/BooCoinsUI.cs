using TMPro;
using UnityEngine;

public class BooCoinsUI : MonoBehaviour {
    
    //==============================================================================================//
    //==============================================================================================//
    
    public TextMeshProUGUI BooCoinsAmountText;

    //==============================================================================================//
    //==============================================================================================//

    void Start() {
        CurrencyService.Instance.OnCoinsChanged += UpdateText;
        UpdateText();
    }

    void UpdateText() {
        int currentBooCoins = DataService.Instance.Data.Coins;
        BooCoinsAmountText.text = currentBooCoins.ToString();
    }

    //==============================================================================================//
    //==============================================================================================//
}
