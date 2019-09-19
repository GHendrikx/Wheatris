using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour, IDamagable
{

    [SerializeField]
    private Rigidbody myRb;

    [Range(0, 1)]
    [SerializeField]
    private float rotateMultiplier;
    [Range(0, 1)]
    [SerializeField]
    protected float movementMultiplier;

    [Range(0, 10)]
    [SerializeField]
    private float gravityModifier;

    public delegate void BlockCallBack(Block b);
    public BlockCallBack onHitGround;

    public float Hitpoints
    {
        get;
        set;
    }

    protected abstract void Start();

    protected abstract void OnBecameInvisible();

    protected virtual void Update()
    {
        Fall();
    }

    /// <summary>
    /// Get damage on the block
    /// </summary>
    /// <param name="_damage"></param>
    public void GetDamage(float _damage)
    {
        Hitpoints -= _damage;
        if (Hitpoints < 0)
            Pool.Instance.ReturnObjectToPool<Block>(this);
    }

    /// <summary>
    /// Falling gravity
    /// </summary>
    private void Fall()
    {
        myRb.AddForce(Vector3.down * gravityModifier);
    }

    /// <summary>
    /// Rotating the Tetris block
    /// </summary>
    /// <param name="rotateMultiplier"></param>
    public void Rotate(float _rotate)
    {
        myRb.AddTorque(new Vector3(myRb.rotation.x, myRb.rotation.y, myRb.rotation.z + (_rotate * rotateMultiplier)));
    }

    /// <summary>
    /// Moving the Tetris block
    /// </summary>
    /// <param name="moveMultiplier"></param>
    public void Move(float _movement)
    {
        Vector3 _vector = new Vector3(_movement * movementMultiplier, 0, 0);
        myRb.MovePosition(transform.position + _vector);
    }

    /// <summary>
    /// When the block hit the ground or a block it will update Delegates 
    /// </summary>
    public virtual void OnCollisionEnter(Collision _coll)
    {
        if (_coll.gameObject.layer == LayerMask.NameToLayer("Wall"))
            return;

        onHitGround?.Invoke(this);
    }
}
