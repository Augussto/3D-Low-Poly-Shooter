using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallRider : MonoBehaviour
{
    public float wallDistance = 1f;
    public float wallrideForce = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        CheckForWallride();
    }

    void CheckForWallride()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.right, out hit, wallDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                Wallride();
            }
        }
    }

    void Wallride()
    {
        // Simplemente aplicar una fuerza hacia arriba
        rb.AddForce(Vector3.up * wallrideForce);
    }
}
