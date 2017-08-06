using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour {

    public int points = 1000;
    public Transform effect;
    public Transform soundDie;

    bool dead = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collision.tag == "PlayerBullet")
        {
            if (!dead)
            {
                dead = true;
                Destroy(collision.gameObject);
                ManagerScript ms = GameObject.Find("Manager").GetComponent("ManagerScript") as ManagerScript;
                ms.killEnemy(points);
                Transform e = Instantiate(effect);
                e.position = transform.position;
                deletThis();
            }
        }
    }
    void deletThis()
    {
        Instantiate(soundDie);
        Destroy(this.gameObject);
    }
}
