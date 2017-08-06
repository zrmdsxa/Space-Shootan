using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyF1 : MonoBehaviour {

    public float speed = 1;

    public Transform bullet;

    public float MAXDELAY = 1.0f;
    public float MINDELAY = 0.5f;
    float nextShot = 1f;

    Vector3 move;

    public Transform soundFire;

    // Use this for initialization
    void Start()
    {
        Vector3 target;
        if (GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player").transform.position;
        }

        else
        {
            target = Vector3.zero;
        }
        //Debug.Log(target);
        move = target - transform.position;
        move = move.normalized;
        //Debug.Log(Mathf.Atan2(move.y, move.x)*180/Mathf.PI);
        transform.Rotate(0, 0, Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg + 90);

    }
	
	// Update is called once per frame
	void Update () {

        transform.position+=(move * speed * Time.deltaTime);
        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 7.25f, 0);
        }

        if (nextShot <= 0)
        {
            Transform b = Instantiate(bullet);
            b.position = transform.position;
            EnemyBullet eb = b.GetComponent("EnemyBullet") as EnemyBullet;
            eb.setDirection(move);
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
