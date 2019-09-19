using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : Block
{
    /// <summary>
    /// Object Subscribe to the Movement delegates. 
    /// </summary>
    protected override void Start()
    {
        InputManager.Instance.horizontalMovement += Move;
        InputManager.Instance.rotateMovement += Rotate;
    }

    /// <summary>
    /// For performance optimizing
    /// </summary>
    protected override void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        
    }

    protected override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// unsubscribing to the event when the block collide with the ground.
    /// </summary>
    public override void OnCollisionEnter(Collision _coll)
    {
        base.OnCollisionEnter(_coll);

        Block _block = _coll.gameObject.GetComponent<Block>();

        if (_coll.gameObject.layer == LayerMask.NameToLayer("Ground") || _block != null)
        {
            InputManager.Instance.horizontalMovement -= Move;
            InputManager.Instance.rotateMovement -= Rotate;
        }
    }
}
