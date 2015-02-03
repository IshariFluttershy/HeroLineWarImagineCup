using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomType : MonoBehaviour {

    /*[SerializeField]
    private List<GameObject> RoomPossibilities;*/

    private GameObject room;
    private Transform trans;

	// Use this for initialization
	void Awake () {

        Debug.Log("Awake");
        trans = transform;

        //int roomIndex = Random.Range(0, RoomPossibilities.Count);
        //room = Instantiate(RoomPossibilities[roomIndex], trans.position + new Vector3(0.0f, 0.0f, -1.0f), trans.rotation) as GameObject;
        //room.transform.parent = trans;
	}

    public void CreateRoom(GameObject model)
    {
        Debug.Log("Model == " + model);
        Debug.Log("trans == " + trans);
        room = Instantiate(model, trans.position + new Vector3(0.0f, 0.0f, -1.0f), trans.rotation) as GameObject;
        room.transform.parent = trans;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
