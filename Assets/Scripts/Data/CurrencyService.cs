
using System;
using UnityEngine;

public class CurrencyService : MonoBehaviour {
    
    //==============================================================================================//
    //==============================================================================================//

    public event Action OnCoinsChanged;

    //==============================================================================================//
    //==============================================================================================//
    
    public static CurrencyService Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //==============================================================================================//
    //==============================================================================================//

    public void AdjustCoins(int amount) {
        DataService.Instance.Data.Coins += amount;
        OnCoinsChanged?.Invoke();
    }

    public bool HaveEnoughCoins(int amount) {
        return DataService.Instance.Data.Coins >= amount;
    }

    //==============================================================================================//
    //==============================================================================================//
}