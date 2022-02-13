using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D turnCharachter;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueAmount=1f;

    [SerializeField] float boostedSkiSpeed=30f;

    [SerializeField] float baseSkiSpeed=20f;

    int totalSpin=0;

    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        turnCharachter = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove){
            rotatePlayer();
            boostPlayer();
        }
    }

    void boostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow)){

            surfaceEffector2D.speed=boostedSkiSpeed;
            totalSpin++;
        }

        else{

            surfaceEffector2D.speed=baseSkiSpeed;
            totalSpin++;
        }

    }

    public void disableMove(){

        canMove = false;
    }

    private void rotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnCharachter.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turnCharachter.AddTorque(-torqueAmount);
        }
    }

}


