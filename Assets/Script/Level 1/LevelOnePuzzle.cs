using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class LevelOnePuzzle : MonoBehaviour
{
    private ArrayList _puzzleAnswer;
    private ArrayList _answerAttempt;

    private void Update()
    {
        
    }

    private void PuzzleLogic()
    {

    }

    public void AnswerAttempt(ArrayList e)
    {
        _answerAttempt = e;
    }
}
