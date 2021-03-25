using ARVR.ScriptableTypes;
using UnityEngine;

[ExecuteInEditMode]
public class Vector3VisualizationGizmo : MonoBehaviour
{
    [SerializeField]
    private RuntimeVector3Array vectorArray;

    [SerializeField]
    private Color color = Color.red;

    [SerializeField]
    [Range(0.1f, 10)]
    private float radius = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        foreach (var vec in vectorArray)
        {
            Gizmos.DrawWireSphere(vec, radius);
        }
    }
}