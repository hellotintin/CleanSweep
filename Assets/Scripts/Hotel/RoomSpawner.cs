using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject roomPrefab;

    public void SpawnRoom(System.Random rng)
    {
        GameObject roomObj = Instantiate(roomPrefab, transform.position, transform.rotation);

        Room room = roomObj.GetComponent<Room>();

        RoomStatus status = (RoomStatus)rng.Next(0, 4);

        room.Initialize(status);
    }
}