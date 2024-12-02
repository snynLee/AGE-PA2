using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float time;
    private int currentTime;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < 10) 
        {
            time += Time.deltaTime;
            currentTime = (int)time;
            timerText.text = "Timer: " + currentTime;

            if (currentTime >= 10)
            {

                SceneManager.LoadScene("Lose");
            }
        }
    }
}
