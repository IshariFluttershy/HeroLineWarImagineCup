using UnityEngine;
using System.Collections;

public class ProtoMovement : MonoBehaviour {

    public NetworkPlayer Owner;

    private Transform trans;
    private NavMeshAgent agent;
    private Vector3 serverCurrentDestination = Vector3.zero;
    private float lastTime = 0.0f;
    private Quaternion rotReceive = Quaternion.identity;
    private Vector3 posReceive = Vector3.zero;

    [SerializeField]
    private float rotationInterpolationSpeed = 15.0f;
    [SerializeField]
    private float translationInterpolationSpeed = 15.0f;

    void Awake()
    {
        trans = transform;
        agent = GetComponent<NavMeshAgent>();
    }

    [RPC]
    void SetPlayer(NetworkPlayer _player)
    {
        Owner = _player;

        if (_player == Network.player)
            enabled = true;
    }

    void Update()
    {
        if (Owner != null && Network.player == Owner)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Vector3 destination = hit.point;
                    SendSetDestinationInput(destination);

                    if (Network.isServer)
                        SendSetDestinationInput(destination);
                    else if (Network.isClient)
                        networkView.RPC("SendSetDestinationInput", RPCMode.Server, destination);
                }
            }
        }

        if (Network.isServer)
            agent.SetDestination(serverCurrentDestination);

        if (Network.isClient)
        {
            trans.position = Vector3.Lerp(trans.position, posReceive, Time.deltaTime * translationInterpolationSpeed);
            trans.rotation = Quaternion.Lerp(trans.rotation, rotReceive, Time.deltaTime * rotationInterpolationSpeed);
        }
    }

    [RPC]
    void SendSetDestinationInput(Vector3 _point)
    {
        serverCurrentDestination = _point;
    }
                        

    void OnSerializeNetworkView(BitStream _stream, NetworkMessageInfo _info)
    {

        if (_stream.isWriting)
        {
            Vector3 pos = trans.position;
            Quaternion rot = trans.rotation;
            _stream.Serialize(ref pos);
            _stream.Serialize(ref rot);
        }
        else
        {
            _stream.Serialize(ref posReceive);
            _stream.Serialize(ref rotReceive);
        }
    }
}
