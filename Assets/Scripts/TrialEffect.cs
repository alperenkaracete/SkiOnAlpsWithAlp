using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialEffect : MonoBehaviour
{

    [SerializeField] ParticleSystem skiTrial;
    void Update()
    {
    
    }
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "Player"){
            skiTrial.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D other) {
        skiTrial.Stop();
    }

}
