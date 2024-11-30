using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject changelPanel;

    void Start()
    {
        changelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && changelPanel.activeSelf == false)
        {
            changelPanel.SetActive(true);
        }

        if (Input.anyKeyDown && changelPanel.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
