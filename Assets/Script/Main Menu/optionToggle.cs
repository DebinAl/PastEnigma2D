using UnityEngine;

public class optionToggle : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleOption()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
