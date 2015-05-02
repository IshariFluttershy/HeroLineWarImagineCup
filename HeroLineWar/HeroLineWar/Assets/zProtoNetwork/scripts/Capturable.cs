using UnityEngine;
using System.Collections;

[System.Serializable]
public enum TeamColor
{
    RED,
    BLUE,
    GREY
}

public class Capturable : MonoBehaviour {

    public TeamColor OwnedBy = TeamColor.GREY;
    public float SideBar = 0.0f;

    void Update()
    {
        if (SideBar >= 100.0f)
            OwnedBy = TeamColor.RED;
        else if (SideBar <= -100.0f)
            OwnedBy = TeamColor.BLUE;
        else
            OwnedBy = TeamColor.GREY;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Ca collide");
        Unit capturer = other.GetComponent<Unit>();

        if (capturer)
        {
            if (capturer.OwnedBy == TeamColor.RED && SideBar < 100.0f)
                SideBar += 20 * Time.deltaTime;
            else if (capturer.OwnedBy == TeamColor.BLUE && SideBar > -100.0f)
                SideBar -= 20 * Time.deltaTime;
        }

    }
}
