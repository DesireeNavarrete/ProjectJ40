
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Stat
{
    public float Value { get; private set; }//valor del stat actual
    public float Multiplier { get; set; } //multiplicador para ese stat

    public Stat(float initialValue, float multiplier = 1f)
    {
        Value = Mathf.Clamp(initialValue, 0f, 100f);
        Multiplier = multiplier;
    }

    public void Modify(float amount)
    {
        Value = Mathf.Clamp(Value + amount * Multiplier, 0f, 100f);
    }

   

    public void SetValue(float value)
    {
        Value = Mathf.Clamp(value, 0f, 100f);
    }
}
