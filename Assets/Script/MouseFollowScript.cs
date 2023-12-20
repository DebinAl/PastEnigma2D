using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseFollowScript : MonoBehaviour
{
    private Vector3 _offsett = new(0f, 0.5f, -10f);
    private Vector3 _mousePos;
    private Vector3 _targetPos;
    private bool _isActive = true;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _thresholdX;
    [SerializeField] private float _thresholdY;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "LevelScene")
        {
            GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress;
            GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleDone;
            GameEventHandler.instance.OnPuzzleFailed += Instance_OnPuzzleDone;
        }
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == "LevelScene")
        {
            GameEventHandler.instance.OnStartButtonPress -= Instance_OnStartButtonPress;
            GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleDone;
            GameEventHandler.instance.OnPuzzleFailed -= Instance_OnPuzzleDone;
        }
            
    }
    private void Instance_OnPuzzleDone()
    {
        _isActive = true;
    }

    private void Instance_OnStartButtonPress()
    {
        _isActive = false;
    }

    void Update()
    {
        if (_isActive)
        {
            MouseFollow();
        }
    }

    private void MouseFollow()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _targetPos = (_player.position + _mousePos) / 2f;

        _targetPos.x = Mathf.Clamp(_targetPos.x, -_thresholdX + _player.position.x, _thresholdX + _player.position.x);
        _targetPos.y = Mathf.Clamp(_targetPos.y, (-_thresholdY / 2f) + _player.position.y, _thresholdY + _player.position.y);

        transform.position = _targetPos + _offsett;
    }
}
