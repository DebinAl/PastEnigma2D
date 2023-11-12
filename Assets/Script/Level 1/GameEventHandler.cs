using System;
using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    public static GameEventHandler instance;

    public event Action OnStartButtonPress;

    private void Awake()
    {
        instance = this;
    }

    public void StartButtonPress()
    {
        OnStartButtonPress?.Invoke();
    }
}
