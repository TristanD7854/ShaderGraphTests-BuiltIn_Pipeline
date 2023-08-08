using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;

    void OnDrawGizmos()
    {
        if (vertices == null)
        {
            mesh = GetComponent<MeshFilter>().sharedMesh;
            vertices = mesh.vertices;
        }
        foreach (Vector3 v in vertices)
        {
            Vector3 worldPos = transform.position + v;
            Vector3 viewVertVal = SceneView.GetAllSceneCameras()[0].WorldToViewportPoint(worldPos);
            string vert = "v: " + v.ToString();
            string worldVert = " wv: " + worldPos.ToString();
            string viewVert = " vv: " + viewVertVal.ToString();
            UnityEditor.Handles.Label(worldPos, vert + worldVert + viewVert);
        }
    }
}
