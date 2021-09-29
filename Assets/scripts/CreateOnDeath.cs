using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDeath : MonoBehaviour
{
    [Tooltip("Object to spawn when the current object dies")]
    public GameObject ObjectToMake;
    public Vector3 Offset = Vector3.zero;
    public float RandOffset = 0;

    private void OnDestroy()
    {
        Vector3 spawnPos = Random.insideUnitCircle * RandOffset;
        spawnPos += transform.position + Offset;
        Instantiate(ObjectToMake, spawnPos, transform.rotation);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
