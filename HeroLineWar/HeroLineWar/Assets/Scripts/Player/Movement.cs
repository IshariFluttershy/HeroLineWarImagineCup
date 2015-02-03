using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Transform trans;
	private NavMeshAgent agent;
	private Vector3 targetDest;

	void Awake()
	{
        trans = transform;
	}

	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
	{
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
				agent.SetDestination(hit.point);
		}
	}
}
