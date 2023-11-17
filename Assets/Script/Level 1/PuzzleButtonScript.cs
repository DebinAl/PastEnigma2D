using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButtonScript : MonoBehaviour
{
    public int id;
    private Image _buttonImage;
    private Button _button;
    private readonly float _glowDelay = 0.1f;
    private readonly float _glowLength = 0.4f;

    [SerializeField] private Material _material;
    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress;
        GameEventHandler.instance.OnPuzzleSequence += Instance_OnPuzzleSequence;
        GameEventHandler.instance.OnPuzzleFailed += Instance_OnPuzzleFailed;
        GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleFailed;
    }

    private void OnDestroy()
    {
        GameEventHandler.instance.OnStartButtonPress -= Instance_OnStartButtonPress;
        GameEventHandler.instance.OnPuzzleSequence -= Instance_OnPuzzleSequence;
        GameEventHandler.instance.OnPuzzleFailed -= Instance_OnPuzzleFailed;
        GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleFailed;
    }

    private void Instance_OnStartButtonPress()
    {
        _buttonImage.enabled = true;
    }

    private void Instance_OnPuzzleFailed()
    {
        _button.interactable = false;
        _buttonImage.enabled = false;
        StopAllCoroutines();
    }

    private void Instance_OnPuzzleSequence(List<int> obj)
    {
        StopAllCoroutines();
        List<int> aList = obj;

        StartCoroutine(Queue(aList));    
        _button.interactable = false;        
    }

    private IEnumerator Queue(List<int> obj)
    {
        yield return new WaitForSeconds(0.5f);
        
        foreach (var i in obj)
        {
            yield return StartCoroutine(PuzzleCoroutine(i));
        }

        _button.interactable = true;
    }

    private IEnumerator PuzzleCoroutine(int obj)
    {
        yield return new WaitForSeconds(_glowDelay);

        if (obj == id) _buttonImage.material = _material;

        yield return new WaitForSeconds(_glowLength);

        if (obj == id) _buttonImage.material = null;
    }
}
