using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float Speed = 500;
    public float RotationSpeed = 10;

    Rigidbody2D myRb;

    //propulsion from jetpack
    public GameObject propulsion;
    public float Cooldown = 0.2f;
    float Timer = 0;
    public float propulsionSpeed;
    public Vector3 Offest1 = new Vector3(0.35f, 0.4f, 0);

    public float FireError = 1f;

    //screen shake things
    camerafollow FC;
    public float FireShakeTime = 0.1f;
    public float FireSHakeMagnitude = 0.1f;

    //audio things
    AudioSource SFXPlayer;
    public AudioClip LaserNoise;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        FC = FindObjectOfType<camerafollow>();
        SFXPlayer = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    //fixed update runs on physics times
    private void FixedUpdate()
    {
        //grab input from the
        float ySpeed = Input.GetAxisRaw("Vertical") * Speed;
        float rotSpeed = Input.GetAxisRaw("Horizontal") * RotationSpeed;

        //Add fores and torque
        myRb.AddForce(transform.up * ySpeed * Time.fixedDeltaTime); 

        myRb.AddTorque(-rotSpeed * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        //increase the timer based on time passed
        Timer += Time.deltaTime;
        if (Timer > Cooldown && Input.GetAxisRaw("Jump") == 1)
        {
            //reset the timer
            Timer = 0;
            //make Laser noise
            SFXPlayer.PlayOneShot(LaserNoise);
            //fire propulsion
            Fire(Offest1);
            FC.TriggerShake(FireShakeTime, FireSHakeMagnitude);
        }
    }
    //spawns one object with an offest form the spawner
    void Fire(Vector3 offset)
    {
        //create the object with a position offset and affected by the rotation of the spawner
        Vector3 spawnPos = transform.position + transform.rotation * offset;
        GameObject clone = Instantiate(propulsion, spawnPos, transform.rotation);
        //set the speed of the clone
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        cloneRb.velocity = transform.up * propulsionSpeed + transform.right * Random.Range(-FireError, FireError);
        cloneRb.velocity += myRb.velocity;
    }



}
