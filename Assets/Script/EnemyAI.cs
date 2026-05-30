using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private Transform currentTarget;

    public int health = 5;

    void Start()
    {
        currentTarget = pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        float distance = Vector3.Distance(
            transform.position,
            currentTarget.position
        );

        if(distance <= 0.05f)
        {
            if(currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kena: " + collision.gameObject.name);

        if(collision.gameObject.CompareTag("Bullet"))
        {
            health--;

            Destroy(collision.gameObject);

            Debug.Log("Health: " + health);

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}