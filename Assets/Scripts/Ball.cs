using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle mainPaddle;
    [SerializeField] float lauchVelocityX;
    [SerializeField] float lauchVelocityY;
    [SerializeField] float randomFactor = 0.4f;
    [SerializeField] AudioClip[] sounds;

    AudioSource audoioSource;
    Rigidbody2D rigidBody;

    BallState state = BallState.ON_PADDLE;
    Vector2 vectorToPaddle;

    public enum BallState
    {
        ON_PADDLE,
        FREE_MOVEMENT
    }
    // Start is called before the first frame update
    void Start()
    {
        vectorToPaddle = transform.position - mainPaddle.transform.position;
        audoioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BallState.ON_PADDLE:
                this.stayOnPaddle();
                this.launchBallOnClick();
            break;
        }
    }

    private void launchBallOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            state = BallState.FREE_MOVEMENT;
            this.launchBall();
        }
    }

    private void stayOnPaddle()
    {
        Vector2 paddlePosition = new Vector2(mainPaddle.transform.position.x, mainPaddle.transform.position.y);

        transform.position = paddlePosition + vectorToPaddle;
    }

    private void launchBall ()
    {
        rigidBody.velocity = new Vector2(lauchVelocityX, lauchVelocityY);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (state == BallState.FREE_MOVEMENT)
        {
            playCollisionSound();
            this.tweakVelocity();
        }
    }

    private void tweakVelocity ()
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomFactor),
            Random.Range(0, randomFactor)
        );

        rigidBody.velocity += velocityTweak;
    }

    private void playCollisionSound ()
    {
        if (sounds.Length == 0)
        {
            Debug.LogError("Missed audio for ball collision");
            return;
        }

        audoioSource.PlayOneShot(getRandomSound());
    }

    private AudioClip getRandomSound()
    {
        int index = Random.Range(0, sounds.Length);

        return sounds[index];
    }
}
