using DG.Tweening;
using UnityEngine;

public class Cookie : MonoBehaviour {

    //==============================================================================================//
    //==============================================================================================//

    public float SpeedMultiplier = 2f;
    public int Health;
    public int MaxHealth;

    public CookieVariant CookieAbility;
    public CookieType CookieType;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    //==============================================================================================//
    //==============================================================================================//

    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable() {
        Reset();
        CookieAbility.OnCookieSpawned(this);
        Launch();
    }
    
    //==============================================================================================//
    //==============================================================================================//

    public void Launch() {
        (Vector3 spawnPosition, int direction) = GetRandomPositionAndDirection();
        Vector2 launchDirection = GetCookieLinearVelocity(direction);

        transform.position = spawnPosition;
        _rigidbody2D.gravityScale = SpeedMultiplier * SpeedMultiplier;
        _rigidbody2D.linearVelocity = launchDirection * SpeedMultiplier;
        transform.DOScale(0.1f, 5f / SpeedMultiplier);
    }

    public void Reset() {
        Health = MaxHealth;
        transform.DOKill();   
        transform.localScale = new(2, 2, 2);
        transform.rotation = Quaternion.identity;
        _rigidbody2D.linearVelocity = new();
        _rigidbody2D.angularVelocity = 0f;
    }

    public void SpawnBookies() {
        GameObject bookiePrefab = GameSettings.Instance.BookiePrefab;
        GameObject bookie = Instantiate(bookiePrefab, transform.position, Quaternion.identity);
        bookie.transform.localScale = transform.localScale;
        Reset();
    }

    //==============================================================================================//
    //==============================================================================================//

    (Vector3, int) GetRandomPositionAndDirection() {
        (Vector3 leftPosition, Vector3 rightPosition) = ScreenUtils.GetHorizontalScreenWorldPosition();
        Vector3 bottomPosition = ScreenUtils.GetBottomScreenWorldPosition();
        (float screenSizeX, _) = ScreenUtils.GetScreenSizeWorldPosition();

        int randomNum = Random.Range(1, 3);
        float randomXPosition;
        int direction = 1;

        if (randomNum == 1) {
            randomXPosition = leftPosition.x + Random.Range(0, screenSizeX / 3);
        } else {
            randomXPosition = rightPosition.x - Random.Range(0, screenSizeX / 3);
            direction = -1;
        }

        _spriteRenderer.flipX = direction == 1;
        Vector3 spawnPosition = new(randomXPosition, bottomPosition.y, 0);
        return (spawnPosition, direction);
    }

    Vector2 GetCookieLinearVelocity(int direction) {
        (float screenSizeX, float screenSizeY) = ScreenUtils.GetScreenSizeWorldPosition();

        (float width, float height) = (
            Random.Range(screenSizeX / 3, screenSizeX / 3 * 2), 
            Random.Range(screenSizeY / 2, screenSizeY - _spriteRenderer.bounds.size.y / 2)
        );

        float g = - Physics2D.gravity.y;
        float vy = Mathf.Sqrt(2 * g * height);
        float vx = width * Mathf.Sqrt(g / (8 * height));

        return new Vector2(vx * direction, vy);
    }

    //==============================================================================================//
    //==============================================================================================//
}
