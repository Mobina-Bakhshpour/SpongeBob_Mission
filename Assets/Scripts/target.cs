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
    //public Animation _animation;
    //public AnimationClip movejellyfish;

    // [Header("Animation")]

    // public Animation animation;
    // public AnimationClip movejellyfish;


    // [Header("Recoil Settings")]
    // [Range(1,4)]
    // public float recoilPercant = 2f;

    // [Range(1,5)]
    // public float recoverPercent = 3f;

    // [Space]
    // public float recoilUp = 0.05f;
    // public float recoilBack = 0.05f;
    // private Vector3 originalPosition;
    // private Vector3 recoilVelocity = Vector3.zero;

    // private float recoilLenght;
    // private float recoverLenght;
    // private bool recoiling;
    // private bool recovering;

    //  public float fireRate;



    void Start(){
        // recoilLenght =  0;
        // recoverLenght =  10 / fireRate * recoverPercent;
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

    // void Update()
    // {
    //     recoiling = true;
    //     recovering = false;

    //      if (recoiling) {
    //         Recoil();
    //     }

    //     if (recovering) {
    //         Recovering();
    //     }
    // }

    // void Recoil() {
    //     Vector3 finalPosition = new Vector3(originalPosition.x,originalPosition.y+recoilUp,originalPosition.z-recoilBack);
    //     transform.localPosition = Vector3.SmoothDamp(transform.localPosition,finalPosition,ref recoilVelocity,recoilLenght);
    //     if (transform.localPosition == finalPosition) {
    //         recoiling = false;
    //         recovering = true;
    //     }
    // }

    //     void Recovering() {
    //     Vector3 finalPosition = originalPosition;
    //     transform.localPosition = Vector3.SmoothDamp(transform.localPosition,finalPosition,ref recoilVelocity,recoverLenght);
    //     if (transform.localPosition == finalPosition) {
    //         recoiling = false;
    //         recovering = false;
    //     }
    // }

}