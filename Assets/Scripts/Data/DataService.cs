using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DataService : MonoBehaviour {
    
    //==============================================================================================//
    //==============================================================================================//

    public SaveData Data => _saveData ??= LoadData();

    string _saveFilePath;
    SaveData _saveData;

    //==============================================================================================//
    //==============================================================================================//
    
    public static DataService Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _saveFilePath = Application.persistentDataPath + "/data.json";
        LoadUpgrades();
    }

    //==============================================================================================//
    //==============================================================================================//
    
    public void Save() {
        string jsonText = JsonUtility.ToJson(Data);
        Debug.Log(Data.UpgradesLevel[0]);
        File.WriteAllText(_saveFilePath, jsonText);
    }

    SaveData LoadData() {
        if (File.Exists(_saveFilePath)) {
            string jsonText = File.ReadAllText(_saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonText);
            Debug.Log(data.OwnedCookie[0]);
            if (data != null) return data;
        }
        return new SaveData();
    }

    void LoadUpgrades() {
        GameSettings gs = GameSettings.Instance;
        gs.BatterUpgrade.CurrentLevel = Data.UpgradesLevel[(int) UpgradeType.Batter]; 
        gs.BatchUpgrade.CurrentLevel = Data.UpgradesLevel[(int) UpgradeType.Batch]; 
        gs.GlazeUpgrade.CurrentLevel = Data.UpgradesLevel[(int) UpgradeType.Glaze]; 
        gs.CutterUpgrade.CurrentLevel = Data.UpgradesLevel[(int) UpgradeType.Cutter]; 
        gs.OvenspreadUpgrade.CurrentLevel = Data.UpgradesLevel[(int) UpgradeType.Ovenspread]; 

        gs.CookieCooldown = gs.BaseCookieCooldown - (gs.CookieCooldownDecreaseRate * gs.BatterUpgrade.CurrentLevel);
        gs.MultishotChance = gs.BaseMultishotChance + (gs.MultishotChanceIncreaseRate * gs.BatchUpgrade.CurrentLevel);
        gs.GoldenBookieChance = gs.BaseGoldenBookieChance + (gs.GoldenBookieChanceIncreaseRate * gs.GlazeUpgrade.CurrentLevel);
        gs.ShootingRadius = gs.BaseShootingRadius + (gs.ShootingRadiusChanceIncreaseRate * gs.OvenspreadUpgrade.CurrentLevel);
    }

    //==============================================================================================//
    //==============================================================================================//

    void OnApplicationPause(bool pause) {
        if (pause) Save();
    }

    void OnApplicationQuit() {
        Save();
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
