using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public float spawnSpeed;
    public GameObject boost;
    public Transform launch;
	// Use this for initialization
	void Start () {
        
        InvokeRepeating("Boost", 0, spawnSpeed);
    }
    private void Boost()
    {
        Instantiate(boost, launch.position, Quaternion.Euler(0, 0, launch.rotation.z));
    }
}
