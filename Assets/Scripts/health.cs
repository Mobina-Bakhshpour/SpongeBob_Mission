using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public bool isLocalPlayer;

    public RectTransform healthBar;

    public float originalHealthBarSize;


    // [Header("UI")]
    // public TextMeshProUGUI healthText;

    [PunRPC]
    public void TakeDamage(int _damage) {
        health -= _damage;
        healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);

        //healthText.text = health.ToString();

        if (health <= 0) {
            if(isLocalPlayer)
            {
                RoomManager.instance.RespawnPlayer();
                // RoomManager.instance.deaths++;
                // RoomManager.instance.SetHashes();
            }
                
                Destroy(gameObject);
        }
         
    }

    private void Start()
    {
            originalHealthBarSize = healthBar.sizeDelta.x;

    }
}
