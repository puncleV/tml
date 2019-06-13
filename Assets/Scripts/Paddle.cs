using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int units;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.move();
    }

    private void move()
    {
        float newX = Input.mousePosition.x / Screen.width * units;

        transform.position = this.getNewXPosition(newX);
    }

    private Vector2 getNewXPosition(float newX)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        currentPosition.x = Mathf.Clamp(newX, minX, maxX);
        return currentPosition;
    }
}
