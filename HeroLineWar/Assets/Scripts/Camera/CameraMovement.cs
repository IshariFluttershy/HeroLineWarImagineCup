using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform trans;
	[SerializeField]
	private float speed = 1.0f;
	[SerializeField]
	private GameObject Player;
    [SerializeField]
    private float MaxZoom = 15.0f;
    [SerializeField]
    private float MinZoom = 90.0f;

	void Awake()
	{
		trans = transform;
	}

	void Start () 
	{
	}
	
	void Update () 
	{
		CameraMove();
        Zoom();

		if (Input.GetKey(KeyCode.Space))
			CenterPlayer();
	}

	void CameraMove()
	{
        if ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= 10) || Input.GetKey(KeyCode.LeftArrow))
			trans.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        else if ((Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.x <= Screen.width) || Input.GetKey(KeyCode.RightArrow))
			trans.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if ((Input.mousePosition.y >= 0 && Input.mousePosition.y <= 10) || Input.GetKey(KeyCode.DownArrow))
			trans.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        else if ((Input.mousePosition.y >= Screen.height - 10 && Input.mousePosition.y <= Screen.height) || Input.GetKey(KeyCode.UpArrow))
			trans.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
	}

    void Zoom()
    {
        if (trans.position.y >= MaxZoom && Input.GetAxis("Mouse ScrollWheel") > 0.0f)
            trans.Translate(Vector3.down, Space.World);
        if (trans.position.y <= MinZoom && Input.GetAxis("Mouse ScrollWheel") < 0.0f)
            trans.Translate(Vector3.up, Space.World);
    }

	void CenterPlayer()
	{
		Vector3 center = new Vector3(Player.transform.position.x, this.trans.position.y, Player.transform.position.z - 8);

		this.trans.position = center;
	}
}
