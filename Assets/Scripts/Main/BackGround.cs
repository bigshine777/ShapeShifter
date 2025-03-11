using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private GameObject _camera;
    void Start()
    {
        _camera = Camera.main.gameObject;
    }

    void Update()
    {
        _FollowCamera();
    }

    private void _FollowCamera()
    {
        transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, transform.position.z);
    }
}
