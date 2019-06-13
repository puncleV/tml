using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle mainPaddle;

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
        if (state == BallState.ON_PADDLE)
        {
            Vector2 paddlePosition = new Vector2(mainPaddle.transform.position.x, mainPaddle.transform.position.y);

            transform.position = paddlePosition + vectorToPaddle;
        }
    }
}
