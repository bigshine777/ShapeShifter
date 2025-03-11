using UnityEngine;

public class SquareStage_1 : MonoBehaviour
{
    private Stage1Message _stage1Message;
    void Start()
    {
        _stage1Message = FindAnyObjectByType<Stage1Message>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")){
            Destroy(transform.parent.gameObject);
            _stage1Message.ShowThirdMessage();
        }
    }

}
