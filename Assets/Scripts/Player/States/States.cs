
using UnityEngine.UI;

public class States
{
    public float nivel;
    public float multiplicador;
    public Image slider;

    public float nl => nivel;
    public float multipl => multiplicador;
    public Image sli => slider;

    public States(float nivel, float multiplicador, Image slider)
    {
        this.nivel = UnityEngine.Mathf.Clamp(nivel, 0, 100);
        this.multiplicador = multiplicador;
        this.slider = slider;
    }

    public void SetNivel(float niv)
    {
        nivel = niv;
    }
}
