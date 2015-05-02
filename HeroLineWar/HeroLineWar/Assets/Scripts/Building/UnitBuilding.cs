using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(Timer))]
public class UnitBuilding : MonoBehaviour {


    public bool on;
    public GameObject unit = null;

    private Timer spawnTimer;
    private Timer unitTimer;
    [SerializeField]
    private int nbrUnits;
    private int unitSpawed = 0;
    private bool isSpawing = false;
    private Transform popTrans;
    private Transform trans;

    void Awake()
    {
        SetTimers();
        if (on)
            spawnTimer.Launch();
        trans = transform;
        for (int i = 0; i < trans.childCount; i++)
        {
            if (trans.GetChild(i).tag == "UnitPop")
            {
                popTrans = trans.GetChild(i);
                break;
            }
        }
    }

    void SetTimers()
    {
        Timer[] timer = GetComponents<Timer>();
        if (timer[0].GetDuration() < timer[1].GetDuration())
        {
            unitTimer = timer[0];
            spawnTimer = timer[1];
            return;
        }
        unitTimer = timer[1];
        spawnTimer = timer[0];
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (on)
        {
            if (isSpawing)
            {
                if (unitTimer.IsDone())
                {
                    SpawnEntity();
                    unitTimer.Restart();
                    unitSpawed++;
                    if (unitSpawed >= nbrUnits)
                    {
                        isSpawing = false;
                        spawnTimer.Restart();
                    }
                }
            }
            else if (spawnTimer.IsDone())
            {
                SpawnEntity();
                unitTimer.Restart();
                isSpawing = true;
                unitSpawed = 1;
            }
        }
	}

    void SpawnEntity()
    {
        if (unit != null)
        {
            GameObject obj = Instantiate(unit, popTrans.position, popTrans.rotation) as GameObject;
            obj.transform.rotation = popTrans.rotation;
        }
    }
}
