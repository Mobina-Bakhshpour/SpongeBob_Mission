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
    public float speed;

    float x;
    float y;
    float z;
    Vector3 pos;
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

    void Start(){
         x = Random.Range(30, 968);
        y = 5;
        z = Random.Range(20, 986);
        pos = new Vector3(x, y, z);
        InvokeRepeating("play", 10.0f, 20.0f);
    }

     void Update(){
        transform.position=Vector3.MoveTowards(transform.position, pos,speed*Time.deltaTime);
    }

    void play(){
        x = Random.Range(30, 968);
        y = 5;
        z = Random.Range(20, 986);
        pos = new Vector3(x, y, z);
       // Debug.Log("play"+transform.position);

    }
}
