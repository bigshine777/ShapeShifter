using Unity.VisualScripting;
using UnityEngine;

public class SquareStage : MonoBehaviour
{
    [SerializeField] public Sprite _targetSprite;
    [SerializeField] private float fallSpeed;
    private Player _player;
    private bool _shouldFall;

    void Start()
    {
        _shouldFall = false;
        _player = FindAnyObjectByType<Player>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        _Fall();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (spriteRenderer && spriteRenderer.sprite == _targetSprite)
            {
                _shouldFall = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        _shouldFall = false;
    }

    private void _Fall()
    {
        if (!_shouldFall) return;
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        _player.transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
}
