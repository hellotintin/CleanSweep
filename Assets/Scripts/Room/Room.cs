using UnityEngine;

public class Room : MonoBehaviour, IInteractable
{
    public RoomStatus status;

    bool cleared = false;

    public void Initialize(RoomStatus newStatus)
    {
        status = newStatus;
        cleared = false;
    }

    public void Interact()
    {
        if (cleared) return;

        HandleRoom();
    }

    void HandleRoom()
    {
        switch (status)
        {
            case RoomStatus.NeedsService:
                Debug.Log("Cleaning Room");
                break;

            case RoomStatus.ReadyForCheckout:
                Debug.Log("Checkout confirmed");
                break;

            case RoomStatus.VIPRequest:
                Debug.Log("VIP request handled");
                break;

            case RoomStatus.ProblemRoom:
                Debug.Log("Problem resolved");
                break;
        }

        cleared = true;

        GameAnalyticsManager.OnRoomCleared(status);
        FloorManager.Instance.RoomCleared();
    }

    void Start()
    {
        FloorManager.Instance.RegisterRoom();
    }

}