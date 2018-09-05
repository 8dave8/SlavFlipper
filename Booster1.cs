using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster1 : MonoBehaviour {
    //Paddle Left
    public HingeJoint2D hinge2D;
    public Rigidbody2D rb2d;
    private JointMotor2D motor;
    //Paddle Right
    public HingeJoint2D hinge2D2;
    public Rigidbody2D rb2d2;
    private JointMotor2D motorRef;
    void Start ()
    {
        //Paddle Left
        rb2d.GetComponent<Rigidbody2D>();
        hinge2D.GetComponent<HingeJoint2D>();
        motor = hinge2D.motor;
        hinge2D.useMotor = true;
        motor.motorSpeed = 500;
        hinge2D.motor = motor;
        //Paddle Right
        rb2d2.GetComponent<Rigidbody2D>();
        hinge2D2.GetComponent<HingeJoint2D>();
        motorRef = hinge2D2.motor;
        hinge2D2.useMotor = true;
        motorRef.motorSpeed = -500;
        hinge2D2.motor = motorRef;
    }
    void  Update()
    {
        if (Input.touchCount > 1)
        {
            var input1 = Input.GetTouch(0);
            Debug.Log("input1");
            var input2 = Input.GetTouch(1);
            Debug.Log("input2");
            if (input1.position.x < Screen.width / 2 && input2.position.x > Screen.width / 2)
            {
                motor.motorSpeed = -1500;
                motorRef.motorSpeed = 1500;
                hinge2D.motor = motor;
                hinge2D2.motor = motorRef;
            }
            if (input2.phase == TouchPhase.Ended )
            {
                Debug.Log("input2ENDED");
                if (input1.position.x < Screen.width / 2)
                {
                    motorRef.motorSpeed = -500;
                    hinge2D2.motor = motorRef;
                    Debug.Log("Jobble");
                }
                if (input1.position.x > Screen.width / 2)
                {
                    motor.motorSpeed = 500;
                    hinge2D.motor = motor;
                    Debug.Log("Balle");
                }
            }
            else if (input1.phase == TouchPhase.Ended)
            {
                Debug.Log("input1ENDED");
                if (input2.position.x < Screen.width / 2)
                {
                    motorRef.motorSpeed = -500;
                    hinge2D2.motor = motorRef;
                    Debug.Log("Jobble");
                }
                if (input2.position.x > Screen.width / 2)
                {
                    motor.motorSpeed = 500;
                    hinge2D.motor = motor;
                    Debug.Log("Balle");
                }
            }
        }
        else if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                Debug.Log("balFEL");
                motor.motorSpeed = -1500;
                hinge2D.motor = motor;
            }
            if (touch.position.x > Screen.width / 2)
            {
                Debug.Log("Jobbfel");
                motorRef.motorSpeed = 1500;
                hinge2D2.motor = motorRef;
            }
        }
        else
        {
            motor.motorSpeed = 500;
            motorRef.motorSpeed = -500;
            hinge2D.motor = motor;
            hinge2D2.motor = motorRef;
        }
    }
    
}
