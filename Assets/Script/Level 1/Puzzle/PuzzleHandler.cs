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

        var e = 0;
        var i = _answerAttempt.Count;
        var isChecked = false;

        while (e < i)
        {            
            if(_answerAttempt[e] != _answerList[e])
            {
                CheckAnswer();
                isChecked = true;
            }

            e++;
        }

        if (_answerAttempt.Count.Equals(_answerList.Count) && !isChecked)
        {
            CheckAnswer();
        }
    }

    private void CreateAnswer()
    {
        if (_answerList.Count < 6)
        {
            _answerList.Add(Random.Range(0, 4));
            AnswerSequence();
        }
        else
        {
            GameEventHandler.instance.PuzzleDone(); 
        }
    }

    private void AnswerSequence()
    {
        GameEventHandler.instance.PuzzleSequence(_answerList);
    }

    private void CheckAnswer()
    {
        if (_answerAttempt.SequenceEqual(_answerList) && _answerList.Count != 0)
        {
            _answerAttempt.Clear();
            CreateAnswer();
        }
        else
        {
            _answerAttempt.Clear();
            _answerList.Clear();
            GameEventHandler.instance.PuzzleFailed();
        }
    }

}
