using DG.Tweening;
using UnityEngine;

public class Ghost : MonoBehaviour {

    //==============================================================================================//
    //==============================================================================================//

    public Bookie Bookie;

    private Animator _animator;

    //==============================================================================================//
    //==============================================================================================//

    void Awake() {
        _animator = GetComponent<Animator>();
    }

    void Start() {
        _animator.SetBool("IsGolden", Bookie.Golden);
    }

    //==============================================================================================//
    //==============================================================================================//

    public void Spawn() {
        float ghostSpawnDirection = GameSettings.Instance.GhostSpawnDistance;
        float ghostMovingDuration = GameSettings.Instance.GhostMovingDuration;

        transform.position = Bookie.transform.position + (Vector3) Random.onUnitCircle * ghostSpawnDirection;
        transform.localScale = Bookie.transform.localScale;
        transform.DOMove(Bookie.transform.position, ghostMovingDuration)
            .SetLink(gameObject)
            .OnComplete(() => { OnMovingFinished(); });
    }

    //==============================================================================================//
    //==============================================================================================//
    
    void OnMovingFinished() {
        Destroy(Bookie.gameObject); // TODO: Setup Bookie ObjectPool
        _animator.SetBool("IsEating", true);
    }

    void OnExploded() {
        Destroy(gameObject);
        CurrencyService.Instance.AdjustCoins(1); // TODO: Code the coin yield amount
    }

    //==============================================================================================//
    //==============================================================================================//
}
