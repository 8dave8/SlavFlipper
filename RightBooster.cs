using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBooster : MonoBehaviour {
    
    public HingeJoint2D hinge2D2;
    public Rigidbody2D rb2d2;
    private JointMotor2D motorRef;
    // Use this for initialization
    void Start()
    {
        rb2d2.GetComponent<Rigidbody2D>();
        hinge2D2.GetComponent<HingeJoint2D>();
        motorRef = hinge2D2.motor;
        hinge2D2.useMotor = true;
        motorRef.motorSpeed = -500;
        hinge2D2.motor = motorRef;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            var touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                motorRef.motorSpeed = 1500;
                hinge2D2.motor = motorRef;
            }
        }
        else
        {
            motorRef.motorSpeed = -500;
            hinge2D2.motor = motorRef;
        }
    }
    
}
