using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed = 7.0f;
    Vector3 dir;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void setDirection(Vector3 d)
    {
        dir = d.normalized;
        transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI + 90);
    }
}
