using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<SystemVariables> _systems;
    public LSystem _lSystem;
    public RotateCamera _rotateCamera;
    public GameObject animate;
    // Start is called before the first frame update
    void Start()
    {
        _rotateCamera.Reset();
        _lSystem.animate = animate.activeInHierarchy;
    }
    public void animateModel()
    {
        animate.SetActive(!animate.activeInHierarchy);
        _lSystem.animate = animate.activeInHierarchy;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[0]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[1]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[2]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[3]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[4]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[5]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[6]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _rotateCamera.Reset();
            _lSystem.GetModel(_systems[7]);
            _rotateCamera.isThreeD = _lSystem.SetUpModel();
            _lSystem.StartDrawing();
        }

    }
}
