using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    private List<int> _answerList = new();
    private List<int> _answerAttempt = new();
    
    private void Start()
    {
        GameEventHandler.instance.OnStartButtonPress += CreateAnswer;
        GameEventHandler.instance.OnPuzzlePress += Instance_OnPuzzlePress;
    }

    private void OnDestroy()
    {
        GameEventHandler.instance.OnStartButtonPress -= CreateAnswer;
        GameEventHandler.instance.OnPuzzlePress -= Instance_OnPuzzlePress;
    }

    private void Instance_OnPuzzlePress(int id)
    {
        _answerAttempt.Add(id);
        if(_answerAttempt.Count.Equals(_answerList.Count))
        {
            CheckAnswer();
        }
    }

    private void CreateAnswer()
    {
        if (_answerList.Count < 4)
        {
            _answerList.Add(Random.Range(0, 3));
        }
        else
        {
            Debug.Log("Done");
        }

        var strings = "answer: ";

        foreach (var i in _answerList)
        {
            strings += i.ToString();
        }
        Debug.Log(strings);
    }

    private void CheckAnswer()
    {
        if (_answerAttempt.SequenceEqual(_answerList))
        {
            _answerAttempt.Clear();
            CreateAnswer();
        }
        else
        {
            Debug.Log("You Lose");
        }
    }

}
