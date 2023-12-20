using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicVolume : MonoBehaviour
{
    AudioSource bgm;

    void Start()
    {
        bgm = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            bgm.volume = PlayerPrefs.GetFloat("VolumeValue", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            Debug.Log(PlayerPrefs.GetFloat("VolumeValue"));

            PlayerPrefs.SetFloat("VolumeValue", bgm.volume);
        }
    }
}