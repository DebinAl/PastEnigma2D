using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    //camera
    private Vector3 _cameraOffset = new(0f, 2f, -10f);
    private readonly float _camSpeed = 0.2f; //speed for smoothdamp

    //zoom
    private float _zoomTimer; //how long it takes before zoom reset
    private float _orthoTarget;
    private readonly float _defaultOrtho = 6f;
    private readonly float zoomSpeed = 0.5f; //speed when changing zoom

    //velocity ref
    private float velocity = 0f;
    private Vector3 velocityV3 = Vector3.zero;

    //bool
    private bool _isActive = true;

    //serializeField 
    [SerializeField] private Transform cursorRef;
    [SerializeField] private Camera mainCam;

    //puzzle
    private Canvas _puzzleCanvas;
    private Camera _puzzleCamera;

    private void Start()
    {
        _orthoTarget = _defaultOrtho;

        if (SceneManager.GetActiveScene().name == "LevelScene")
        {
            GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress;
            GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleDone;
            GameEventHandler.instance.OnPuzzleFailed += Instance_OnPuzzleDone;

            _puzzleCanvas = GameObject.FindGameObjectWithTag("PuzzleCanvas").transform.GetComponent<Canvas>();
            _puzzleCamera = GameObject.FindGameObjectWithTag("PuzzleCamera").transform.GetComponent<Camera>();
            _puzzleCamera.enabled = false;
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

    private void Instance_OnPuzzleDone()
    {
        _isActive = true;
        _puzzleCanvas.worldCamera = mainCam;
        ChangePuzzleCamera();
    }

    private void Instance_OnStartButtonPress()
    {
        _isActive = false;
        _puzzleCanvas.worldCamera = _puzzleCamera;
        ChangePuzzleCamera();
    }

    void Update()
    {
        if (_isActive)
        {
            CameraZoom();

            //Smooth Camera
            Vector3 targetPosition = _cameraOffset + cursorRef.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityV3, _camSpeed);
        }
    }
    
    private void ChangePuzzleCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        _puzzleCamera.enabled = !_puzzleCamera.enabled;
    }

    private void CameraZoom()
    {
        //zoom logic
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            _orthoTarget -= 0.5f;
            _zoomTimer = 7f;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            _orthoTarget += 0.5f;
            _zoomTimer = 7f;
        }

        _orthoTarget = Mathf.Clamp(_orthoTarget, 5f, 8f);

        mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, _orthoTarget, ref velocity, zoomSpeed);

        _zoomTimer -= Time.deltaTime;
        
        if ( _zoomTimer <= 0f)
        {
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, _defaultOrtho, ref velocity, zoomSpeed);
            _orthoTarget = _defaultOrtho;    
        }
    }
}
