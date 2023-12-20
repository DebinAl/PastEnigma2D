using UnityEngine;

public class Gate : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleDone;
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleDone;
    }

    private void Instance_OnPuzzleDone()
    {
        animator.SetBool("IsDone", true);
    }
}
