using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D turnCharachter;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueAmount = 1f;

    [SerializeField] float boostedSkiSpeed = 30f;

    [SerializeField] float baseSkiSpeed = 20f;
    [SerializeField] public TextMeshProUGUI _totalSpins;
    float lastRotation = 0f;
    float cumulativeRotationCW = 0f;
    float cumulativeRotationCCW = 0f;   

    int totalSpin = 0;

    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        turnCharachter = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        lastRotation = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rotatePlayer();
            boostPlayer();
            countSpins();
        }
    }

    void boostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            surfaceEffector2D.speed = boostedSkiSpeed;
        }

        else
        {

            surfaceEffector2D.speed = baseSkiSpeed;
        }

    }

    public void disableMove()
    {

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

    void countSpins()
    {
        float currentRotation = transform.eulerAngles.z;
        float delta = Mathf.DeltaAngle(lastRotation, currentRotation);

        if (delta > 0f)
        {
            // Saat yönünün tersine dönüyor (CCW)
            cumulativeRotationCCW += delta;
            cumulativeRotationCW = 0f; // ters yönde döndüğü için sıfırla
        }
        else if (delta < 0f)
        {
            // Saat yönünde dönüyor (CW)
            cumulativeRotationCW -= delta; // delta < 0 olduğu için işareti değiştir
            cumulativeRotationCCW = 0f; // ters yönde döndüğü için sıfırla
        }

        if (cumulativeRotationCW >= 360f)
        {
            totalSpin++;
            cumulativeRotationCW = 0f;
            Debug.Log("CW Spin! Total spins: " + totalSpin);
        }

        if (cumulativeRotationCCW >= 360f)
        {
            totalSpin++;
            cumulativeRotationCCW = 0f;
            Debug.Log("CCW Spin! Total spins: " + totalSpin);
        }

        lastRotation = currentRotation;
        string spinText = "Total Spins: ";
        spinText += totalSpin;
        if (spinText != _totalSpins.text)
            _totalSpins.text = spinText;
    }

}


