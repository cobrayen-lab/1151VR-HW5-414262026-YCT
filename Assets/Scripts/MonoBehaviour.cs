
using UnityEngine;

public class TrainerThrowTest : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Throw");
        }
    }
}
