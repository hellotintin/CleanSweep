using UnityEngine;

public class HotelGenerator : MonoBehaviour
{
    public static HotelGenerator Instance;

    public GameObject floorPrefab;

    public int totalFloors = 10;

    public float floorHeight = 6f;

    int currentFloor = 0;

    System.Random rng;

    Floor[] floors;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateHotel();
    }

    void GenerateHotel()
    {
        rng = new System.Random();

        floors = new Floor[totalFloors];

        for (int i = 0; i < totalFloors; i++)
        {
            Vector3 pos = new Vector3(0, i * floorHeight, 0);

            GameObject floorObj = Instantiate(floorPrefab, pos, Quaternion.identity);

            Floor floor = floorObj.GetComponent<Floor>();

            floor.Generate(rng);

            floors[i] = floor;
        }
    }

    public void GoToFloor(int floorIndex)
    {
        if (floorIndex < 0 || floorIndex >= floors.Length)
            return;

        currentFloor = floorIndex;

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 pos = floors[floorIndex].transform.position;

        player.position = pos + new Vector3(0, 1, -4);
    }

    public int GetCurrentFloor()
    {
        return currentFloor;
    }
}