using UnityEngine;
using UnityEngine.UI;

public class PuzzleButtonScript : MonoBehaviour
{
    public int id;
    private Image _buttonImage;
    private Button _button;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress; ;
    }

    private void OnDestroy()
    {
        GameEventHandler.instance.OnStartButtonPress -= Instance_OnStartButtonPress;
    }

    private void Instance_OnStartButtonPress()
    {
        _button.interactable = true;
        _buttonImage.enabled = true;
    }
}
