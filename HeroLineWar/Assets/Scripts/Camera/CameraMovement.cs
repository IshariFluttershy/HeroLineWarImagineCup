using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform trans;
	[SerializeField]
	private float speed = 1;
	[SerializeField]
	private GameObject Player;

	void Awake()
	{
		trans = transform;
	}

	void Start () 
	{
	}
	
	void Update () 
	{
		KeyBoardDeplacement();
		MouseDeplacement();

		if (Input.GetKey(KeyCode.Space))
			CenterPlayer();
	}

	void MouseDeplacement()
	{
		if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= 10)
			trans.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
		else if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.x <= Screen.width)
			trans.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
		if (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 10)
			trans.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
		else if (Input.mousePosition.y >= Screen.height - 10 && Input.mousePosition.y <= Screen.height)
			trans.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
	}

	void KeyBoardDeplacement()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
			trans.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
		if (Input.GetKey(KeyCode.UpArrow))
			trans.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
		if (Input.GetKey(KeyCode.RightArrow))
			trans.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
		if (Input.GetKey(KeyCode.DownArrow))
			trans.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
	}

	void CenterPlayer()
	{
		Vector3 center = new Vector3(Player.transform.position.x, this.trans.position.y, Player.transform.position.z - 8);

		this.trans.position = center;
	}
}
