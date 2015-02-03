using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomGeneration : MonoBehaviour {

    [SerializeField]
    private List<GameObject> possibleRooms;

    private List<GameObject> rooms;
    private Transform trans;

    private int previousIndex = 0;

	// Use this for initialization
	void Awake () {

        trans = transform;
        rooms = new List<GameObject>();

        for (int i = 0; i < trans.childCount; i++)
            rooms.Add(trans.GetChild(i).gameObject);

        if (possibleRooms.Count < 2)
        {
            Debug.LogError("RoomGeneration need at least 2 possible rooms");
            return;
        }

        foreach (GameObject room in rooms)
        {
            RoomType roomType = room.GetComponent<RoomType>();
            if (roomType != null)
            {
                int index = Random.Range(0, possibleRooms.Count);

                while (index == previousIndex)
                    index = Random.Range(0, possibleRooms.Count);

                roomType.CreateRoom(possibleRooms[index]);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
