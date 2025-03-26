using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data { get; private set; }
    public Inventory inventory;
    public PlayerStateMachine stateMachine;
    public CharacterController Controller;
    private Vector3 moveDirection;
    private float changeDirectionTime = 2f; // 방향 변경 간격
    private float timer;
    private float moveSpeed = 2f;
    private float gravity = 9.81f;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0;
        }

        ApplyGravity();
        Controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void ChangeDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    private void ApplyGravity()
    {
        if (!Controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }

    private void Awake()
    {
        stateMachine = new(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}
