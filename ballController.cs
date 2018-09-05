using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballController : MonoBehaviour {

    public Rigidbody2D myrb2d;
    public int plusBallpoints = 1;
    public Text countballs;
    public Text countPoints;
    public Text EndText;
    public AudioClip point1;
    public AudioClip point2;
    public AudioClip die11;
    public AudioClip die12;
    public AudioClip die2;
    public AudioClip Bumper1;
    public AudioClip Bumper2;
    public GameObject Deadmenu;
    public GameObject Particles;
    public float maxSpeed;
    private int balls;
    private int points;
	void Start () {
        balls = 3;
        points = 0;
        SetCountBalls();
        SetCountPoints();
	}
    private void Update()
    {
        if (myrb2d.velocity.magnitude > maxSpeed)
        {
            myrb2d.velocity = Vector2.ClampMagnitude(myrb2d.velocity, maxSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Deadzone")
        {
            balls--;
            SoundManager.instance.RandomizeSfx(die11,die12);
            SetCountBalls();
            if (balls == 0)
            {
                SoundManager.instance.playSingle(die2);
                EndText.text = "Out of balls\nYour score: "+points.ToString();
                Restart();
            }
            else transform.position = new Vector2(16f, 19f);
        }
        
        else if (other.tag == "plusOne")
        {
            balls += plusBallpoints;
            SetCountBalls();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Points")
        {
            SoundManager.instance.RandomizeSfx(point1, point2);
            points += 50;
            SetCountPoints();
            Instantiate(Particles, other.transform.position, Quaternion.identity);
            StartCoroutine(Respawn(other.gameObject,8f));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "point200")
        {
            SoundManager.instance.playSingle(Bumper1);
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
            points += 200;
            SetCountPoints();
            StartCoroutine(Color(other.gameObject, 0.2f));
        }
        else if (other.collider.tag == "point500")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.6f);
            SoundManager.instance.playSingle(Bumper2);
            points += 500;
            SetCountPoints();
            StartCoroutine(Color(other.gameObject, 0.2f));
        }
    }
    private void Restart()
    {
        if (points > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", points);
        }
        Deadmenu.SetActive(true);
    }
    void SetCountBalls()
    {
        countballs.text = "Balls: " + balls.ToString();
    }
    void SetCountPoints()
    {
        countPoints.text = "Points: " + points.ToString();
    }
    IEnumerator Respawn(GameObject other, float sec)
    {
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(sec);
        other.gameObject.SetActive(true);
    }
    IEnumerator Color(GameObject utkozo, float sec)
    {
        yield return new WaitForSeconds(sec);
        utkozo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }
}
