using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Camera _mainCamera;
    private InputManager _inputManager;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private LayerMask _mask;

    void Start()
    {
        _mainCamera = GetComponent<PlayerLook>().GetCamera();
        _inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        Ray newRay = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
        Debug.DrawRay(newRay.origin, newRay.direction * distance, Color.green);
        RaycastHit hitInfo;
        if(Physics.Raycast(newRay.origin, newRay.direction, out hitInfo, distance, _mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactionObject = hitInfo.collider.GetComponent<Interactable>();
                if(_inputManager._movementActions.Interaction.triggered)
                {
                    interactionObject.BaseInteract();
                    //interactionObject.gameObject.transform.position = interactionObject.gameObject.transform.position * 5f;
                }
            }
        }
    }
}
