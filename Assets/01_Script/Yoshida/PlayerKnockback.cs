using System.Collections;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.5f;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void Knockback()
    {
        StartCoroutine(KnockbackRoutine());
    }

    IEnumerator KnockbackRoutine()
    {
        float timer = 0f;

        while (timer < knockbackDuration)
        {Debug.Log("ccc");
            Vector3 knockbackDirection = -transform.forward; // Œã‚ë•ûŒü
            playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
