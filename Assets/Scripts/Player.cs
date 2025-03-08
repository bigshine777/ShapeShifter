using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Sprite _squareSprite;
    [SerializeField] private Sprite _circleSprite;
    [SerializeField] private Sprite _triangleSprite;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private GameObject _goalPost;
    private BoxCollider2D _squareCollider;
    private CircleCollider2D _circleCollider;
    private PolygonCollider2D _triangleCollider;
    private Sprite _currentSprite;
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _currentCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentSprite = _squareSprite;
        _squareCollider = GetComponent<BoxCollider2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _triangleCollider = GetComponent<PolygonCollider2D>();
        _currentCollider = _squareCollider;
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerOutOfBounds();
    }

    public void ChangeCircle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _ChangeShape(_circleSprite, _circleCollider);
    }

    public void ChangeSquare(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _ChangeShape(_squareSprite, _squareCollider);
    }

    public void ChangeTriangle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (_currentSprite != _triangleSprite)
        {
            _Jump();
        }
        _ChangeShape(_triangleSprite, _triangleCollider);
    }

    private void _ChangeShape(Sprite sprite, Collider2D collider)
    {
        if (_currentSprite != sprite)
        {
            _spriteRenderer.sprite = sprite;
            _currentSprite = sprite;
        }

        if (_currentCollider != collider)
        {
            _currentCollider.enabled = false;
            collider.enabled = true;
            _currentCollider = collider;
        }
    }

    private RaycastHit2D _HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f, layerMask);
    }

    private void _Jump()
    {
        RaycastHit2D hit = _HitFloor();
        if (hit.collider != null)
        {
            _rigid.AddForce(hit.normal * _jumpSpeed, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }

    private void IsPlayerOutOfBounds()
    {
        Camera camera = Camera.main;
        Vector3 playerPosition = transform.position;
        Vector3 screenPoint = camera.WorldToViewportPoint(playerPosition);

        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            Destroy(gameObject);
        }
    }

    public bool IsPlayerGoal()
    {
        return transform.position.x > _goalPost.transform.position.x;
    }
}
