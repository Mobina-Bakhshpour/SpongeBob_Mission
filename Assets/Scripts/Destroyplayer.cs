using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyplayer : MonoBehaviour
{

    public Health Healthplayer;
   [Header("SOUND")]
    public AudioClip auC;
    public AudioSource auS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

      void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "enemy"){
            //Healthplayer.health-=10;

             Healthplayer=FindObjectOfType<Health>();
             Healthplayer.health -= 5;
             Healthplayer.healthBar.sizeDelta = new Vector2(Healthplayer.originalHealthBarSize * Healthplayer.health / 100f, Healthplayer.healthBar.sizeDelta.y);
             auS.PlayOneShot(auC);
             if(Healthplayer.health<=0){
                    Destroy(gameObject);
                
                    if(Healthplayer.isLocalPlayer){
                        RoomManager.instance.RespawnPlayer();
                    }
             }
            
        }
    }
}
