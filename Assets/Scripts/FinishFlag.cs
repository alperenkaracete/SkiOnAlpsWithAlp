using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{       
    [SerializeField] float NextLevelCounter = 0.5f;
    [SerializeField] ParticleSystem finnishEffect;

    bool finishCount=false;
    void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Player"){
                finnishEffect.Play();
                Invoke ("loadScene",NextLevelCounter);
                if (!finishCount){
                    GetComponent<AudioSource>().Play();
                    finishCount=true;
                }
            }
        }

    void loadScene (){

        SceneManager.LoadScene(0);
    }    

}
