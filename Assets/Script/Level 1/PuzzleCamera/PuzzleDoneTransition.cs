using UnityEngine;

public class PuzzleDoneTransition : MonoBehaviour
{
    bool puzzleDone = false;
    Vector3 reference = Vector3.zero;

    private void Start()
    {
        GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleDone;
    }

    private void OnDisable()
    {
        GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleDone;
    }

    private void Instance_OnPuzzleDone()
    {
        puzzleDone = true;
    }

    void Update()
    {
        if(puzzleDone)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(9.75f, 1.3f, -10f), ref reference, 0.2f);
        }
    }
}
