using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterController : MonoBehaviour {

    public float speed;
    public Rigidbody2D r2;
	// Use this for initialization
	void Awake () {
        r2.GetComponent<Rigidbody2D>();
        r2.AddForce(new Vector2(0, 1) * speed, ForceMode2D.Impulse);

	}
	
}
