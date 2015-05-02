using UnityEngine;
using System.Collections;

public class UnitMove : MonoBehaviour {

    [SerializeField]
    private float speed = 5;
    private Transform trans;

	// Use this for initialization
	void Start () 
    {
        trans = transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        trans.Translate(trans.forward * Time.deltaTime * speed, Space.World);
        Debug.Log(trans.forward);
	}
}
