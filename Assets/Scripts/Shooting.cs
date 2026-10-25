using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Camera FPSCamera;
    public float fireRate = 0.1f;
    float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
        if(Input.GetButton("Fire1") && fireTimer >= fireRate)
        {
            fireTimer = 0.0f;
            RaycastHit _hit;
            Ray ray = FPSCamera.ViewportPointToRay(new Vector3 (0.5f,0.5f));
            if (Physics.Raycast(ray, out _hit, 100f))
            {
                Debug.Log(_hit.collider.gameObject.name);
                if(_hit.collider.gameObject.CompareTag("Player") && !_hit.collider.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    _hit.collider.gameObject.GetComponent<PhotonView>().RPC("takeDamage",RpcTarget.AllBuffered, 10f);
                }
            }
        }
    }
}
