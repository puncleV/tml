using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int units;
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
        Vector2 newPosition = new Vector2(newX, transform.position.y);
        transform.position = newPosition;
    }
}
