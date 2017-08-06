using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveThis : MonoBehaviour {

    public float delay = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (delay > 0f)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
