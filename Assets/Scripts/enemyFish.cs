using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class enemyFish : MonoBehaviour
{
    public float Heealth=50f;
    public Score scorevalue;
        // public float Heealth=50f;

        // public Score scorevalue;

    [PunRPC]
    public void takedamageFish(int amount){
        Heealth-=amount;
        if(Heealth<=0){
            DieFish();
        }
         Debug.Log(Heealth);
    }

    void DieFish(){
        Destroy(gameObject);
        scorevalue=FindObjectOfType<Score>();
        scorevalue.AddScore();
        // Debug.Log(scorevalue.score);
    }
}
