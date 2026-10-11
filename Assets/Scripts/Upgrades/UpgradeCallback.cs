using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeCallback", menuName = "Scriptable Objects/Upgrade Callback")]
public class UpgradeCallback : ScriptableObject {

    public void OnBatterUpgraded(Upgrade self) {
        GameSettings gs = GameSettings.Instance;
        DataService ds = DataService.Instance;

        gs.CookieCooldown -= gs.CookieCooldownDecreaseRate;
        ds.Data.UpgradesLevel[(int) UpgradeType.Batter] = self.CurrentLevel;
        Debug.Log("Current Level: " + ds.Data.UpgradesLevel[(int) UpgradeType.Batter]);
    }

    public void OnBatchUpgraded(Upgrade self) {
        GameSettings gs = GameSettings.Instance;
        DataService ds = DataService.Instance;

        gs.MultishotChance += gs.MultishotChanceIncreaseRate;
        ds.Data.UpgradesLevel[(int) UpgradeType.Batch] = self.CurrentLevel;
    }

    public void OnGlazeUpgraded(Upgrade self) {
        GameSettings gs = GameSettings.Instance;
        DataService ds = DataService.Instance;

        gs.GoldenBookieChance += gs.GoldenBookieChanceIncreaseRate;
        ds.Data.UpgradesLevel[(int) UpgradeType.Glaze] = self.CurrentLevel;
    }

    public void OnOvenspreadUpgraded(Upgrade self) {
        GameSettings gs = GameSettings.Instance;
        DataService ds = DataService.Instance;

        gs.ShootingRadius = gs.ShootingRadiusChanceIncreaseRate;
        ds.Data.UpgradesLevel[(int) UpgradeType.Ovenspread] = self.CurrentLevel;
    }
}
