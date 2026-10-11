using System.Collections.Generic;
using UnityEngine;

public class CookieVariantService : MonoBehaviour {

    public List<CookieVariant> CookieVariants;

    public static CookieVariantService Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UnlockCookieVariant(CookieType cookieType) {
        int cookieCost = CookieVariants[(int) cookieType].Cost;
        bool hasEnoughCoins = CurrencyService.Instance.HaveEnoughCoins(cookieCost);
        if (!hasEnoughCoins) return;

        CurrencyService.Instance.AdjustCoins(-cookieCost);
        List<CookieType> ownedCookie = DataService.Instance.Data.OwnedCookie;
        ownedCookie.Add(cookieType);
    }

    public bool HaveCookieVariant(CookieType cookieType) {
        List<CookieType> ownedCookie = DataService.Instance.Data.OwnedCookie;
        return ownedCookie.Contains(cookieType);
    }
}
