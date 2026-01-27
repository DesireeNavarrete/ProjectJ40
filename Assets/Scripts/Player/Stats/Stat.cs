
using UnityEngine;
using UnityEngine.UI;

public class Stat
{
    //public float nivel;
    //public float multiplicador;
    //public Image slider;

    //public float nl => nivel;
    //public float multipl => multiplicador;
    //public Image sli => slider;

    //public Stat(float nivel, float multiplicador, Image slider)
    //{
    //    this.nivel = UnityEngine.Mathf.Clamp(nivel, 0, 100);
    //    this.multiplicador = multiplicador;
    //    this.slider = slider;
    //}

    //public void SetNivel(float niv)
    //{
    //    nivel = niv;
    //}

    public float Value { get; private set; }//valor del stat actual
    public float Multiplier { get; private set; } //multiplicador para ese stat

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
