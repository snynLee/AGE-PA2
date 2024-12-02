using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isBig = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBig)
        {
            gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x * Time.deltaTime, 0, 0);
            if (gameObject.transform.localScale.x >= 25)
            {
                isBig = true;
            }
            
        }
        else
        {
            if (gameObject.transform.localScale.x <= 1)
            { 
                isBig = false; 
            }
            gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x * Time.deltaTime, 0, 0);
        }
    }
}
