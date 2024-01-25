using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class target : MonoBehaviour
{
    public float Heealth=50f;
    //public float s=0;
    public Score scorevalue;
    public float speed;

    float x;
    float y;
    float z;
    Vector3 pos;

    void Start(){
         x = Random.Range(30, 968);
        y = 5;
        z = Random.Range(20, 986);
        pos = new Vector3(x, y, z);
        InvokeRepeating("play", 10.0f, 20.0f);
    }


    [PunRPC]
    public void takedamage(int amount){
        Heealth-=amount;
        if(Heealth<=0){
            Die();
        }

        Debug.Log(Heealth);
    }

    void Die(){
        Destroy(gameObject);
        scorevalue=FindObjectOfType<Score>();
        scorevalue.AddScore();
    }

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position, pos,speed*Time.deltaTime);
    }

    void play(){
        x = Random.Range(30, 968);
        y = 5;
        z = Random.Range(20, 986);
        pos = new Vector3(x, y, z);
        Debug.Log("play"+transform.position);

    }

}