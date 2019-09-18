using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    /// <summary>
    /// The amount of player blocks
    /// </summary>
    private int amountOfPlayerBlocks = 0;

    /// <summary>
    /// The amount of AI blocks
    /// </summary>
    private int amountOfAIBlocks = 0;
    private float delay = 3;
    public void Start()
    {
        GenerateNewBlock<PlayerBlock>();
    }

    /// <summary>
    /// Generating the new block.
    /// </summary>
    public void GenerateNewBlock<T>() where T : Block
    {
        T _block = Pool.Instance.GetObjectFromPool<T>();

        _block.gameObject.SetActive(true);
        _block.onHitGround += BlockHitGround;
        
        if (typeof(T) == typeof(PlayerBlock))
        {
            ScoreManager.Instance.UpdateScore(1, 0);
            amountOfPlayerBlocks++;
        }
        else
        {
            ScoreManager.Instance.UpdateScore(0, 1);
            amountOfAIBlocks++;
        }

    }

    /// <summary>
    /// HitGround of block
    /// </summary>
    /// <param name="_block"></param>
    private void BlockHitGround(Block _block)
    {
        _block.onHitGround -= BlockHitGround;

        if (amountOfPlayerBlocks < 10)
        {
            GenerateNewBlock<PlayerBlock>();
            amountOfPlayerBlocks++;
        }

        else if (amountOfAIBlocks < 10)
        {
            amountOfAIBlocks++;

            GenerateNewBlock<DestructionBlock>();
        }
        //else show win or lose screen.
        else
        {
            ScoreManager.Instance.Invoke("ShowEndScreen",delay);
        }
    }
}
