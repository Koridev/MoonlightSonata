using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ApplyAnimation : EditorWindow
{
    [MenuItem("Window/Animation/Applyer")]
    public static void ShowWindow()
    {
        GetWindow<ApplyAnimation>();
    }

    private AnimationClip selectedClip;

    void OnClipSelected(object clip)
    {
        selectedClip = clip as AnimationClip;
    }

    private void OnGUI()
    {
        if (Selection.activeGameObject != null)
        {
            Animator animator = Selection.activeGameObject.GetComponent<Animator>();
            if (animator == null)
            {
                GUILayout.Label("The selected object doesn't have an Animator component");
            }
            else
            {
                AnimationClip[] clips = AnimationUtility.GetAnimationClips(Selection.activeGameObject);



                if (EditorGUILayout.DropdownButton(new GUIContent(selectedClip == null ? "Animation Clip..." : selectedClip.name), FocusType.Keyboard))
                {
                    GenericMenu menu = new GenericMenu();

                    foreach (AnimationClip clip in clips)
                    {
                        menu.AddItem(new GUIContent(clip.name), clip.Equals(selectedClip), OnClipSelected, clip);
                    }

                    menu.DropDown(GUILayoutUtility.GetLastRect());
                }


                if (selectedClip == null)
                {
                    GUI.enabled = false;
                }
                if (GUILayout.Button("Apply") && selectedClip != null)
                {
                    selectedClip.SampleAnimation(Selection.activeGameObject, 0);
                }

                GUI.enabled = true;
            }
        }
        else
        {
            GUILayout.Label("No selected object");
        }

    }
}