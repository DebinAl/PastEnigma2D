using System.Collections;
using UnityEngine;

public class MovingTrap1 : MonoBehaviour
{
    [SerializeField] GameObject[] Traps;

    readonly float _spikeDelay = 7f;
    float timer = 0f;

    private void Start()
    {
        foreach (var trap in Traps)
        {
            trap.SetActive(false);
        }
    }

    private void Update()
    {
        if(timer <= 0f)
        {
            StartCoroutine(SpikeSequence());
            timer = _spikeDelay;
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator SpikeSequence()
    {
        StartCoroutine(SpikeUp());

        yield return new WaitForSeconds(3f);

        StartCoroutine(SpikeDown());
    }
    
    private IEnumerator SpikeUp()
    {
        foreach(var trap in Traps)
        {
            trap.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private IEnumerator SpikeDown()
    {
        foreach (var trap in Traps)
        {
            trap.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
