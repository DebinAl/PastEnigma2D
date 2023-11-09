using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private bool _isActive = false;
    
    public void ButtonPressed()
    {
        if (_isActive) 
        {
            _isActive = false;
            Debug.Log("False");
        }else
        {
            _isActive = true;
            Debug.Log("True");
        }
    }
}
