using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashedTrailEffect : MonoBehaviour
{
    float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float deleteAfterSeconds;

    public GameObject dash;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            GameObject line = Instantiate(dash, transform.position, transform.rotation);
            Destroy(line, deleteAfterSeconds);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
        
    }
}
