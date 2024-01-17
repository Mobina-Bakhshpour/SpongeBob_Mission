using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Wepon : MonoBehaviour
{

    private int score = 0;
    private int score1 = 0;


    public Image ammoCircle;

    public int damage;

    public float fireRate;

    public Camera camera;

    private float nextFire;

    [Header("Ammo")]
    public int mag = 5;
    public int ammo = 30;
    public int magAmmo = 30;

    [Header("VFX")]
    public GameObject hitVFX;

    [Header("UI")]
    //public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI magText;
    public TextMeshProUGUI scoreText;
    

    [Header("Animation")]

    public Animation animation;
    public AnimationClip reload;
    
    
    [Header("Recoil Settings")]
    [Range(0,1)]
    public float recoilPercant = 0.3f;

    [Range(0,2)]
    public float recoverPercent = 0.7f;

    [Space]
    public float recoilUp = 0.05f;
    public float recoilBack = 0.05f;


    private Vector3 originalPosition;
    private Vector3 recoilVelocity = Vector3.zero;

    private float recoilLenght;
    private float recoverLenght;
    private bool recoiling;
    private bool recovering;

    [Header("SOUND")]
    public AudioClip auC;
    public AudioSource auS;

    public TextMeshProUGUI ScoreText { get => scoreText; set => scoreText = value; }
    public TextMeshProUGUI ScoreText1 { get => scoreText; set => scoreText = value; }

    void SetAmmo(){
        ammoCircle.fillAmount=(float)ammo/magAmmo;
    }
    
    void Start() {
        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;

        originalPosition = transform.localPosition;

        recoilLenght =  0;
        recoverLenght =  1 / fireRate * recoverPercent;
            SetAmmo();

    }


    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0) {
            nextFire -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && nextFire <=0 && ammo > 0 && animation.isPlaying==false) {
            nextFire = 1 / fireRate;

            ammo--;

        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;
            SetAmmo();


            Fire();
            if(score>=5){
                score1=score/5;
                scoreText.text = score1.ToString();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }

        if (recoiling) {
            Recoil();
        }

        if (recovering) {
            Recovering();
        }
    }
    }
    void Reload(){
        animation.Play(reload.name);
        //GetComponent<Animation>().Play(reload.name);
        if (mag > 0) {
            mag--;

            ammo = magAmmo;
        }
        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;
        SetAmmo();

    }

    void Fire() {
        auS.PlayOneShot(auC);
        recoiling = true;
        recovering = false;
        Ray ray = new Ray(camera.transform.position,camera.transform.forward);

        RaycastHit hit;
        //PhotonNetwork.LocalPlayer.AddScore(1);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f)) {
            PhotonNetwork.Instantiate(hitVFX.name,hit.point,Quaternion.identity);
            if (hit.transform.gameObject.GetComponent<Health>()) {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All,damage);
                
            }
                //PhotonNetwork.LocalPlayer.AddScore(damage);
                // if(damage > hit.transform.gameObject.GetComponent<Health>().health)
                // {
                //     //Kill
                //     PhotonNetwork.LocalPlayer.AddScore(100);
                //     // RoomManager.instance.Kills++;
                //     // RoomManager.instance.SetHashes();
                // }
                if(hit.transform.gameObject.GetComponent<target>()){
                    hit.transform.gameObject.GetComponent<PhotonView>().RPC("takedamage", RpcTarget.All,damage);
                    score+=1;
            } 
           }
        }
    

    void Recoil() {
        Vector3 finalPosition = new Vector3(originalPosition.x,originalPosition.y+recoilUp,originalPosition.z-recoilBack);
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition,finalPosition,ref recoilVelocity,recoilLenght);
        if (transform.localPosition == finalPosition) {
            recoiling = false;
            recovering = true;
        }
    }

        void Recovering() {
        Vector3 finalPosition = originalPosition;
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition,finalPosition,ref recoilVelocity,recoverLenght);
        if (transform.localPosition == finalPosition) {
            recoiling = false;
            recovering = false;
        }
    }
}



