using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour {

    //==============================================================================================//
    //==============================================================================================//

    public static CookieSpawner Instance { get; private set; }
    public List<ObjectPool> CookiePools;

    private float _time;

    //==============================================================================================//
    //==============================================================================================//

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        _time += Time.deltaTime;
        if (_time < GameSettings.Instance.CookieCooldown) return;
        LaunchCookie();
        _time = 0;
    }

    //==============================================================================================//
    //==============================================================================================//

    public void LaunchCookie() {
        float randomNumber = Random.Range(0, 100);
        if (randomNumber > GameSettings.Instance.MultishotChance) {
            LaunchSingleCookie();
        } else StartCoroutine(LaunchMultipleCookies());
    }

    void LaunchSingleCookie() {
        ObjectPool cookiePool = PickRandomOwnedCookiePool();
        GameObject cookie = cookiePool.GetObject();
        cookie.transform.SetParent(transform);
        cookiePool.ReturnAfter(cookie, 5f);
    }

    IEnumerator LaunchMultipleCookies() {
        LaunchSingleCookie();
        yield return new WaitForSeconds(0.1f);
        LaunchSingleCookie();
    }

    ObjectPool PickRandomOwnedCookiePool() {
        List<CookieType> ownedCookies = DataService.Instance.Data.OwnedCookie;
        int randomIndex = Random.Range(0, ownedCookies.Count);
        CookieType cookieType = ownedCookies[randomIndex];
        return CookiePools[(int) cookieType];
    }
    
    //==============================================================================================//
    //==============================================================================================//
}
