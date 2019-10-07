using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.Globalization;
using System;


public class AnimationConverter : EditorWindow
{
    [SerializeField]
    private string animationName;
    [SerializeField]
    private TextAsset textAsset;

    private List<Vector3> headPosition;
    private List<Quaternion> headRotation;
    //private List<Vector3> headRotation;
    private List<Vector3> leftElbowPosition;
    private List<Quaternion> leftElbowRotation;
    private List<Vector3> leftArmPosition;
    private List<Quaternion> leftArmRotation;
    private List<Vector3> rightElbowPosition;
    private List<Quaternion> rightElbowRotation;
    private List<Vector3> rightArmPosition;
    private List<Quaternion> rightArmRotation;
    private List<Vector3> pelvisPosition;
    private List<Quaternion> pelvisRotation;
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

    void ExtractXMLData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        Debug.Log(textAsset.name);
        XmlNodeList xmlHeadPosition = xmlDoc.GetElementsByTagName("Headposition");
        XmlNodeList xmlHeadRotation = xmlDoc.GetElementsByTagName("Headrotation");
        XmlNodeList xmlLeftElbowPosition = xmlDoc.GetElementsByTagName("Elbowposition_Left");
        XmlNodeList xmlLeftElbowROtation = xmlDoc.GetElementsByTagName("Elbowrotation_Left");
        XmlNodeList xmlLeftArmPosition = xmlDoc.GetElementsByTagName("Handposition_Left");
        XmlNodeList xmlLeftArmRotation = xmlDoc.GetElementsByTagName("Handrotation_Left");
        XmlNodeList xmlRightElbowPosition = xmlDoc.GetElementsByTagName("Elbowposition_Right");
        XmlNodeList xmlRightElbowRotation = xmlDoc.GetElementsByTagName("ElbowRotation_Right");
        XmlNodeList xmlRightArmPosition = xmlDoc.GetElementsByTagName("Handposition_Right");
        XmlNodeList xmlRightArmRotation = xmlDoc.GetElementsByTagName("Handrotation_Right");
        XmlNodeList xmlPelvisPosition = xmlDoc.GetElementsByTagName("Pelvisposition");
        XmlNodeList xmlPelvisRotation = xmlDoc.GetElementsByTagName("Pelvisrotation");
        XmlNodeList xmlLeftKneePosition = xmlDoc.GetElementsByTagName("Kneeposition_Left");
        XmlNodeList xmlLeftKneeRotation = xmlDoc.GetElementsByTagName("Kneerotation_Left");
        XmlNodeList xmlLeftLegPosition = xmlDoc.GetElementsByTagName("Footposition_Left");
        XmlNodeList xmlLeftLegRotation = xmlDoc.GetElementsByTagName("Footrotation_Left");
        XmlNodeList xmlRightKneePosition = xmlDoc.GetElementsByTagName("Kneeposition_Right");
        XmlNodeList xmlRightKneeRotation = xmlDoc.GetElementsByTagName("Kneerotation_Right");
        XmlNodeList xmlRightLegPosition = xmlDoc.GetElementsByTagName("Footposition_Right");
        XmlNodeList xmlRightLegRotation = xmlDoc.GetElementsByTagName("Footrotation_Right");

