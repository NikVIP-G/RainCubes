using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _materialForChange;

    public void ChangeColor(Material material)
    {
        material.color = _materialForChange.color;
    }
}
