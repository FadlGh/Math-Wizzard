using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public enum OperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    [SerializeField] private OperationType operationType;

    [SerializeField] private CauldronSlot child1;
    [SerializeField] private CauldronSlot child2;
    [SerializeField] private GameObject potionPrefab;

    private float PerformOperation(float operand1, float operand2)
    {
        switch (operationType)
        {
            case OperationType.Addition:
                return operand1 + operand2;
            case OperationType.Subtraction:
                return operand1 - operand2;
            case OperationType.Multiplication:
                return operand1 * operand2;
            case OperationType.Division:
                if (operand2 != 0)
                {
                    return operand1 / operand2;
                }
                else
                {
                    Debug.LogWarning("Division by zero is not allowed.");
                    return float.NaN;
                }
            default:
                Debug.LogError("Invalid operation type.");
                return float.NaN;
        }
    }

    private bool CanPerform()
    {
        return child1.value > 0 && child2.value > 0;
    }

    public void Perform()
    {
        if (!CanPerform()) return;
        float endValue = PerformOperation(child1.value, child2.value);
        GameObject newPotion = Instantiate(potionPrefab, new Vector2(transform.position.x, transform.position.y - 2), Quaternion.identity);
        newPotion.GetComponent<Potion>().value = (int)endValue;
    }

    void Update()
    {
        print(child1.value);
    }
}
