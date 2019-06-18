using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip destroySound;
    [SerializeField] int points = 10;

    Level level;
    GameState gameState;

    public int getPoints ()
    {
        return this.points;
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
        this.changeGameState();
        AudioSource.PlayClipAtPoint(destroySound, transform.position);
        level.onBlockDestroied();
        Destroy(gameObject);
    }

    private void changeGameState ()
    {
        gameState.addToScore(this.points);
        gameState.increaseSpeed();
    }
}
