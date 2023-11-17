using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    private Image _buttonImage;
    private Button _button;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress;
        GameEventHandler.instance.OnPuzzleFailed += Instance_OnPuzzleFailed;
        GameEventHandler.instance.OnPuzzleDone += Instance_OnStartButtonPress;
    }

    private void OnDestroy()
    {
        GameEventHandler.instance.OnStartButtonPress -= Instance_OnStartButtonPress;
        GameEventHandler.instance.OnPuzzleFailed -= Instance_OnPuzzleFailed;
        GameEventHandler.instance.OnPuzzleDone -= Instance_OnStartButtonPress;
    }

    private void Instance_OnStartButtonPress()
    {
        _buttonImage.enabled = false;
        _button.interactable = false;
    }

    private void Instance_OnPuzzleFailed()
    {
        _buttonImage.enabled = true;
        _button.interactable = true;
    }
}
