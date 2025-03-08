using UnityEngine;

public class GateManager : MonoBehaviour
{
    private Player _player;
    [SerializeField] private Sprite _allowedSprite;
    [SerializeField] private float _resistPower;
    private bool _hasPassedGate;

    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _hasPassedGate = false;
    }

    void Update()
    {
        _JudgeShape();
    }

    private void _JudgeShape()
    {
        if (_hasPassedGate || !_player) return;

        if (_player.transform.position.x > transform.position.x)
        {
            SpriteRenderer currentRenderer = _player.GetComponent<SpriteRenderer>();

            if (currentRenderer.sprite == _allowedSprite)
            {
                _hasPassedGate = true;
            }
            else
            {
                _player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * _resistPower, ForceMode2D.Impulse);
            }
        }
    }
}
