using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [Tooltip("Drag the object from the heiarchy tab into this slot that you want the camera to follow")]
    public GameObject Target;
    [Tooltip("set between 0 and one kinda how fast it moves to the target"), Range(0,1)]
    public float LerpVal = 0.8f;

    float ShakeTime = 0;
    float ShakeAmount = 0;
    //call this funtion to make the screen shake
    public void TriggerShake(float time, float amount)
    {
        if(ShakeTime < time)
        {
            ShakeTime = time;
        }
        if(ShakeAmount < amount)
        {
            ShakeAmount = amount;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //fixed update runs onece per physics frame
    private void FixedUpdate()
    {
       if(Target != null)
        {
            //calculate where the camera is moving Towards
            Vector3 newPos = Target.transform.position;
            newPos.z = transform.position.z;
            //lerp towards the target to make a smoothing effect in the movement
            transform.position = Vector3.Lerp(transform.position, newPos, LerpVal);
        }

       if(ShakeTime > 0)
        {
            ShakeTime -= Time.fixedDeltaTime;
            Vector3 randDir = Random.insideUnitCircle * ShakeAmount;
            transform.position += randDir;
        }
       else
        {
            ShakeAmount = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            TriggerShake(0.2f, 0.2f);
        }
    }
}
