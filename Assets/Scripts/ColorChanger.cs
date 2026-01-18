using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _colorForChange;

    public void ChangeColor(Material material)
    {
        material.color = _colorForChange;
    }
}
