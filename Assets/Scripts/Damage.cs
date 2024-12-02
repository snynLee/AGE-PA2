using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class Damage : MonoBehaviour
{
    public Slider healthBarSlider;

    private bool hasKey = false;

    public GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {
        Weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarSlider.value <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Fire" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= .011f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Key")
        {
            hasKey = true;
            Debug.Log(other);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Door")
        {
            if (hasKey)
            {
                Destroy(other.gameObject);
                Debug.Log("Door trigger °¨Áö");
            }
        }
        else if (other.gameObject.tag == "Weapon")
        {
            Destroy(other.gameObject);
            Weapon.SetActive(true);
        }
    }
}
