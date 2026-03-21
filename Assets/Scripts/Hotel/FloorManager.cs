//Tracks rooms remaaining nd floors cleaared
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public static FloorManager Instance;

    int remainingRooms;

    void Awake()
    {
        Instance = this;
    }

    public void ResetFloor()
    {
        remainingRooms = 0;
    }

    public void RegisterRoom()
    {
        remainingRooms++;
    }

    public void RoomCleared()
    {
        remainingRooms--;

        if (remainingRooms <= 0)
        {
            FloorCompleted();
        }
    }

    void FloorCompleted()
    {
        Debug.Log("Floor Cleared!");

        int currentFloor = HotelGenerator.Instance.GetCurrentFloor();
        GameAnalyticsManager.OnFloorCompleted(currentFloor);

        int nextFloor = currentFloor + 1;

        if (nextFloor >= HotelGenerator.Instance.totalFloors)
            GameAnalyticsManager.OnGameCompleted();

        HotelGenerator.Instance.GoToFloor(nextFloor);
    }
}