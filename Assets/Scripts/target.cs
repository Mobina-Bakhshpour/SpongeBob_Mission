using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class target : MonoBehaviour
{
    public float Heealth=50f;
    public float s=0;


    [PunRPC]
    public void takedamage(int amount){
        Heealth-=amount;
        if(Heealth<=0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}