using UnityEngine;

public class PuzzleButtonScript : MonoBehaviour
{
    public int id;
    private GameObject _button;
    private SpriteRenderer _renderer;

    [SerializeField] private Material _active;
    [SerializeField] private Material _notActive;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _button = gameObject;
    }

    private void Start()
    {
        GameEventHandler.instance.OnStartButtonPress += OnPuzzleStarted;
    }

    private void OnDestroy()
    {
        GameEventHandler.instance.OnStartButtonPress -= OnPuzzleStarted;
    }

    private void OnPuzzleStarted()
    {       
        _button.SetActive(true);
    }
}