        foreach (XmlNode positionInfo in xmlHeadPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach(XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.z);
                }
            }
            headPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlHeadRotation)
        {
            Quaternion rotation = new Quaternion();
            //Vector3 euler = new Vector3();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.w);
                }
            }
            headRotation.Add(rotation);
        }

        //TODO LEFT ELBOW

        foreach (XmlNode positionInfo in xmlLeftArmPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.z);
                }
            }
            leftArmPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlLeftArmRotation)
        {
            Quaternion rotation = new Quaternion();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.w);
                }
            }
            leftArmRotation.Add(rotation);
        }

        //TODO RIGHT ELBOW

        foreach (XmlNode positionInfo in xmlRightArmPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.z);
                }
            }
            rightArmPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlRightArmRotation)
        {
            Quaternion rotation = new Quaternion();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.w);
                }
            }
            rightArmRotation.Add(rotation);
        }

        foreach (XmlNode positionInfo in xmlPelvisPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.z);
                }
            }
            pelvisPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlPelvisRotation)
        {
            Quaternion rotation = new Quaternion();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.w);
                }
            }
            pelvisRotation.Add(rotation);
        }

        //TODO LEFT KNEE

        foreach (XmlNode positionInfo in xmlLeftLegPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.z);
                }
            }
            leftLegPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlLeftLegRotation)
        {
            Quaternion rotation = new Quaternion();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.w);
                }
            }
            leftLegRotation.Add(rotation);
        }

        //TODO RIGHT KNEE

        foreach (XmlNode positionInfo in xmlRightLegPosition)
        {
            Vector3 position = new Vector3();
            XmlNodeList positionDetails = positionInfo.ChildNodes;

            foreach (XmlNode detail in positionDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out position.z);
                }
            }
            rightLegPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlRightLegRotation)
        {
            Quaternion rotation = new Quaternion();
            XmlNodeList rotationDetails = rotationInfo.ChildNodes;

            foreach (XmlNode detail in rotationDetails)
            {
                if (detail.Name == "X")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.x);
                }

                if (detail.Name == "Y")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.y);
                }

                if (detail.Name == "Z")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.z);
                }

                if (detail.Name == "W")
                {
                    float.TryParse(detail.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out rotation.w);
                }
            }
            rightLegRotation.Add(rotation);
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

        //TODO LEFT ELBOW

        Keyframe[] key_leftHandPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_leftHandRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandRotation_W = new Keyframe[headPosition.Count];

        //TODO RIGHT ELBOW

        Keyframe[] key_rightHandPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightHandPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightHandPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_rightHandRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightHandRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightHandRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_rightHandRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_pelvisPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_pelvisPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_pelvisPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_pelvisRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_pelvisRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_pelvisRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_pelvisRotation_W = new Keyframe[headPosition.Count];

        //TODO LEFT KNEE

        Keyframe[] key_leftLegPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_leftLegRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegRotation_W = new Keyframe[headPosition.Count];

        //TODO RIGHT KNEE

        Keyframe[] key_rightLegPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightLegPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightLegPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_rightLegRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightLegRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightLegRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_rightLegRotation_W = new Keyframe[headPosition.Count];



        for (int i = 0; i < key_headPosition_X.Length; i++)
        {
            key_headPosition_X[i] = new Keyframe(timeline, headPosition[i].x);
            key_headPosition_Y[i] = new Keyframe(timeline, headPosition[i].y);
            key_headPosition_Z[i] = new Keyframe(timeline, headPosition[i].z);

            key_headRotation_X[i] = new Keyframe(timeline, headRotation[i].x);
            key_headRotation_Y[i] = new Keyframe(timeline, headRotation[i].y);
            key_headRotation_Z[i] = new Keyframe(timeline, headRotation[i].z);
            key_headRotation_W[i] = new Keyframe(timeline, headRotation[i].w);

            //TODO LEFT ELBOW

            key_leftHandPosition_X[i] = new Keyframe(timeline, leftArmPosition[i].x);
            key_leftHandPosition_Y[i] = new Keyframe(timeline, leftArmPosition[i].y);
            key_leftHandPosition_Z[i] = new Keyframe(timeline, leftArmPosition[i].z);

            key_leftHandRotation_X[i] = new Keyframe(timeline, leftArmRotation[i].x);
            key_leftHandRotation_Y[i] = new Keyframe(timeline, leftArmRotation[i].y);
            key_leftHandRotation_Z[i] = new Keyframe(timeline, leftArmRotation[i].z);
            key_leftHandRotation_W[i] = new Keyframe(timeline, leftArmRotation[i].w);

            //TODO RIGHT ELBOW

            key_rightHandPosition_X[i] = new Keyframe(timeline, rightArmPosition[i].x);
            key_rightHandPosition_Y[i] = new Keyframe(timeline, rightArmPosition[i].y);
            key_rightHandPosition_Z[i] = new Keyframe(timeline, rightArmPosition[i].z);

            key_rightHandRotation_X[i] = new Keyframe(timeline, rightArmRotation[i].x);
            key_rightHandRotation_Y[i] = new Keyframe(timeline, rightArmRotation[i].y);
            key_rightHandRotation_Z[i] = new Keyframe(timeline, rightArmRotation[i].z);
            key_rightHandRotation_W[i] = new Keyframe(timeline, rightArmRotation[i].w);

            //TODO PELVIS, ALL LEGS!!

            key_pelvisPosition_X[i] = new Keyframe(timeline, pelvisPosition[i].x);
            key_pelvisPosition_Y[i] = new Keyframe(timeline, pelvisPosition[i].y);
            key_pelvisPosition_Z[i] = new Keyframe(timeline, pelvisPosition[i].z);

            key_pelvisRotation_X[i] = new Keyframe(timeline, pelvisRotation[i].x);
            key_pelvisRotation_Y[i] = new Keyframe(timeline, pelvisRotation[i].y);
            key_pelvisRotation_Z[i] = new Keyframe(timeline, pelvisRotation[i].z);
            key_pelvisRotation_W[i] = new Keyframe(timeline, pelvisRotation[i].w);

            key_leftLegPosition_X[i] = new Keyframe(timeline, leftLegPosition[i].x);
            key_leftLegPosition_Y[i] = new Keyframe(timeline, leftLegPosition[i].y);
            key_leftLegPosition_Z[i] = new Keyframe(timeline, leftLegPosition[i].z);

            key_leftLegRotation_X[i] = new Keyframe(timeline, leftLegRotation[i].x);
            key_leftLegRotation_Y[i] = new Keyframe(timeline, leftLegRotation[i].y);
            key_leftLegRotation_Z[i] = new Keyframe(timeline, leftLegRotation[i].z);
            key_leftLegRotation_W[i] = new Keyframe(timeline, leftLegRotation[i].w);

            key_rightLegPosition_X[i] = new Keyframe(timeline, rightLegPosition[i].x);
            key_rightLegPosition_Y[i] = new Keyframe(timeline, rightLegPosition[i].y);
            key_rightLegPosition_Z[i] = new Keyframe(timeline, rightLegPosition[i].z);

            key_rightLegRotation_X[i] = new Keyframe(timeline, rightLegRotation[i].x);
            key_rightLegRotation_Y[i] = new Keyframe(timeline, rightLegRotation[i].y);
            key_rightLegRotation_Z[i] = new Keyframe(timeline, rightLegRotation[i].z);
            key_rightLegRotation_W[i] = new Keyframe(timeline, rightLegRotation[i].w);

            timeline += 0.1f;
        }

        curve = new AnimationCurve(key_headPosition_X);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_headPosition_Y);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_headPosition_Z);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_headRotation_X);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_headRotation_Y);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_headRotation_Z);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_headRotation_W);
        clip.SetCurve("Head Target Parent", typeof(Transform), "localRotation.w", curve);

        curve = new AnimationCurve(key_leftHandPosition_X);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_leftHandPosition_Y);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_leftHandPosition_Z);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_leftHandRotation_X);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_leftHandRotation_Y);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_leftHandRotation_Z);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_leftHandRotation_W);
        clip.SetCurve("Left Arm Target Parent", typeof(Transform), "localRotation.w", curve);

        curve = new AnimationCurve(key_rightHandPosition_X);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_rightHandPosition_Y);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_rightHandPosition_Z);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_rightHandRotation_X);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_rightHandRotation_Y);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_rightHandRotation_Z);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_rightHandRotation_W);
        clip.SetCurve("Right Arm Target Parent", typeof(Transform), "localRotation.w", curve);

        curve = new AnimationCurve(key_pelvisPosition_X);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_pelvisPosition_Y);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_pelvisPosition_Z);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_pelvisRotation_X);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_pelvisRotation_Y);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_pelvisRotation_Z);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_pelvisRotation_W);
        clip.SetCurve("Hip Target Parent", typeof(Transform), "localRotation.w", curve);

        headPosition.Clear();
        headRotation.Clear();
        leftArmPosition.Clear();
        leftArmRotation.Clear();
        rightArmPosition.Clear();
        rightArmRotation.Clear();
        pelvisPosition.Clear();
        pelvisRotation.Clear();
        leftLegPosition.Clear();
        leftLegRotation.Clear();
        rightLegPosition.Clear();
        rightLegRotation.Clear();

#if UNITY_EDITOR
        AssetDatabase.CreateAsset(clip, "Assets/Clips/" + animationName + ".anim");
        AssetDatabase.SaveAssets();
#endif

    }
}
