using UnityEngine;
using System.Collections;

public class ProtoSelection : MonoBehaviour {

    [SerializeField]
    private GameObject selectedOverlayPrefab;

    private Transform selectedOverlay;

	void Start () {

        GameObject obj = Instantiate(selectedOverlayPrefab, new Vector3(0.0f, 100000.0f, 0.0f), Quaternion.identity) as GameObject;
        selectedOverlay = obj.transform;
	}
	
	void Update () {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                int layerMask = 1 << 9;
                
                if (Physics.Raycast(ray, out hit, 1000, layerMask))
                {
                    selectedOverlay.position = hit.collider.transform.position;
                    selectedOverlay.localScale = hit.collider.transform.localScale * 1.1f;
                }
            }
	}
}
