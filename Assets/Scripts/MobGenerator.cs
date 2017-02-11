using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGenerator : MonoBehaviour
{
    public enum State
    {
        Idle,
        Initialize,
        Setup,
        SpawnMob
    }
    public GameObject mobPrefab;
    public GameObject[] spawnPoints;
    public State state;                 // local variable that holds our current state

    void Awake()
    {
        state = State.Initialize;
    }

    // Use this for initialization
    IEnumerator Start ()
    {
		while (true)
        {
            switch (state)
            {
                case State.Initialize:
                    Initialize();
                    break;
                case State.Setup:
                    Setup();
                    break;
                case State.SpawnMob:
                    SpawnMob();
                    break;
            }
            yield return 0;
        }
	}

    private void Initialize ()
    {
        Debug.Log("We are in Initialize");

        if (!CheckForMobPrefab() || !CheckForSpawnPonts())
            return;

        state = State.Setup;
    }

    private void Setup()
    {
        Debug.Log("We are in Setup");

        state = State.SpawnMob;
    }

    private void SpawnMob ()
    {
        Debug.Log("We are in SpawnMob");

        GameObject[] gos = AvailableSpawnPoints();

        for (int i = 0; i < gos.Length; i++)
        {
            GameObject go = Instantiate(mobPrefab, 
                gos[i].transform.position, 
                Quaternion.identity) as GameObject;

            go.transform.parent = gos[i].transform;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Targeting>().AddTarget(go.transform);
        }
    
        state = State.Idle;
    }

    // check to see that we have at least one mov prefab to spawn
    private bool CheckForMobPrefab ()
    {
        return mobPrefab != null ? true : false;
    }

    // check to see if we have at least one spawn point
    private bool CheckForSpawnPonts ()
    {
        return spawnPoints.Length > 0 ? true : false;
    }

    // generate list of available spawn points that do not have any child mobs
    private GameObject[] AvailableSpawnPoints ()
    {
        List<GameObject> gos = new List<GameObject>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].transform.childCount == 0)
            {
                Debug.Log("Spawn Point available");
                gos.Add(spawnPoints[i]);
            }
        }

        return gos.ToArray();
    }
}
