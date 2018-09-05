using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterDestroy : MonoBehaviour {
    public float lifetime;
	// Use this for initialization
	void Awake () {
        Destroy(gameObject, lifetime);
	}

}
