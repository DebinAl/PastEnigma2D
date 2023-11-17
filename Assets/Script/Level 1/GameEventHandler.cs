using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    public static GameEventHandler instance;

    public event Action OnStartButtonPress;
    public event Action<int> OnPuzzlePress;
    public event Action OnPuzzleFailed;
    public event Action<List<int>> OnPuzzleSequence;
    public event Action OnPuzzleDone;

    private void Awake()
    {
        instance = this;
    }

    public void StartButtonPress()
    {
        OnStartButtonPress?.Invoke();
    }

    public void PuzzlePress(int e)
    {
        OnPuzzlePress?.Invoke(e);
    }

    public void PuzzleFailed()
    {
        OnPuzzleFailed?.Invoke();
    }

    public void PuzzleDone()
    {
        OnPuzzleDone?.Invoke();
    }

    public void PuzzleSequence(List<int> e)
    {
        OnPuzzleSequence?.Invoke(e);
    }
}
