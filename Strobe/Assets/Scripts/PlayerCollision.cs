using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Movement movement;
    public Rigidbody rb;
    public float NewCrystal = 0f;
    public float Drag = 0.001f;
    public ParticleSystem Ps;
    public ParticleSystem Hyper;
    public ParticleSystem particleSystemPrefab;
    public bool enableSpark = true;

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            rb.useGravity = true;
            rb.drag = Drag;
            Ps.Stop();
            Hyper.Stop();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnTriggerEnter (Collider target)
    {
        if (target.tag == "Space")
        {
            movement.enabled = false;
            rb.useGravity = false;
            Ps.Stop();
            Hyper.Stop();
            FindObjectOfType<GameManager>().EndGame();
        }

        if (target.tag == "Crystal")
        {
            NewCrystal = NewCrystal + 1f;
            Destroy(target);
        }
    }
    
    void OnCollisionStay(Collision collisionInfo)
    {
        if (rb.velocity.x < 2 && rb.velocity.z < 2 && rb.velocity.y < 2 )
        {
            enableSpark = false;
        }
        if (enableSpark == true)
        {
            foreach (ContactPoint contact in collisionInfo.contacts)
            {
                Instantiate(particleSystemPrefab, contact.point, Quaternion.identity);
            }
        }
    }
}