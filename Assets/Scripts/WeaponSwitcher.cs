using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedWeaopn = 0;
    public Animation _animation;
    public AnimationClip changeWeapons;

    public AudioClip auC;
    public AudioSource auS;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapn();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeaopn;
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            selectedWeaopn = 0;
            auS.PlayOneShot(auC);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            selectedWeaopn = 1;
            auS.PlayOneShot(auC);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            selectedWeaopn = 2;
            auS.PlayOneShot(auC);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            selectedWeaopn = 3;
            auS.PlayOneShot(auC);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            selectedWeaopn = 4;
            auS.PlayOneShot(auC);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            selectedWeaopn = 5;
            auS.PlayOneShot(auC);
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            if(selectedWeaopn <= 0 && selectedWeaopn <= 5){
                selectedWeaopn = transform.childCount + 1;
                auS.PlayOneShot(auC);
            }else{
                selectedWeaopn -=1;
                auS.PlayOneShot(auC);
            }
        }
        if(previousSelectedWeapon != selectedWeaopn){
            SelectWeapn();
        }
    }
    void SelectWeapn(){
        if(selectedWeaopn >= transform.childCount){
            selectedWeaopn = transform.childCount -1;
        }
        _animation.Stop();
        _animation.Play(changeWeapons.name);


        int i = 0;
        foreach (Transform _weapon in transform){
            if(i == selectedWeaopn){
                _weapon.gameObject.SetActive(true);
            }else{
                 _weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
