using UnityEngine;
using System.Collections;

public class ProtoAttack : MonoBehaviour {

    public NetworkPlayer Owner;

    [SerializeField]
    private float range;
    [SerializeField]
    private float damages;

    private Transform trans;

	void Start () {

        Owner = GetComponent<ProtoMovement>().Owner;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, 0x000001))
            {
                Debug.Log("LOLUSSE");
            }
        }
	}
}
