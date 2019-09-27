using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationConverter : EditorWindow
{
    [SerializeField]
    private string animationName;
    [SerializeField]
    private TextAsset textAsset;

   [MenuItem("Window/Animation Converter")]

   static void animationConverter()
    {
        EditorWindow myWindow = EditorWindow.GetWindow<AnimationConverter>();
        myWindow.minSize = new Vector2(512, 256);
        myWindow.maxSize = myWindow.minSize;
    }


    private void OnGUI()
    {
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Select name for animation.");
        animationName = EditorGUILayout.TextField(animationName);
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Choose Textasset to convert.");
        textAsset = (TextAsset)EditorGUILayout.ObjectField(textAsset, typeof(TextAsset));

        if (GUILayout.Button("Convert!"))
        {

        }
        



    }

    void ExtractXMLData()
    {

    }

    void ConvertData()
    {

    }
}
