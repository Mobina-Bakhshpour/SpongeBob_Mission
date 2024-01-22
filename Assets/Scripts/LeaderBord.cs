
using UnityEngine;
using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun.UtilityScripts;

public class LeaderBord : MonoBehaviour
{
    public RoomManager room;
    //private string viewScore;
    public GameObject playerHolder;

    [Header("Options")] 
    public float refreshRate = 1f;

    [Header("UI")] 
    public GameObject[] slots;

    [Space]
    public TextMeshProUGUI[] scoreTexts;
    public TextMeshProUGUI[] nameTexts;

    private void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);

        }

        var sortedPlayerList = (from player in PhotonNetwork.PlayerList orderby player.GetScore() descending select player).ToList();
        int i = 0;
        foreach (var player in sortedPlayerList)
        {
            slots[i].SetActive(true);

            if(player.NickName == "")
               player.NickName = "unnamed";


            nameTexts[i].text = player.NickName;
            room=FindObjectOfType<RoomManager>();
            // viewScore = weapon.score.ToString();
            // Debug.Log(weapon.score);
             scoreTexts[i].text = player.GetScore().ToString();
            scoreTexts[i].text = room.score.ToString();
            i++;
        }
    }

    private void Update()
    {
        playerHolder.SetActive(Input.GetKey(KeyCode.Tab));
    }
}

