using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public Transform gunHolder;
    public Transform mainCamera;

    private bool isPickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;

            transform.SetParent(gunHolder);

            transform.localPosition = new Vector3(0.3f, -0.2f, 0.5f);

            transform.localRotation = Quaternion.identity;

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.isKinematic = true;
            rb.useGravity = false;

            GetComponent<Collider>().enabled = false;

            GetComponent<ShootingScript>().enabled = true;
        }
    }

    void Update()
    {
        if(isPickedUp)
        {
            transform.rotation = mainCamera.rotation;
        }
    }
}