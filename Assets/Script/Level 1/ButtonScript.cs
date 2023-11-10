using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] public bool _isActive = false;
    [SerializeField] private Material _active;
    [SerializeField] private Material _notActive;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void ButtonPressed()
    {
        if (_isActive) 
        {
            _isActive = false;

            _renderer.material = _notActive;
        }else
        {
            _isActive = true;

            _renderer.material = _active;
        }
    }
}
