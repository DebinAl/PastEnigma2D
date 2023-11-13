using System;
using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    public static GameEventHandler instance;

    public event Action OnStartButtonPress;
    public event Action OnPuzzleProgress;
    public event Action<int> OnPuzzlePress;
    public event Action OnPuzzleFailed;

    private void Awake()
    {
        instance = this;
    }

    public void StartButtonPress()
    {
        OnStartButtonPress?.Invoke();
    }

    public void PuzzleProggress()
    {
        OnPuzzleProgress?.Invoke();
    }

    public void PuzzlePress(int e)
    {
        OnPuzzlePress?.Invoke(e);
    }

    public void Puzzlefailed()
    {
        OnPuzzleFailed?.Invoke();
    }
}
