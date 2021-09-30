using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text Score;
    // Start is called before the first frame update
    void Start()
    {
       Score = GetComponent<TMP_Text>();
       ChangeText();
        GameManager.OnScoreChange.AddListener(ChangeText);
    }

    public void ChangeText()
    {
        Score.text = "Score: " + GameManager.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
