using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
private Vector3 offset = new(0f, 2f, -10f);
    private float camFollowUp = 0.2f;
    private float zoom = 6f;
    private float zoomTimer = 7f;
    private float zoomFollowUp = 0.5f;
    private Vector3 cursorPos;

    //velocity ref
    private float velocity = 0f;
    private Vector3 velocityV3 = Vector3.zero;

    //serializeField
    [SerializeField] private Transform cursorRef;
    [SerializeField] private Camera cam;

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        
        //changing the orthograpicSize
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, zoomFollowUp);

        //reset the z value of the cursor
        cursorPos = new Vector3(cursorRef.position.x, cursorRef.position.y, 0);

        //Smooth Camera
        Vector3 targetPosition = offset + cursorPos;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityV3, camFollowUp);
    }

    private void CameraZoom()
    {
        //zoom logic
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            zoom-=0.5f;
            zoomTimer = 7f;
        } else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            zoom+=0.5f;
            zoomTimer = 7f;
        }

        zoomTimer -= Time.deltaTime;

        //reset zoom timer
        if(zoomTimer <= 0f)
        {
            zoom = 6f;
            zoomTimer = 7f;
        }

        //clamping the value between 6 to 8
        zoom = Mathf.Clamp(zoom, 6, 8);
    }
}
