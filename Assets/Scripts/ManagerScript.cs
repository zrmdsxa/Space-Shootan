using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour {

    public Transform gameoverSound;
    public Transform player;

    public Transform ufo;
    public float ufoSpawn = 10.0f; //time to spawn in seconds
    float ufoTimer;

    public Transform f1;
    public float f1Spawn = 6.0f; //time to spawn in seconds
    float f1Timer;

    public Transform f2;
    public float f2Spawn = 7.0f; //time to spawn in seconds
    float f2Timer;

    int score = 0;
    ScoreText st;

    int highscore = 0;
    ScoreText hs;

    int lives = 3;

    bool gameEnded = false;
    bool start = true;

    GameObject gameover;
    GameObject l1;
    GameObject l2;

	// Use this for initialization
	void Start () {
        l1 = GameObject.Find("Lives1");
        l2 = GameObject.Find("Lives2");
        st = GameObject.Find("Score").GetComponent("ScoreText") as ScoreText;
        hs = GameObject.Find("Highscore").GetComponent("ScoreText") as ScoreText;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        hs.setScore(highscore);
        gameover = GameObject.Find("GameOver");
        gameover.SetActive(false);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                newGame();
                GameObject.Find("Start").SetActive(false);
                start = false;
            }
        }
        else
        {
            if (gameEnded && Input.GetKeyDown(KeyCode.Return))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                //newGame();
            }
            if (!gameEnded)
            {
                if (ufoTimer <= 0)
                {
                    Transform u = Instantiate(ufo, new Vector3(10,Random.Range(3, 6),0), Quaternion.identity);
                    ufoTimer = ufoSpawn;
                }
                else
                {
                    ufoTimer -= Time.deltaTime;
                }

                if (f1Timer <= 0)
                {
                    Transform f = Instantiate(f1, new Vector3(Random.Range(-8, 8), 7.25f, 0), Quaternion.identity);
                
                    f1Timer = f1Spawn;
                }
                else
                {
                    f1Timer -= Time.deltaTime;
                }

                if (f2Timer <= 0)
                {
                    Transform f = Instantiate(f2,new Vector3(Random.Range(-8, 8), 7.25f, 0), Quaternion.identity);
                    f.position = new Vector3(Random.Range(-8, 8), 7.25f, 0);
                    f2Timer = f2Spawn;
                }
                else
                {
                    f2Timer -= Time.deltaTime;
                }
            }
        }
        
    }

    public void killEnemy(int e)
    {
        score += e;
        st.setScore(score);
    }

    public void killPlayer()
    {
        lives--;
        Debug.Log(lives);
        if (lives > 0)
        {
            
            if (lives == 2)
            {
                l2.SetActive(false);
            }
            if (lives == 1)
            {
                l1.SetActive(false);
            }
            StartCoroutine(SpawnPlayer());
            Debug.Log(lives);
        }
        else
        {
            Instantiate(gameoverSound);
            gameEnded = true;
            gameover.SetActive(true);
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                hs.setScore(highscore);
            }
        }
    }


    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(2);
        Instantiate(player);
    }



    void newGame()
    {
        gameover.SetActive(false);
        lives = 3;
        
        l1.SetActive(true);
        l2.SetActive(true);

        score = 0;
        st.setScore(score);

        Instantiate(player);

        ufoTimer = ufoSpawn;
        f1Timer = f1Spawn;
        f2Timer = f2Spawn;
    }
}
