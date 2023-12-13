using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool _isActive = true;

    //serializeField 
    [SerializeField] private Transform cursorRef;
    [SerializeField] private Camera cam;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelScene")
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
            GameEventHandler.instance.OnPuzzleFailed -= Instance_OnPuzzleDone;
            GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleDone;
        }
    }

    void Update()
    {
        if (_isActive)
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
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(2f, 3f, -10f), ref velocityV3, camFollowUp);
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
