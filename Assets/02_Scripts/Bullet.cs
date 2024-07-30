using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1500.0f);

        Destroy(this.gameObject, 3.0f);
    }

}
