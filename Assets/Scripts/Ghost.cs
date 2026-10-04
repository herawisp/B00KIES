using DG.Tweening;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public Transform Bookie;

    public void Spawn() {
        transform.position = Bookie.position + (Vector3) Random.onUnitCircle * 3f;
        transform.localScale = Bookie.localScale;
        transform.DOMove(Bookie.position, 0.5f)
            .SetLink(gameObject)
            .OnComplete(() => {
                Destroy(Bookie.gameObject);
                CurrencyService.Instance.AdjustCoins(1);
                Destroy(gameObject, 2f);
            });
    }
}
