using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    //time until object is destroyed in seconds
    public float LifeTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
