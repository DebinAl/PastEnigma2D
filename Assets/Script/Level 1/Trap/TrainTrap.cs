using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrap : MonoBehaviour
{
    [SerializeField] GameObject[] traps;

    readonly float _spikeDelay = 3f;
    float timer = 0f;

    private void Start()
    {
        foreach (var trap in traps)
        {
            trap.SetActive(false);
        }
    }

    private void Update()
    {
        if (timer <= 0f)
        {
            StartCoroutine(SpikeSequence());
            timer = _spikeDelay;
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator SpikeSequence()
    {
        StartCoroutine(SpikeUp());

        yield return new WaitForSeconds(2f);

        StartCoroutine(SpikeDown());
    }

    private IEnumerator SpikeUp()
    {
        foreach (var trap in traps)
        {
            trap.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private IEnumerator SpikeDown()
    {
        foreach (var trap in traps)
        {
            trap.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
