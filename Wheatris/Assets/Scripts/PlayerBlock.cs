using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        InputManager.Instance.horizontalMovement += Move;
        InputManager.Instance.rotateMovement += Rotate;
    }

    protected override void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        
    }

    protected override void Update()
    {
        base.Update();
    }
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
