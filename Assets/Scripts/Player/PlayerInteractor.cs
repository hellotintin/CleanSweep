using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    Camera cam;

    void Start()
    {
        EasyPeasyFirstPersonController.FirstPersonController controller = GetComponent<EasyPeasyFirstPersonController.FirstPersonController>();
        if (controller != null)
            cam = controller.cam;
        else
            cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        if (cam == null) return;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
