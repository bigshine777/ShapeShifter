using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectStageButton : MonoBehaviour
{
    [SerializeField] private int _stageInt;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _IsEnabledStage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void _IsEnabledStage()
    {
        if (_stageInt <= PlayerPrefs.GetInt("Stage", 1))
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    public void ChangeScence()
    {
        SceneManager.LoadScene("Stage" + _stageInt);
    }
}
