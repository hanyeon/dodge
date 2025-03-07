using UnityEngine;

public class Bullet : MonoBehaviour
{ public float speed = 8f;

    private Rigidbody bulletRigidbody;

        void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 3f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playercontroller = other.GetComponent <PlayerController>();

            if (playercontroller != null)
                playercontroller.Die();

                   
        }
    }
}