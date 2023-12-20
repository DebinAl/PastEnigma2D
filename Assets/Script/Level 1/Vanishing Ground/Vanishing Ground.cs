using System.Collections;
using UnityEngine;

public class VanishingGround : MonoBehaviour
{
    [SerializeField] private GameObject[] grounds;

    readonly float delay = 0.75f;
    readonly float timer = 3f;
    float curTimer = 3f;
    private void Update()
    {
        if(curTimer <= 0f)
        {
            StartCoroutine(GroundToggle());
            curTimer = timer;
        }          

        curTimer -= Time.deltaTime;
    }

    private IEnumerator GroundToggle()
    {
        foreach(var ground in grounds)
        {
            ground.SetActive(false);
        }

        yield return new WaitForSeconds(delay);

        foreach (var ground in grounds)
        {
            ground.SetActive(true);
        }
    }

}
