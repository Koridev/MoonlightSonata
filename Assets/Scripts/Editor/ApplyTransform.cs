using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ApplyTransform : EditorWindow
{

    [MenuItem("Window/Transform/Applyer")]
    public static void ShowWindow()
    {
        GetWindow<ApplyTransform>();
    }

    private void OnGUI()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject go = Selection.activeGameObject;

            if (GUILayout.Button("Apply Rotation"))
            {
                List<Vector3> positions = new List<Vector3>();
                List<Quaternion> rotations = new List<Quaternion>();

                for(int i = 0; i < go.transform.childCount; i++)
                {
                    positions.Add(go.transform.GetChild(i).transform.position);
                    rotations.Add(go.transform.GetChild(i).transform.rotation);
                }

                go.transform.localRotation = Quaternion.identity;

                for (int i = 0; i < go.transform.childCount; i++)
                {
                    go.transform.GetChild(i).transform.position = positions[i];
                    go.transform.GetChild(i).transform.rotation = rotations[i];
                }
            }

            if (GUILayout.Button("Apply Scale"))
            {
                List<Vector3> positions = new List<Vector3>();

                for (int i = 0; i < go.transform.childCount; i++)
                {
                    positions.Add(go.transform.GetChild(i).transform.position);
                }

                Vector3 initialScale = go.transform.localScale;
                go.transform.localScale = Vector3.one;

                for (int i = 0; i < go.transform.childCount; i++)
                {
                    go.transform.GetChild(i).transform.position = positions[i];
                    Vector3 localScale = go.transform.GetChild(i).transform.localScale;
                    go.transform.GetChild(i).transform.localScale = new Vector3(localScale.x * initialScale.x, localScale.y * initialScale.y, localScale.z * initialScale.z);
                }
            }
        }
        else
        {

        }
    }


}
