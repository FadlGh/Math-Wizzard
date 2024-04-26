using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    #region Variables
    private GameObject carriedObject;
    private float rayDistance = 5;
    private int layerIndex;
    #endregion

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Carriable");
    }
    private void OnEnable()
    {
        TouchManager.FingerPosition += MoveObject;
    }

    private void OnDisable()
    {
        TouchManager.FingerPosition -= MoveObject;
    }

    private void MoveObject(Vector2 position)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(position, Vector3.forward, rayDistance);
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            carriedObject = hitInfo.collider.gameObject;
            carriedObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            return;
        }

        carriedObject.transform.position = position;
    }
}
