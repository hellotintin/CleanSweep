using UnityEngine;

public class Floor : MonoBehaviour
{
    RoomSpawner[] spawners;

    public void Generate(System.Random rng)
    {
        spawners = GetComponentsInChildren<RoomSpawner>();

        foreach (RoomSpawner spawner in spawners)
        {
            spawner.SpawnRoom(rng);
        }
    }
}