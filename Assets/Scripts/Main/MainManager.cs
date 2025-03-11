using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using System.Text.RegularExpressions;

public class MainManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _gameClearUI;
    [SerializeField] private TextMeshProUGUI _messageText;
    private Player _player;
    private bool _bshowUI;
    private int _stageInt;
    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _bshowUI = false;
        _stageInt = int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void _GameOver()
    {
        if (_player || _bshowUI) return;
        _gameOverUI.SetActive(true);
        _bshowUI = true;
        _messageText.text = "";
    }

    private void _GameClear()
    {
        if (_bshowUI || !_player.IsPlayerGoal()) return;
        _gameClearUI.SetActive(true);
        Rigidbody2D _rigid = _player.GetComponent<Rigidbody2D>();
        _rigid.linearVelocity = Vector2.zero;
        _rigid.bodyType = RigidbodyType2D.Kinematic;
        _messageText.text = "";
        _SetNextStageInt();
    }

    private void _SetNextStageInt()
    {
        PlayerPrefs.SetInt("Stage", _stageInt + 1);
        PlayerPrefs.Save();
    }

    public void ChangeNextStage()
    {
        SceneManager.LoadScene("Stage" + (_stageInt + 1));
    }

    public void ChangeSelectStageScence()
    {
        SceneManager.LoadScene("SelectStage");
    }

    public void BtnResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
