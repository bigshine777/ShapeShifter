using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _gameClearUI;
    private Player _player;
    private bool _bshowUI;
    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _bshowUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        _GameOver();
        _GameClear();
    }

    public void ResetScence(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SceneManager.LoadScene("Main");
    }

    private void _GameOver()
    {
        if (_player || _bshowUI) return;
        _gameOverUI.SetActive(true);
        _bshowUI = true;
    }

    private void _GameClear()
    {
        if (_bshowUI || !_player.IsPlayerGoal()) return;
        _gameClearUI.SetActive(true);
        Rigidbody2D _rigid = _player.GetComponent<Rigidbody2D>();
        _rigid.linearVelocity = Vector2.zero;
        _rigid.bodyType = RigidbodyType2D.Kinematic;
    }

}
