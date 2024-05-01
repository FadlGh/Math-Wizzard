using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    public int value;
    public Color color;
    public bool isAnswer;
    public TMP_Text text;
    [SerializeField] private LayerMask stickLayerIndex;

    private void Start()
    {
        //text.text = value.ToString();
    }

    private void Update()
    {
        Collider2D[] stickColliders = Physics2D.OverlapCircleAll(transform.position, 1f, stickLayerIndex);
        print(stickLayerIndex.value);
        if (stickColliders.Length > 0)
        {
            transform.position = stickColliders[0].transform.position;
            print(stickColliders[0].transform.position);
            print("true");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
