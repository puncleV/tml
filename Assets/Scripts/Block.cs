using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip destroySound;
    [SerializeField] int score = 10;

    Level level;
    GameState gameState;

    public int getScore ()
    {
        return this.score;
    }

    private void Start()
    {
        cacheReferences();

        level.blockInitialized();
    }

    private void cacheReferences()
    {
        gameState = FindObjectOfType<GameState>();
        level = FindObjectOfType<Level>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(--health == 0)
        {
            destroy();
        }
    }

    private void destroy()
    {
        gameState.onBlockDestroied();
        AudioSource.PlayClipAtPoint(destroySound, transform.position);
        level.onBlockDestroied(this);
        Destroy(gameObject);
    }
}
