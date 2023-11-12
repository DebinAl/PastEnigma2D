using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _cam;

    void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        //TODO: check button features

        /*
                 if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("ButtonStart"))
            {
                GameEventHandler.instance.StartButtonPress();
            }

            if (hit.collider != null && hit.collider.CompareTag("Button"))
            {
                // TODO: when puzzle piece clicked            
            }

        }         
         */
    }
}
