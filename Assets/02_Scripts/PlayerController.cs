using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using TMPro;

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
    [SerializeField] private TMP_Text nickName;

    void Start()
    {
        pv = GetComponent<PhotonView>();

        // 닉네임 설정
        nickName.text = pv.Owner.NickName;

        firePos = transform.Find("Body/Gun/FirePos");
        if (pv.IsMine)
        {
            Camera.main.transform.SetParent(this.transform);
            Camera.main.transform.localPosition = new Vector3(0, 5, -5);
            Camera.main.transform.localRotation = Quaternion.Euler(30, 0, 0);
        }
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
            pv.RPC(nameof(Fire), RpcTarget.AllViaServer, PhotonNetwork.NickName);
        }
    }

    [PunRPC]
    void Fire(string nickName)
    {
        var bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        bullet.GetComponent<Bullet>().nickName = nickName;
    }

    private int hp = 100;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
            hp -= 10;
            if (hp <= 0)
            {
                string nickName = coll.gameObject.GetComponent<Bullet>().nickName;
                string msg = $"{pv.Owner.NickName} is killed by {nickName}";
                Debug.Log(msg);
                PlayerDie();
            }
        }
    }

    private void PlayerDie()
    {
        SetVisible(false);
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke(nameof(RespwanPlayer), 3.0f);
    }

    void RespwanPlayer()
    {
        hp = 100;
        SetVisible(true);
        GetComponent<CapsuleCollider>().enabled = true;
    }

    void SetVisible(bool isVisible)
    {
        var meshs = GetComponentsInChildren<MeshRenderer>();
        foreach (var mesh in meshs)
        {
            mesh.enabled = isVisible;
        }
    }

}
