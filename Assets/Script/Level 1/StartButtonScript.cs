using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    private GameObject _startButton;

    private void Awake()
    {
        _startButton = gameObject;
    }

    private void Start()
    {
        GameEventHandler.instance.OnStartButtonPress += StartButtonAction;
    }

    private void OnDestroy()
    {
        GameEventHandler.instance.OnStartButtonPress -= StartButtonAction;
    }

    public void StartButtonAction()
    {
        _startButton.SetActive(false);
    }
}
