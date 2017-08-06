using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyF2 : MonoBehaviour {


    public float speed = 1;

    public Transform bullet;

    public float MAXDELAY = 2.0f;
    public float MINDELAY = 1.5f;
    float nextShot = 2f;
    Vector3 target;

    public Transform soundFire;

    // Use this for initialization
    void Start () {
        //target = new Vector3(Random.Range(-12, 12), Random.Range(-6, 7), 0);
        target = new Vector3(Random.Range(-11, 11), Random.Range(0, 6), 0);
        //Debug.Log(target);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log((target - transform.position).sqrMagnitude);
        if ((target-transform.position).sqrMagnitude < 16)
        {
            target = new Vector3(Random.Range(-11, 11), Random.Range(1, 6), 0);
        }
        Vector3 t = target;
        Vector3 pos = transform.position;
        t.x = t.x - pos.x;
        t.y = t.y - pos.y;

        float angle = Mathf.Atan2(t.y, t.x) * Mathf.Rad2Deg + 90;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), 1.0f);

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (nextShot <= 0)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                Transform b = Instantiate(bullet);
                b.position = transform.position;
                EnemyBullet eb = b.GetComponent("EnemyBullet") as EnemyBullet;

                eb.setDirection(GameObject.FindWithTag("Player").transform.position - transform.position);

                Instantiate(soundFire);
                nextShot = Random.Range(MINDELAY, MAXDELAY);
            }
            
        }
        else
        {
            nextShot -= Time.deltaTime;
        }
    }
}
