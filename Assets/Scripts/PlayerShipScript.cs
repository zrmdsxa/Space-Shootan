using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour {

    public float speed = 5.0f;

    public Transform bullet;

    public Transform effect;
    public Transform soundFire;
    public Transform soundDie;

    public float MAXDELAY = 1.0f;
    float currentDelay = 0.0f;

    bool dead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (currentDelay > 0.0f)
        {
            currentDelay -= Time.deltaTime;
        }

        fire();
        move();
        
    }

    private void FixedUpdate()
    {
        
    }

    void checkBounds()
    {
        if (transform.position.x <= -7.25f)
        {
            transform.position = new Vector3(-7.25f, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= 7.25f)
        {
            transform.position = new Vector3(7.25f, transform.position.y, transform.position.z);
        }
    }
    void move()
    {
        float move = Input.GetAxis("Horizontal");
        float velocity = move * Time.deltaTime * speed;
        transform.Translate(velocity, 0, 0);
        checkBounds();
    }

    void fire()
    {
        if (currentDelay <= 0)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Transform b = Instantiate(bullet) as Transform;
                b.position = transform.position;
                Instantiate(soundFire);
                currentDelay = MAXDELAY;
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "EnemyBullet" || collision.tag == "Enemy")
        {
            if (!dead)
            {
                dead = true;
                ManagerScript ms = GameObject.Find("Manager").GetComponent("ManagerScript") as ManagerScript;
            
                ms.killPlayer();

                Transform e = Instantiate(effect);
                e.position = transform.position;
                Instantiate(soundDie);
                Destroy(this.gameObject);
            }
        }
    }
}

