using UnityEngine;

public class CauldronSlot : MonoBehaviour
{
    private int carriableLayerIndex;
    [HideInInspector] public int value;
    [HideInInspector] public GameObject current;

    private void Start()
    {
        carriableLayerIndex = LayerMask.NameToLayer("Carriable");
        value = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == carriableLayerIndex && current == null)
        {
            value = collision.gameObject.GetComponent<Potion>().value;
            current = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == current)
        {
            value = -1;
            current = null;
        }
    }
}
