using System.Collections;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    public ArrayList _puzzleAnswer = new();
    private ArrayList _answerAttempt = new();

    [SerializeField] private GameObject[] _puzzleButton;
    [SerializeField] private GameObject _startButton;

    public void PuzzleStart()
    {
        ButtonSetActive();

        PuzzleLogic();

        AnswerAttempt();
    }

    private void ButtonSetActive()
    {
        foreach (var obj in _puzzleButton)
        {
            obj.SetActive(true);
        }

        _startButton.SetActive(false);
    }

    private void PuzzleLogic()
    {
        int rand = Random.Range(0, 4);

        _puzzleAnswer.Add($"Button ({rand})");
    }

    private void AnswerAttempt()
    {
        if (_answerAttempt.Equals(_puzzleAnswer))
        {
            _answerAttempt.Clear();
            PuzzleLogic();
        }
        else
        {
            PuzzleReset();
        }
    }

    private void PuzzleReset()
    {
        _puzzleAnswer.Clear();
        _answerAttempt.Clear();

        foreach (var obj in _puzzleButton)
        {
            obj.SetActive(false);
        }

        _startButton.SetActive(true);
    }

    public void SetAnswer(string e)
    {
        _answerAttempt.Add(e);
    }
}
