using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private FullPlayerController player;

    [SerializeField] protected int health;
    [SerializeField] protected float genericStateTimer;
    [SerializeField] protected Transform pathingDestination;

    protected enum EnemyState
    {
        IDLE = 0,
        WANDER = 1,
        CHASE = 2,
        FIND = 3,
        ATTTACK = 4
    }

    [SerializeField] protected EnemyState myState;
    [SerializeField] protected EnemyState afterIdleState;

    void Start()
    {
        player = FindAnyObjectByType<FullPlayerController>();
        myState = EnemyState.IDLE;
        genericStateTimer = 1.0f;
        afterIdleState = EnemyState.WANDER;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    protected void ChangeState(EnemyState state, float idleTime = 0.0f)
    {
        if (idleTime == 0.0f)
        {
            myState = state;
        }
        else
        {
            afterIdleState = state;
            myState = EnemyState.IDLE;
            genericStateTimer = idleTime;
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (Vector3.Distance(transform.position,player.transform.position) < 10.0f)
        {

        }

        switch (myState)
        {
            case EnemyState.IDLE:
                IdleState();
                break;
            case EnemyState.WANDER:
                WanderState();
                break;
            case EnemyState.CHASE:
                ChaseState();
                break;
            case EnemyState.FIND:
                FindState();
                break;
            case EnemyState.ATTTACK:
                AttackState();
                break;
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void IdleState()
    {
        genericStateTimer -= Time.deltaTime;
        if (genericStateTimer <= 0.0f)
        {
            myState = afterIdleState;
        }
    }

    protected virtual void WanderState()
    {
        transform.position = Vector3.MoveTowards(transform.position, pathingDestination.position, Time.deltaTime);
        transform.LookAt(pathingDestination,Vector3.up);
    }

    protected virtual void ChaseState()
    {

    }

    protected virtual void FindState()
    {

    }

    protected virtual void AttackState()
    {

    }
}
