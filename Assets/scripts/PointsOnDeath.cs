using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnDeath : MonoBehaviour
{
    [Tooltip("points that are aded to the score in the game amanger when dying")]
    public int Points = 5;
    // Start is called before the first frame update
    void Start()
    {
        //Find the death component to add a function to run when dying
        Death Grim = GetComponent<Death>();
        if(Grim != null)
        Grim.OnDeath.AddListener(AddPoints);
    }

    public void AddPoints()
    {
        GameManager.Score += Points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
