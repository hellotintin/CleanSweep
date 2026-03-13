using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int currentFloor = HotelGenerator.Instance.GetCurrentFloor();

        int nextFloor = currentFloor + 1;

        HotelGenerator.Instance.GoToFloor(nextFloor);
    }
}