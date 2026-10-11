using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    //==============================================================================================//
    //==============================================================================================//

    public List<GameObject> prefabs;

    private readonly Queue<GameObject> pool = new();
    private readonly HashSet<GameObject> pooled = new();
    private readonly Dictionary<GameObject, Coroutine> pendingReturns = new();

    //==============================================================================================//
    //==============================================================================================//

    void Start() {
        if (prefabs.Count == 1) return;
        foreach (GameObject prefab in prefabs) {
            ReturnObject(Instantiate(prefab));
        }
    }

    //==============================================================================================//
    //==============================================================================================//

    public GameObject GetObject() {
        if (pool.Count > 0) {
            GameObject obj = pool.Dequeue();
            pooled.Remove(obj);
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(PickRandomPrefab());
    }

    public void ReturnObject(GameObject obj) {
        if (!pooled.Add(obj)) {
            Debug.LogWarning($"{obj.name} was returned twice or re-enabled outside the pool", obj);
            return;
        }
        CancelPendingReturn(obj);
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public void ReturnAfter(GameObject obj, float time) {
        CancelPendingReturn(obj);
        pendingReturns[obj] = StartCoroutine(ReturnLaterRoutine(obj, time));
    }

    //==============================================================================================//
    //==============================================================================================//

    IEnumerator ReturnLaterRoutine(GameObject obj, float time) {
        yield return new WaitForSeconds(time);
        pendingReturns.Remove(obj);
        ReturnObject(obj);
    }

    void CancelPendingReturn(GameObject obj) {
        if (pendingReturns.Remove(obj, out Coroutine routine)) StopCoroutine(routine);
    }

    GameObject PickRandomPrefab() {
        if (prefabs.Count == 1) return prefabs[0];
        return prefabs[Random.Range(0, prefabs.Count)];
    }
    
    //==============================================================================================//
    //==============================================================================================//
}