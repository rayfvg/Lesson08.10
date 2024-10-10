using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraModSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _topDownCamera;
    [SerializeField] private CinemachineVirtualCamera _thirdPersonCamera;

    private Queue<CinemachineVirtualCamera> _cameras;

    private void Awake()
    {
        _cameras = new Queue<CinemachineVirtualCamera>();
        _cameras.Enqueue(_topDownCamera);
        _cameras.Enqueue(_thirdPersonCamera);
        SwitchNextMode();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SwitchNextMode();
        }
    }

    private void SwitchNextMode()
    {
        CinemachineVirtualCamera nextMode = _cameras.Dequeue();

        foreach (var cam in _cameras)
        {
            cam.gameObject.SetActive(false);
        }

        nextMode.gameObject.SetActive(true);

        _cameras.Enqueue(nextMode);
    }
}
