using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertObjectsManager : MonoBehaviour
{
    //public static ObstacleManager Instance;
    public GameObject objectprefab;
    public GameObject Road;
    private float scaleFactor = 5;
    private List<GameObject> obstacles = new List<GameObject>();

    public int gridX = 3;
    public int gridZ = 15;
    public float density = 0.5f;
    public float yHeight = 0.2f;

    // Start is called before the first frame update
    void Awake()
    {
        PlaceObstacles();
    }

    void PlaceObstacles()
    {
        float gridXDistances = (Road.transform.localScale.x * scaleFactor * 2) / gridX;
        float gridZDistances = (Road.transform.localScale.z * scaleFactor * 2) / gridZ;

        float startX = Road.transform.position.x - Road.transform.localScale.x * scaleFactor + gridXDistances*0.5f;
        float startZ = Road.transform.position.z - Road.transform.localScale.z * scaleFactor + gridZDistances*0.5f;

        float skipFirst = 5;

        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                // skip the first obstacles, so the player has a chance
                if (startZ + gridZDistances * z > skipFirst)
                {
                    if (Random.Range(0f, 1f) < density)
                    {
                        Vector3 randomPos = new Vector3(startX + gridXDistances * x + Random.Range(-(gridXDistances * 0.5f), gridXDistances * 0.5f), yHeight, startZ + gridZDistances * z + Random.Range(-(gridZDistances * 0.5f), gridZDistances * 0.5f));
                        obstacles.Add(Instantiate(objectprefab, randomPos, objectprefab.transform.rotation, this.transform));
                    }
                }
            }
        }
    }

    public void RespawnObstacles()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            Destroy(obstacles[i]);
        }
        obstacles.Clear();

        PlaceObstacles();
    }
}
