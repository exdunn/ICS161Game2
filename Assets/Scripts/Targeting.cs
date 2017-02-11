using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    private Transform myTransform;

    public List<Transform> targets;
    public Transform selectedTarget;

	// Use this for initialization
	void Start ()
    {
        myTransform = transform;
        targets = new List<Transform>();
        selectedTarget = null;

        AddAllEnemies();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Tab))
            TargetEnemy();
	}

    private void TargetEnemy ()
    {
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
            selectedTarget = targets[0];
        }
        else
        {
            int index = targets.IndexOf(selectedTarget);

            if (index < targets.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            DeselectTarget();
            selectedTarget = targets[index];
        }
        SelectTarget();
    }

    private void SortTargetsByDistance ()
    {
        targets.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, myTransform.position).CompareTo(
                Vector3.Distance(t2.position, myTransform.position));
        });
    }

    private void SelectTarget ()
    {
        selectedTarget.GetComponent<Renderer>().material.color = Color.red;
        PlayerAttack pa = (PlayerAttack)GetComponent <PlayerAttack>();
        pa.SetTarget(selectedTarget.gameObject);
    } 

    private void DeselectTarget ()
    {
        selectedTarget.GetComponent<Renderer>().material.color = Color.white;
        selectedTarget = null;
    }

    public void AddAllEnemies ()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in go)
        {
            targets.Add(enemy.transform);
        }
    }

    public void AddTarget (Transform enemy)
    {
        targets.Add(enemy);
    }
}
