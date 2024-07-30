using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// f3610a01-731b-480c-b58c-0e090a363b26

public class PlayerController : MonoBehaviour
{
    // 람다식 기호 발음 : go to, goes to
    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");
    private float r => Input.GetAxis("Mouse X");
    private bool isFire => Input.GetMouseButtonDown(0);

    private PhotonView pv;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePos;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        //this.enabled = pv.IsMine;
        firePos = transform.Find("Body/Gun/FirePos");
    }

    void Update()
    {
        if (pv.IsMine == false) return;

        // 이동 및 회전 처리
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * 6.0f);
        transform.Rotate(Vector3.up * Time.deltaTime * r * 200.0f);

        // 발사로직
        if (isFire)
        {

        }
    }
}
