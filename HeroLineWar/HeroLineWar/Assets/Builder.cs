using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TypeBuiling { None, UnitBuilding, PowerBuilding, Wall };

public class Builder : MonoBehaviour {

    [SerializeField]
    private List<GameObject> unitBuildings;
    [SerializeField]
    private List<GameObject> powerBuildings;

    private List<GameObject> currentList;

    private bool clicked = false;
    private bool fill = false;
    private TypeBuiling currentSelect = TypeBuiling.None;

    private Vector2 buttonPos;
    private Rect box;
    private Rect selectBox;

	// Use this for initialization
	void Start () 
    {
        box = new Rect( 0, 0, 0, 0 );
	}
	
	// Update is called before OnMouseOver
	void Update () 
    {
        if (clicked && !box.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
        {
            clicked = false;
            currentSelect = TypeBuiling.None;
        }
	}

    void OnMouseOver()
    {
        if (!clicked && Input.GetMouseButtonDown(0))
        {
            buttonPos.x = Input.mousePosition.x;
            buttonPos.y = Screen.height - Input.mousePosition.y;
            box = new Rect(buttonPos.x - Screen.width / 12, buttonPos.y - Screen.height / 45, Screen.width / 6, Screen.height / 4);
            clicked = true;
        }
    }

    void OnGUI()
    {
        if (clicked)
        {
            GUI.Box(box, "Buildings");
            if (GUI.Button(new Rect(box.x, box.y + Screen.height / 16, box.width, box.height / 4), "UnitBuildings"))
                SetCurrentList(TypeBuiling.UnitBuilding);
            else if (GUI.Button(new Rect(box.x, box.y + Screen.height / 8, box.width, box.height / 4), "PowerBuildings"))
                SetCurrentList(TypeBuiling.PowerBuilding);
            else if (GUI.Button(new Rect(box.x, box.y + Screen.height / 16 * 3, box.width, box.height / 4), "Quit"))
            {
                currentSelect = TypeBuiling.None;
                clicked = false;
            }

            if (currentSelect != TypeBuiling.None)
            {
                GUI.Box(selectBox, currentSelect.ToString());
                for (int i = 0; i < currentList.Count; i++)
                {
                    if (GUI.Button(new Rect(selectBox.x, selectBox.y + (box.height / 4 * (i + 1)), selectBox.width, box.height / 4), currentList[i].name))
                        CreateBuilding(currentList[i]);
                }
            }
        }
    }

    void CreateBuilding(GameObject ob)
    {

    }

    void SetCurrentList(TypeBuiling type)
    {
        currentSelect = type;
        if (type == TypeBuiling.None)
            clicked = false;
        else if (type == TypeBuiling.UnitBuilding)
            currentList = unitBuildings;
        else if (type == TypeBuiling.PowerBuilding)
            currentList = powerBuildings;

        selectBox = new Rect(box.x + box.width, box.y, box.width, box.height / 4 * (currentList.Count + 1));
    }
}
