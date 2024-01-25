using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addhealth : MonoBehaviour
{
    // [Header("SOUND")]
    // public AudioClip auC;
    // public AudioSource auS;
    public Health Healthplayer;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player"){
             Healthplayer=FindObjectOfType<Health>();
            // auS.PlayOneShot(auC);
             //Healthplayer.health+=5;
              Healthplayer.health += 5;
             Healthplayer.healthBar.sizeDelta = new Vector2(Healthplayer.originalHealthBarSize * Healthplayer.health / 100f, Healthplayer.healthBar.sizeDelta.y);
             Destroy(gameObject);
            
        }
    }
}
