using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    Transform trans;

	// Use this for initialization
	void Start () {
        trans = transform;
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(1.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-1.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0.0f, 1.0f, 0.0f);

        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0.0f, -1.0f, 0.0f);
	}
}
