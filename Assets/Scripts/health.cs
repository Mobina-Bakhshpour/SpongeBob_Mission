using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public RectTransform healthBar;

    private float originalHealthBarSize;


    [Header("UI")]
    public TextMeshProUGUI healthText;

    [PunRPC]
    public void TakeDamage(int _damage) {
        health -= _damage;
        healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);

        healthText.text = health.ToString();

        if (health <= 0) {
            RoomManager.instance.RespawnPlayer();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
            originalHealthBarSize = healthBar.sizeDelta.x;

    }
}
