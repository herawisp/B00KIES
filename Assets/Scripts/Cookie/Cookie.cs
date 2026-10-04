using DG.Tweening;
using UnityEngine;

public class Cookie : MonoBehaviour {

    public float SpeedMultiplier = 1f;
    public GameObject BookiePrefab;
    public Ghost GhostPrefab;
    public bool Shot;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable() {
        Shot = false;
        Reset();
        Launch();
    }

    void OnDisable() {
        if (Shot) SpawnBookies();
        Reset();
    }

    public void Launch() {
        (Vector3 leftPosition, Vector3 rightPosition) = ScreenUtils.GetHorizontalScreenWorldPosition();
        Vector3 bottomPosition = ScreenUtils.GetBottomScreenWorldPosition();
        (float screenSizeX, float screenSizeY) = ScreenUtils.GetScreenSizeWorldPosition();

        int randomNum = Random.Range(1, 3);
        float randomXPosition;
        
        int direction = 1;

        if (randomNum == 1) {
            randomXPosition = leftPosition.x + Random.Range(0, screenSizeX / 3);
        } else {
            randomXPosition = rightPosition.x - Random.Range(0, screenSizeX / 3);
            direction = -1;
        }

        Vector3 spawnPosition = new(randomXPosition, bottomPosition.y, 0);
        transform.position = spawnPosition;

        (float width, float height) = (
            Random.Range(screenSizeX / 3, screenSizeX / 3 * 2), 
            Random.Range(screenSizeY / 2, screenSizeY - _spriteRenderer.bounds.size.y / 2)
        );

        float g = - Physics2D.gravity.y;
        float vy = Mathf.Sqrt(2 * g * height);
        float vx = width * Mathf.Sqrt(g / (8 * height));

        _rigidbody2D.gravityScale = SpeedMultiplier * SpeedMultiplier;
        _rigidbody2D.linearVelocity = new Vector2(vx * direction, vy) * SpeedMultiplier;
        transform.DOScale(0.1f, 5f);
    }

    public void Reset() {
        transform.DOKill();   
        transform.localScale = new(2, 2, 2);
        transform.rotation = Quaternion.identity;
        _rigidbody2D.linearVelocity = new();
        _rigidbody2D.angularVelocity = 0f;
    }

    public void SpawnBookies() {
        GameObject bookie = Instantiate(BookiePrefab, transform.position, Quaternion.identity);
        bookie.transform.localScale = transform.localScale;
        bookie.transform.DOMove(transform.position + (Vector3) Random.onUnitCircle * 2f, 0.5f)
            .SetLink(gameObject)
            .OnComplete(() => {
                Ghost ghost = Instantiate(GhostPrefab);
                ghost.Bookie = bookie.transform;
                ghost.Spawn();
            });
    }
}
