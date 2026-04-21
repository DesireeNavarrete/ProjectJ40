using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ReactSO", menuName = "ScriptableObjects/ReactSO", order = 1)]

public class NeedsSO : ScriptableObject
{

    [Header("General")]
    public string reaccion;

    [Header("Sprite")]
    public Sprite emoticono;

    // pone siempre el nombre del scriptable en el id
    private void OnValidate()
    {
#if UNITY_EDITOR
        reaccion = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
