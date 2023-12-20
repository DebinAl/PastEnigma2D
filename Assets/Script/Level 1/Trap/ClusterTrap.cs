using System.Collections;
using UnityEngine;

public class Cluster : MonoBehaviour
{
    [SerializeField] GameObject[] clusterSpikes;


    readonly float spikeDelay = 0.25f;
    readonly float timer = 2f;
    float curTimer = 2f;

    private void Start()
    {
        foreach (var cluster in clusterSpikes)
        {
            cluster.SetActive(false);
        }
    }

    private void Update()
    {
        if(curTimer < 0f)
        {
            StartCoroutine(SpikeSequence());
            curTimer = timer;
        }

        curTimer -= Time.deltaTime;
    }

    private IEnumerator SpikeSequence()
    {
        StartCoroutine(SpikeUp());
        yield return new WaitForSeconds(spikeDelay+0.10f);
        StartCoroutine(SpikeDown());
    }

    private IEnumerator SpikeUp()
    {
        foreach (var cluster in clusterSpikes)
        {
            cluster.SetActive(true);
            yield return new WaitForSeconds(spikeDelay);
        }
    }
    private IEnumerator SpikeDown()
    {
        foreach (var cluster in clusterSpikes)
        {
            cluster.SetActive(false);
            yield return new WaitForSeconds(spikeDelay);
        }
    }
}
