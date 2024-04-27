using UnityEngine;

[RequireComponent (typeof(TouchManager))]
public class PickUp : MonoBehaviour
{
    #region Variables
    // For carrying objects
    private GameObject carriedObject;
    private bool carrying;

    // For ray casting
    private float rayDistance = 5;
    private int layerIndex;

    // To get finger position
    private bool fingerPressed = false;
    private Vector2 fingerPosition;

    private TouchManager touchManagerScript;
    #endregion

    #region Start and Update
    private void Start()
    {
        touchManagerScript = GetComponent<TouchManager>();
        layerIndex = LayerMask.NameToLayer("Carriable");
    }
    private void Update()
    {
        if (carrying)
        {
            fingerPosition = touchManagerScript.TouchPosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(fingerPosition);
            carriedObject.transform.position = worldPosition;
        }
    }
    #endregion

    #region Methods when Pressing and Releasing
    private void CheckPress(Vector2 touchPosition)
    {
        // Get position of where player pressed
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        // Check if there is anything to carry
        RaycastHit2D hitInfo = Physics2D.Raycast(worldPosition, Vector3.forward, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            carriedObject = hitInfo.collider.gameObject;
            carriedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            carrying = true;
        }
        else
        {
            return;
        }
    }

    private void CheckRemoval()
    {
        if (carrying)
        {
            carriedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            carriedObject = null;
            carrying = false;
        }
    }
    #endregion

    #region OnEnable and OnDisable
    private void OnEnable()
    {
        TouchManager.FingerPressed += CheckPress;
        TouchManager.FingerReleased += CheckRemoval;
    }

    private void OnDisable()
    {
        TouchManager.FingerPressed -= CheckPress;
        TouchManager.FingerReleased -= CheckRemoval;
    }
    #endregion
}
