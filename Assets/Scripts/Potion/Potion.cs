using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    public int value;
    public Color color;
    public bool isAnswer;
    public TMP_Text text;

    void Start()
    {
        text.text = value.ToString();
    }
}
