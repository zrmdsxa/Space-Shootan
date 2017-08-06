using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUFO : MonoBehaviour {

    public float speed = 3;

    public Transform bullet;

    public float MAXDELAY = 1.0f;
    public float MINDELAY = 0.5f;
    float nextShot = 1f;

    public Transform soundFire;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(10, Random.Range(3, 6), 0);
        }

        if (nextShot <= 0)
        {
            Transform b = Instantiate(bullet);
            b.position = transform.position;
            EnemyBullet eb = b.GetComponent("EnemyBullet") as EnemyBullet;
            eb.setDirection(Vector3.down);
            Instantiate(soundFire);
            nextShot = Random.Range(MINDELAY, MAXDELAY);
        }
        else
        {
            nextShot -= Time.deltaTime;
        }
    }

    
    void deletThis()
    {
        Destroy(this.gameObject);
    }

}
