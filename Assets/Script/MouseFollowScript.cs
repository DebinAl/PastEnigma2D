using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowScript : MonoBehaviour
{
    private Vector3 _offsett = new Vector3(0f, 0.5f, -10f);
    private Vector3 _mousePos;
    private Vector3 _targetPos;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _thresholdX;
    [SerializeField] private float _thresholdY;
    // Update is called once per frame
    void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        _targetPos = (_player.position + _mousePos) / 2f;

        _targetPos.x = Mathf.Clamp(_targetPos.x, -_thresholdX + _player.position.x, _thresholdX + _player.position.x);
        _targetPos.y = Mathf.Clamp(_targetPos.y, (-_thresholdY / 2f) + _player.position.y, _thresholdY + _player.position.y);

        transform.position = _targetPos + _offsett;
    }
}
