
using UnityEngine;

public class PokeBallCollision : MonoBehaviour
{
    public GameObject captureEffect;

    private bool captured = false;

    void OnTriggerEnter(Collider other)
    {
        if (captured) return;
        if (!other.CompareTag("Pokemon")) return;

        captured = true;

        Debug.Log("精靈球命中寶可夢！");

        // 從被碰撞物件向上尋找 CaptureTarget
        Transform pokemon = other.transform;

        Transform target = FindCaptureTarget(pokemon);

        // 優先使用 CaptureTarget 的座標
        Vector3 effectPosition =
            target != null
            ? target.position
            : other.bounds.center;

        if (captureEffect != null)
        {
            GameObject effect = Instantiate(
                captureEffect,
                effectPosition,
                Quaternion.identity
            );

            effect.SetActive(true);

            ParticleSystem[] particles =
                effect.GetComponentsInChildren<ParticleSystem>(true);

            foreach (ParticleSystem ps in particles)
            {
                ps.gameObject.SetActive(true);
                ps.Clear(true);
                ps.Play(true);
                ps.Emit(100);
            }

            Debug.Log("特效位置：" + effectPosition);

            Destroy(effect, 4f);
        }
        else
        {
            Debug.LogError("CaptureEffect 沒有指定！");
        }

        // 移除寶可夢
        Destroy(other.transform.root.gameObject);

        // 移除精靈球
        Destroy(gameObject);
    }

    Transform FindCaptureTarget(Transform hit)
    {
        Transform current = hit;

        while (current != null)
        {
            Transform target =
                current.Find("CaptureTarget");

            if (target != null)
                return target;

            current = current.parent;
        }

        return null;
    }
}
