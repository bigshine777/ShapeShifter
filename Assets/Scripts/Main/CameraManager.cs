using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Vector2 _cameraPosition;
    private Player _player;
    private Vector3 _initPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _FollowPlayer();
    }

    private void _FollowPlayer()
    {
        if (!_player) return;
        float x = _player.transform.position.x;
        float y = _player.transform.position.y;
        x = Mathf.Clamp(x, _initPos.x - _cameraPosition.x, Mathf.Infinity);
        transform.position = new Vector3(x + _cameraPosition.x, y + _cameraPosition.y, transform.position.z);
    }
}
