
using UnityEngine;

public class TrainerThrow : MonoBehaviour
{
    public Animator animator;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public Transform pokemonTarget;

    public float throwSpeed = 10f;
    public float upwardSpeed = 2f;

    private bool isThrowing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isThrowing)
        {
            isThrowing = true;
            animator.SetTrigger("Throw");
        }
    }

    // 動畫事件：投出精靈球
    
public float flightTime = 1.0f;

public void ReleaseBall()
{
    if (!isThrowing || ballPrefab == null ||
        ballSpawnPoint == null || pokemonTarget == null)
    {
        Debug.LogWarning("投擲設定不完整！");
        return;
    }

    GameObject ball = Instantiate(
        ballPrefab,
        ballSpawnPoint.position,
        Quaternion.identity
    );

    Rigidbody rb = ball.GetComponent<Rigidbody>();

    if (rb == null)
    {
        Debug.LogError("精靈球缺少 Rigidbody");
        Destroy(ball);
        return;
    }

    rb.isKinematic = false;
    rb.useGravity = true;
    rb.constraints = RigidbodyConstraints.None;

    Vector3 start = ballSpawnPoint.position;
    Vector3 target = pokemonTarget.position;

    float t = Mathf.Max(0.1f, flightTime);

    // 位移 = 初速度 × 時間 + 1/2 × 重力 × 時間平方
    // 反推初速度
    Vector3 velocity =
        (target - start - 0.5f * Physics.gravity * t * t) / t;

    rb.linearVelocity = velocity;

    Debug.Log("精靈球投擲速度：" + velocity);

    Destroy(ball, 5f);
}

    // 動畫事件：結束投擲
    public void FinishThrow()
    {
        isThrowing = false;
    }
}
