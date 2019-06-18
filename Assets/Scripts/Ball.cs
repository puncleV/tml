using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle mainPaddle;
    [SerializeField] float lauchVelocityX;
    [SerializeField] float lauchVelocityY;

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
        GetComponent<Rigidbody2D>().velocity = new Vector2(lauchVelocityX, lauchVelocityY);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
