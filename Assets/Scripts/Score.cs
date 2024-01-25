using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{ 
    public int score=0;
   public TextMeshProUGUI scoreUI;

   void Update(){
        scoreUI.text=score.ToString();
   }

   public void AddScore (){
        score+=1;
        
   }

}
