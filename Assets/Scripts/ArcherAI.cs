using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherAI : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    [Header("Player")]
    [SerializeField] GameObject player;


    public bool isFiring = true;
    Coroutine firingCoroutine;

    void Start()
    {
        FireProjectile();
    }

    void Update()
    {
        transform.rotation = GetRotationTowardsPlayer();
    }

    void FireProjectile()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    Quaternion GetRotationTowardsPlayer()
    {


        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle - 180));
    }


    IEnumerator FireContinuously()
    {
        while (true)
        {
            if (player == null)
            {
                isFiring = false;
                yield break;
            }

            Quaternion targetRotation = GetRotationTowardsPlayer();

            GameObject newProjectile = Instantiate(projectile, transform.position, targetRotation);
            Rigidbody2D projectileRigidbody = newProjectile.GetComponent<Rigidbody2D>();

            Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;

            // Normalize the direction and multiply by bullet speed.
            direction.Normalize();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.velocity = direction * projectileSpeed;
            }

            Destroy(newProjectile, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
