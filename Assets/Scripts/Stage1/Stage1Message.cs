using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Stage1Message : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _messageText;
    [SerializeField] private PlayerInput _playerInput;
    private Player _player;
    private bool _isShowedThirdMessage;

    private string[] _normalMessages = {
        "ようこそ！このゲームの遊び方を説明するよ！ ▼",
        "右上に表示されているボタンでそれぞれの形に変化することができるよ! ▼",
        "まずは丸に変身して坂道を転がろう! ▼"
    };

    private int _currentMessageIndex = 0;

    void Start()
    {
        _ShowlNormalMessage();
        _player = FindAnyObjectByType<Player>();
        _isShowedThirdMessage = false;
    }

    void Update()
    {
        _IsShowedNormalMessage();
        _ShowSecondMessage();
    }

    private void _ShowlNormalMessage()
    {
        _messageText.text = _normalMessages[_currentMessageIndex];
    }

    public void NextNormalMessage(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (_currentMessageIndex < _normalMessages.Length - 1)
        {
            _currentMessageIndex++;
            _ShowlNormalMessage();
        }
    }

    private void _IsShowedNormalMessage()
    {
        if (!_playerInput) return;
        if (_currentMessageIndex < _normalMessages.Length - 1)
        {
            _playerInput.enabled = false;
        }
        else
        {
            _playerInput.enabled = true;
        }
    }

    private void _ShowSecondMessage()
    {
        if (_isShowedThirdMessage || !_player) return;
        if (_player.transform.position.x > 18)
        {
            _messageText.text = "次は四角に変身して白い部分に止まろう ▼";
        }

        if (_player.transform.position.y < -6)
        {
            _messageText.text = "四角の重さでこの台は下がっていくよ！ ▼";
        }
    }

    public void ShowThirdMessage()
    {
        _isShowedThirdMessage = true;
        _messageText.text = "三角で跳ねてトゲを避けてみよう！ ▼";
    }
}
