using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dolli : MonoBehaviour {

    public GameController_Dolli gcd;
    public List<GameObject> eggs = new List<GameObject>();

    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
    
    void Start () {
        //_sensitivity = 0.115f;//초기 값
        _sensitivity = 0.5f;
        _rotation = Vector3.zero;

        //초기 알 세팅
        for (int i = 2; i < eggs.Count; i++)
        {
            eggs[i].SetActive(false);
        }

        eggs[0].transform.position = new Vector3(0.2f, 0, 0);
        eggs[1].transform.position = new Vector3(-0.2f, 0, 0);
    }
    
    void Update () {
        OnClickEvent();
        RotationControl();
    }

    public void StageSetting()
    {
        switch (gcd.stage + 1)
        {
            case 3:
                eggs[0].transform.position = new Vector3(0.2f, -0.1f, 0);
                eggs[1].transform.position = new Vector3(-0.2f, -0.1f, 0);
                eggs[2].transform.position = new Vector3(0, 0.2f, 0);

                eggs[2].SetActive(true);
                break;

            case 5:
                eggs[0].transform.position = new Vector3(0.2f, -0.2f, 0);
                eggs[1].transform.position = new Vector3(-0.2f, -0.2f, 0);
                eggs[2].transform.position = new Vector3(0.2f, 0.2f, 0);
                eggs[3].transform.position = new Vector3(-0.2f, 0.2f, 0);

                eggs[3].SetActive(true);
                break;

            case 7:
                eggs[0].transform.position = new Vector3(0.23f, -0.35f, 0);
                eggs[1].transform.position = new Vector3(-0.23f, -0.35f, 0);
                eggs[2].transform.position = new Vector3(-0.35f, 0.08f, 0);
                eggs[3].transform.position = new Vector3(-0, 0.35f, 0);
                eggs[4].transform.position = new Vector3(0.35f, 0.08f, 0);

                eggs[4].SetActive(true);
                break;

            case 9:
                eggs[0].transform.position = new Vector3(0f, -0.35f, 0);
                eggs[1].transform.position = new Vector3(-0.3f, -0.17f, 0);
                eggs[2].transform.position = new Vector3(-0.3f, 0.17f, 0);
                eggs[3].transform.position = new Vector3(-0, 0.35f, 0);
                eggs[4].transform.position = new Vector3(0.3f, 0.17f, 0);
                eggs[5].transform.position = new Vector3(0.3f, -0.17f, 0);

                eggs[5].SetActive(true);
                break;
        }
    }

    void OnClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // rotating flag
            _isRotating = true;

            // store mouse
            _mouseReference = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // rotating flag
            _isRotating = false;
        }
    }

    void RotationControl()
    {
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.z = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            // rotate
            transform.Rotate(_rotation * -1);

            // store mouse
            _mouseReference = Input.mousePosition;
        }
        else
        {
            _rotation *= 0.982f;
            transform.Rotate(_rotation * -1);
        }
    }
}
