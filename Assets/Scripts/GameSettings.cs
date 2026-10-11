using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject {
    
    //==============================================================================================//
    //==============================================================================================//

    [Header("Upgrades Settings")]
    public float CookieCooldown;
    public float MultishotChance;
    public float GoldenBookieChance;
    public float ShootingRadius;

    public float BaseCookieCooldown;
    public float BaseMultishotChance;
    public float BaseGoldenBookieChance;
    public float BaseShootingRadius;


    public float CookieCooldownDecreaseRate;
    public float MultishotChanceIncreaseRate;
    public float GoldenBookieChanceIncreaseRate;
    public float ShootingRadiusChanceIncreaseRate;

    [Header("Prefabs")]
    public GameObject BookiePrefab;
    public Ghost GhostPrefab;

    [Header("Bookie")]
    public float BookieSpawnDistance = 2f;
    public float BookieMovingDuration = 0.5f;
    
    [Header("Ghost")]
    public float GhostSpawnDistance = 2f;
    public float GhostMovingDuration = 0.5f;

    [Header("Shake")]
    public float ShakeDuration = 0.2f;
    public float ShakeMagnitude = 2.5f;

    [Header("Upgrades")]
    public Upgrade BatterUpgrade;
    public Upgrade BatchUpgrade;
    public Upgrade GlazeUpgrade;
    public Upgrade CutterUpgrade;
    public Upgrade OvenspreadUpgrade;
    
    //==============================================================================================//
    //==============================================================================================//

    static GameSettings _instance;
    public static GameSettings Instance {
        get {
            if (_instance == null)
                _instance = Resources.Load<GameSettings>("GameSettings");
            return _instance;
        }
    }
    //==============================================================================================//
    //==============================================================================================//
}
