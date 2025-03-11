using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TitleManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeScene(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SceneManager.LoadScene("SelectStage");
    }
}
