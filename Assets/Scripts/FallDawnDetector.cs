using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDawnDetector : MonoBehaviour
{
    [SerializeField] float crashDelaynum = 1f;
    [SerializeField] ParticleSystem fallDown;

    [SerializeField] AudioClip soundClip;
    bool falldownCount=false;
    void OnTriggerEnter2D(Collider2D other) {
       if (other.tag == "Ground" && !falldownCount){
            fallDown.Play();     
            GetComponent<PlayerController>().disableMove();   
            falldownCount=true;
            GetComponent<AudioSource>().PlayOneShot(soundClip);
            Invoke ("crashDelay",crashDelaynum);            
       }
   }
   void crashDelay(){

        SceneManager.LoadScene(0);
    }
}
