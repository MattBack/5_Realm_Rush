using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip healthLossSFX;

    void Start() {
        healthText.text = health.ToString();
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(healthLossSFX);
        health -= healthDecrease;
        healthText.text = health.ToString();
    }
}
