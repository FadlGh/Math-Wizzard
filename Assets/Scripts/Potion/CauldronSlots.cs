using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronSlots : MonoBehaviour
{
    private int carriableLayerIndex;

    // Start is called before the first frame update
    void Start()
    {
        carriableLayerIndex = LayerMask.NameToLayer("Carriable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == carriableLayerIndex)
        {
            collision.transform.position = transform.position;
            print("s");
        }
    }
}
