using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("EntranceScene");
        Debug.Log("pressed");
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

}
