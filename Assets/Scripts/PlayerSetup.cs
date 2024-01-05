using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public Movement movement;

    public GameObject camera;
    // Start is called before the first frame update
    public void IsLocalPlayer(){
    movement.enabled = true;
    camera.SetActive(true);
}
}
