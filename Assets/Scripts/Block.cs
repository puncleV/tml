using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip destroySound;

    BlockCounter blockCounter;
    GameState gameState;

    private void Start()
    {
        cacheReferences();

        blockCounter.add();
    }

    private void cacheReferences()
    {
        gameState = FindObjectOfType<GameState>();
        blockCounter = FindObjectOfType<BlockCounter>();
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
        blockCounter.delete();
        Destroy(gameObject);
    }
}
