using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    private Material material;

	void Start () {
        material = GetComponent<MeshRenderer>().material;
	}
}
