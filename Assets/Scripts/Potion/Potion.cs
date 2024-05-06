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
        text.text = value.ToString();
    }

    private void Update()
    {
        Collider2D[] stickColliders = Physics2D.OverlapCircleAll(transform.position, 1f, stickLayerIndex);

        if (stickColliders.Length < 1) return;

        transform.position = stickColliders[0].transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
