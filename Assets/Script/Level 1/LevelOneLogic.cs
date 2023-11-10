using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelOneLogic : MonoBehaviour
{
    private ButtonScript _button;
    private LevelOnePuzzle _puzzle;
    private Camera _cam;

    void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.collider != null && hit.collider.CompareTag("Button"))
            {
                _button = hit.collider.GetComponent<ButtonScript>();
                _button.ButtonPressed();
                
            }
        }
    }
}
