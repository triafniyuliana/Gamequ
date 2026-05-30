using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject bullet;

    public float bulletSpeed = 40f;
    public float destroyTime = 1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject cb = Instantiate(
            bullet,
            spawnPosition.position,
            spawnPosition.rotation
        );

        Rigidbody rb = cb.GetComponent<Rigidbody>();

        rb.linearVelocity = spawnPosition.forward * bulletSpeed;

        Destroy(cb, destroyTime);
    }
}