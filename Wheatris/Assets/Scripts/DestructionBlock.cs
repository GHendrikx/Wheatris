using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// AI Class
/// </summary>
public class DestructionBlock : Block
{
    private delegate void ForceBlock(float speed);
    private event ForceBlock forceBlock;

    private float force;
    [SerializeField]
    private float damage;

    [SerializeField]
    private float timer;
    private float beginTimerValue;

    [SerializeField]
    private int[] randomXPositionRange;

    protected override void Start()
    {
        int _randomXPosition = Random.Range(randomXPositionRange[0], randomXPositionRange[1]);
        //This line place the AI on a random x position
        transform.position = new Vector3((float)_randomXPosition, transform.position.y, transform.position.z);

        force = movementMultiplier;
        forceBlock += Move;
        beginTimerValue = timer;
    }

    protected override void Update()
    {
        base.Update();

        forceBlock.Invoke(force);

        if (Timer() < 0)
        {
            force = (force == movementMultiplier) ? force = -movementMultiplier : force = movementMultiplier;
            timer = beginTimerValue;
        }
    }

    public override void OnCollisionEnter(Collision _coll)
    {
        IDamagable _damagable = _coll.gameObject.GetComponent<IDamagable>();

        if (_coll.gameObject.layer == LayerMask.NameToLayer("Ground") || _damagable != null)
        {
            if (_damagable != null)
            {
                _damagable.GetDamage(damage);
                ScoreManager.Instance.UpdateScore(-1, 0);
            }

            Pool.Instance.ReturnObjectToPool<Block>(this);
            onHitGround?.Invoke(this);
        }
    }

    protected override void OnBecameInvisible()
    {
        Pool.Instance.ReturnObjectToPool<DestructionBlock>(this);
    }

    private float Timer()
    {
        return timer -= Time.deltaTime;
    }
}
