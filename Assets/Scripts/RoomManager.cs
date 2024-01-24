using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy1;

    public int score = 0;

    float x , x1;
    float y ,y1;
    float z ,z1;
    Vector3 pos;
    Vector3 pos1 ,pos2;

    // public Animation _animation;
    // public AnimationClip movejellyfish;


    bool joined=false;

    int joined1=15;

    [Space]
    public Transform  spawnPoint;

    [Space]
    public GameObject roomCam;

    

    [Space]
    public GameObject nameUI;
    public GameObject connectingUI;
    private string nickname="undefined";

    [HideInInspector]
    public int Kills = 0;
    [HideInInspector]
    public int deaths = 0;

    // Start is called before the first frame update

    void Awake() {
        instance = this;
    }

    public void ChangeNickname(string _name) {
        nickname = _name;
    }
    public void JoinRoomButtonPressed() {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }
    void Start()
    {

    }

    void Update()
    {

        if(joined){

                joined1+=10;
                Invoke("Respawnenemy", joined1);
            
        }

    }


    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server!");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null , null);

        Debug.Log("We're Connected and in a room now!");

        Invoke("RespawnPlayer", 10);
        Invoke("Respawnenemy", joined1);

        joined=true;
    }

    // void PhotonInit() {

    //    roomCam.SetActive(false);
    //    GameObject _player = PhotonNetwork.Instantiate (player.name, spawnPoint.position,Quaternion.identity);

    //    _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    //    _player.GetComponent<Health>().IsLocalPlayer = true;


    // }

     public void RespawnPlayer() {

         x = Random.Range(30, 968);
        y = 5;
        z = Random.Range(20, 986);
        pos = new Vector3(x, y, z);


        roomCam.SetActive(false);
        GameObject _player = PhotonNetwork.Instantiate (player.name, spawnPoint.position,Quaternion.identity);

        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<Health>().isLocalPlayer = true;

        _player.GetComponent<PhotonView>().RPC("SetNickName",RpcTarget.All,nickname);
        PhotonNetwork.LocalPlayer.NickName = nickname;
    

    }


public void Respawnenemy() {
        // make player

        // for(int i=0;i<=50;i++){
            x = Random.Range(30, 968);
            y = 5;
            z = Random.Range(20, 986);
            pos1 = new Vector3(x, y, z);


            x1 = Random.Range(30, 968);
            y1 = 5;
            z1 = Random.Range(20, 986);
            pos2 = new Vector3(x1, y1, z1);

            // roomCam.SetActive(false);
            //_animation.Stop();
            GameObject _playert = PhotonNetwork.Instantiate (enemy.name, pos1,Quaternion.identity);
            GameObject _playert1 = PhotonNetwork.Instantiate (enemy1.name,  pos2,Quaternion.identity);
            // _animation.Play(movejellyfish.name);
        //     i+=1;
        // }

       
        // _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        // _player.GetComponent<Health>().isLocalPlayer=true;
        // _player.GetComponent<PhotonView>().RPC("SetNickName",RpcTarget.All,nickname);

    }


    // public void SetHashes()
    // {
    //     try
    // {
    //     Hashtable hash = PhotonNetwork.LocalPlayer.CustomProperties;
    //     hash["Kills"] = Kills;
    //     hash["deaths"] = deaths;
    //     PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    // }
    //     catch
    // {
    //     //do nothing
    // }
    // }


}