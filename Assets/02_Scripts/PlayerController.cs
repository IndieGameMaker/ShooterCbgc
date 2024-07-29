using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // go to, goes to
    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");
    private float r => Input.GetAxis("Mouse X");

    void Start()
    {

    }

    void Update()
    {
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * 6.0f);
    }
}
