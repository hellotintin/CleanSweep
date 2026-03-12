using UnityEngine;
using CleanSweep.Core;

namespace CleanSweep.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [Header("Interaction")]
        [SerializeField] private float interactRange = 2.5f;
        [SerializeField] private LayerMask interactMask;
        [SerializeField] private Transform cameraTransform;

        private IInteractable _currentTarget;

        private void Update()
        {
            DetectInteractable();

            if (_currentTarget != null && Input.GetKeyDown(KeyCode.E))
            {
                _currentTarget.Interact(this);
            }
        }

        private void DetectInteractable()
        {
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactMask))
            {
                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

                if (interactable != null)
                {
                    if (interactable != _currentTarget)
                    {
                        _currentTarget?.OnHoverExit();
                        _currentTarget = interactable;
                        _currentTarget.OnHoverEnter();
                    }
                    return;
                }
            }

            // no interactable found
            if (_currentTarget != null)
            {
                _currentTarget.OnHoverExit();
                _currentTarget = null;
            }
        }

        public Vector3 GetPosition() => transform.position;
    }
}