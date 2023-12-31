using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    Image _image;
    Color _color;

    private void Start()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
    }

    public void OnPointerEnter()
    {
        _color.a = 1f;

        _image.color = _color;
    }

    public void OnPointerExit() 
    {
        _color.a = 0.8f;
        
        _image.color = _color;
    }
}
