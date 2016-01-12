using UnityEngine;
using System.Collections;

public class SynchNet : MonoBehaviour, IPunObservable
{
    Animator _animator;
    PhotonView _PhotonView;
    Vector3 target = Vector3.zero;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _PhotonView = GetComponent<PhotonView>();

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isReading != true)
            stream.SendNext(transform.position);
        else
            target = (Vector3)stream.ReceiveNext();
    }


    void Update()
    {
        if (!_PhotonView.isMine)
        {
            Vector3 tmp = target;
            tmp.y = transform.position.y;
            float dis = (transform.position - tmp).magnitude;
            if (dis > 5.0f)
            {
                transform.position = target;
                dis = 0;
            }
            else
            {
                if (dis > 0.250f)
                {
                    transform.LookAt(tmp);
                }
                else
                {
                    dis = 0;
                }
            }
            _animator.SetFloat("Speed", dis / 1.5f );
        }

    }
}
