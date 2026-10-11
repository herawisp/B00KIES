using DG.Tweening;
using UnityEngine;

public class Bookie : MonoBehaviour {

    //==============================================================================================//
    //==============================================================================================//

    public Sprite BookieSprite;
    public Sprite GoldenBookieSprite;
    public bool Golden = false;

    private SpriteRenderer _spriteRenderer;

    //==============================================================================================//
    //==============================================================================================//

    void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        RollGolden();

        float bookieSpawnDistance = GameSettings.Instance.BookieSpawnDistance;
        float bookieMovingDuration = GameSettings.Instance.BookieMovingDuration;

        Vector3 position = transform.position + (Vector3) Random.onUnitCircle * bookieSpawnDistance;
        transform.DOMove(position, bookieMovingDuration)
            .SetLink(gameObject)
            .OnComplete(() => {SpawnGhost();});
    }

    //==============================================================================================//
    //==============================================================================================//

    void RollGolden() {
        int randomNum = Random.Range(0, 100);
        if (randomNum < GameSettings.Instance.GoldenBookieChance) Golden = true;
        _spriteRenderer.sprite = Golden ? GoldenBookieSprite : BookieSprite;
    }

    void SpawnGhost() {
        Ghost ghostPrefab = GameSettings.Instance.GhostPrefab;
        Ghost ghost = Instantiate(ghostPrefab);
        ghost.Bookie = this;
        ghost.transform.localScale = transform.localScale;
        // ghost.transform.SetParent(transform);
        ghost.Spawn();
    }

    //==============================================================================================//
    //==============================================================================================//
}
