using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
public class Upgrade : ScriptableObject {

    public string DisplayName;
    public string Description;
    public Sprite Sprite;

    public int CurrentLevel;
    public int MaxLevel;
    public float CostBase;
    public float GrowthRate;

    public UnityEvent OnUpgraded;

    public void UpgradeLevel() {
        int cost = GetCost();
        bool haveEnoughCoins = CurrencyService.Instance.HaveEnoughCoins(cost);

        if (CurrentLevel < MaxLevel && haveEnoughCoins) {
            CurrencyService.Instance.AdjustCoins(-cost);
            CurrentLevel++;
            OnUpgraded.Invoke();
        }
    }

    public int GetCost() {
        return Mathf.FloorToInt(CostBase * Mathf.Pow(GrowthRate, CurrentLevel));
    }
}
