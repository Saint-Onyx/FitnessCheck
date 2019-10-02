using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System;


public class AnimationConverter : EditorWindow
{
    [SerializeField]
    private string animationName;
    [SerializeField]
    private TextAsset textAsset;

    private List<Vector3> headPosition;
    private List<Quaternion> headRotation;
    private List<Vector3> leftElbowPosition;
    private List<Quaternion> leftElbowRotation;
    private List<Vector3> leftArmPosition;
    private List<Quaternion> leftArmRotation;
    private List<Vector3> rightElbowPosition;
    private List<Quaternion> rightElbowRotation;
    private List<Vector3> rightArmPosition;
    private List<Quaternion> rightArmRotation;
    private List<Vector3> hipPosition;
    private List<Quaternion> hipRotation;
    private List<Vector3> leftKneePosition;
    private List<Quaternion> leftKneeRotation;
    private List<Vector3> leftLegPosition;
    private List<Quaternion> leftLegRotation;
    private List<Vector3> rightKneePosition;
    private List<Quaternion> rightKneeRotation;
    private List<Vector3> rightLegPosition;
    private List<Quaternion> rightLegRotation;

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
            ExtractXMLData();
            ConvertData();
        }       
    }

    /////////////////////////////////////////////
 
    //TODO Floating points not converting properly.

    //Need to find a fix!  

    //ASAP!!!!

    /////////////////////////////////////////////


    void ExtractXMLData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        Debug.Log(xmlDoc.Name);
        XmlNodeList xmlHeadPosition = xmlDoc.GetElementsByTagName("Headposition");
        XmlNodeList xmlHeadRotation = xmlDoc.GetElementsByTagName("Headrotation");
        XmlNodeList xmlLeftArmPosition = xmlDoc.GetElementsByTagName("Handposition_Left");
        XmlNodeList xmlRightArmPosition = xmlDoc.GetElementsByTagName("Handposition_Right");

        Debug.Log(xmlHeadPosition.Count);
        Debug.Log(xmlLeftArmPosition.Count);

        Debug.Log(headPosition.Count);
        Debug.Log(leftArmPosition.Count);

        foreach (XmlNode positionInfo in xmlHeadPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach(XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, out position.z);
                }
            }
            headPosition.Add(position);
        }
        Debug.Log(headPosition.Count);

        foreach (XmlNode rotationInfo in xmlHeadRotation)
        {
            Quaternion rotation = new Quaternion();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, out rotation.w);
                }
            }
            headRotation.Add(rotation);
        }

        foreach (XmlNode positionInfo in xmlLeftArmPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, out position.z);
                }
            }
            leftArmPosition.Add(position);
        }
        Debug.Log(leftArmPosition.Count);

        foreach (XmlNode positionInfo in xmlRightArmPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, out position.z);
                }
            }
            rightArmPosition.Add(position);
        }

    }

    void ConvertData()
    {
        AnimationCurve curve;

        AnimationClip clip = new AnimationClip();

        Keyframe[] keys;
        keys = new Keyframe[headPosition.Count * 10]; //Why times 3???

        float timeline = 0;

        Keyframe[] key_headPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_headPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_headPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_headRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_headRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_headRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_headRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_leftHandPosition_X = new Keyframe[leftArmPosition.Count];
        Keyframe[] key_leftHandPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandPosition_Z = new Keyframe[headPosition.Count];

        //Keyframe[] key_rightHandPosition_X = new Keyframe[headPosition.Count];
        //Keyframe[] key_rightHandPosition_Y = new Keyframe[headPosition.Count];
        //Keyframe[] key_rightHandPosition_Z = new Keyframe[headPosition.Count];


        for (int i = 0; i < key_leftHandPosition_X.Length; i++)
        {
            //key_headPosition_X[i] = new Keyframe(timeline, headPosition[i].x);
            //key_headPosition_Y[i] = new Keyframe(timeline, headPosition[i].y);
            //key_headPosition_Z[i] = new Keyframe(timeline, headPosition[i].z);

            key_headRotation_X[i] = new Keyframe(timeline, headRotation[i].x);
            key_headRotation_Y[i] = new Keyframe(timeline, headRotation[i].y);
            key_headRotation_Z[i] = new Keyframe(timeline, headRotation[i].z);
            key_headRotation_W[i] = new Keyframe(timeline, headRotation[i].w);

            key_leftHandPosition_X[i] = new Keyframe(timeline, leftArmPosition[i].x);
            key_leftHandPosition_Y[i] = new Keyframe(timeline, leftArmPosition[i].y);
            key_leftHandPosition_Z[i] = new Keyframe(timeline, leftArmPosition[i].z);

            //key_rightHandPosition_X[i] = new Keyframe(timeline, rightArmPosition[i].x);
            //key_rightHandPosition_Y[i] = new Keyframe(timeline, rightArmPosition[i].y);
            //key_rightHandPosition_Z[i] = new Keyframe(timeline, rightArmPosition[i].z);


            timeline += 0.1f;
        }

        //curve = new AnimationCurve(key_headPosition_X);
        //clip.SetCurve("Head Target Parent", typeof(Transform), "localPosition.x", curve);
        //curve = new AnimationCurve(key_headPosition_Y);
        //clip.SetCurve("Head Target Parent", typeof(Transform), "localPosition.y", curve);
        //curve = new AnimationCurve(key_headPosition_Z);
        //clip.SetCurve("Head Target Parent", typeof(Transform), "localPosition.z", curve);

        //curve = new AnimationCurve(key_headRotation_X);
        //clip.SetCurve("Head Target Parent", typeof(Animation), "rotation.x", curve);
        //curve = new AnimationCurve(key_headRotation_Y);
        //clip.SetCurve("Head Target Parent", typeof(Transform), "rotation.y", curve);
        //curve = new AnimationCurve(key_headRotation_Z);
        //clip.SetCurve("Head Target Parent", typeof(Transform), "rotation.z", curve);
        //curve = new AnimationCurve(key_headRotation_W);
        //clip.SetCurve("Head Target Parent", typeof(Transform), "rotation.w", curve);

        curve = new AnimationCurve(key_leftHandPosition_X);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_leftHandPosition_Y);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_leftHandPosition_Z);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localPosition.z", curve);

        //curve = new AnimationCurve(key_rightHandPosition_X);
        //clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localPosition.x", curve);
        //curve = new AnimationCurve(key_rightHandPosition_Y);
        //clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localPosition.y", curve);
        //curve = new AnimationCurve(key_rightHandPosition_Z);
        //clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localPosition.z", curve);



#if UNITY_EDITOR
        AssetDatabase.CreateAsset(clip, "Assets/Clips/" + animationName + ".anim");
        AssetDatabase.SaveAssets();
#endif

    }
}
