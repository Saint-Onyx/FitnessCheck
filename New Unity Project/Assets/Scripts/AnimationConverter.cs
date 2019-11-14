using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.Globalization;
using System;


public class AnimationConverter : EditorWindow
{
    /// <summary>
    /// Necessary input for conversion.
    /// </summary>
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

    /// <summary>
    /// Extract data from XML file and prepare for conversion.
    /// </summary>
    void ExtractXMLData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList xmlHeadPosition = xmlDoc.GetElementsByTagName("Headposition");
        XmlNodeList xmlHeadRotation = xmlDoc.GetElementsByTagName("Headrotation");
        XmlNodeList xmlLeftElbowPosition = xmlDoc.GetElementsByTagName("Elbowposition_Left");
        XmlNodeList xmlLeftElbowRotation = xmlDoc.GetElementsByTagName("Elbowrotation_Left");
        XmlNodeList xmlLeftArmPosition = xmlDoc.GetElementsByTagName("Handposition_Left");
        XmlNodeList xmlLeftArmRotation = xmlDoc.GetElementsByTagName("Handrotation_Left");
        XmlNodeList xmlRightElbowPosition = xmlDoc.GetElementsByTagName("Elbowposition_Right");
        XmlNodeList xmlRightElbowRotation = xmlDoc.GetElementsByTagName("Elbowrotation_Right");
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

        foreach (XmlNode positionInfo in xmlLeftElbowPosition)
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
            leftElbowPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlLeftElbowRotation)
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
            leftElbowRotation.Add(rotation);
        }

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

        foreach (XmlNode positionInfo in xmlRightElbowPosition)
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
            rightElbowPosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlRightElbowRotation)
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
            rightElbowRotation.Add(rotation);
        }

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

        foreach (XmlNode positionInfo in xmlLeftKneePosition)
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
            leftKneePosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlLeftKneeRotation)
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
            leftKneeRotation.Add(rotation);
        }

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

        foreach (XmlNode positionInfo in xmlRightKneePosition)
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
            rightKneePosition.Add(position);
        }

        foreach (XmlNode rotationInfo in xmlRightKneeRotation)
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
            rightKneeRotation.Add(rotation);
        }

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

    /// <summary>
    /// Creates an animation clip and assigns keyframes to each body part with position and rotation.
    /// </summary>
    void ConvertData()
    {
        AnimationCurve curve;

        AnimationClip clip = new AnimationClip();

        Keyframe[] keys;
        keys = new Keyframe[headPosition.Count * 20];

        float timeline = 0;

        Keyframe[] key_headPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_headPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_headPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_headRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_headRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_headRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_headRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_leftElbowPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftElbowPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftElbowPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_leftElbowRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftElbowRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftElbowRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_leftElbowRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_leftHandPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_leftHandRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_leftHandRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_rightElbowPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightElbowPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightElbowPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_rightElbowRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightElbowRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightElbowRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_rightElbowRotation_W = new Keyframe[headPosition.Count];

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

        Keyframe[] key_leftKneePosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftKneePosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftKneePosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_leftKneeRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftKneeRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftKneeRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_leftKneeRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_leftLegPosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegPosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegPosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_leftLegRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_leftLegRotation_W = new Keyframe[headPosition.Count];

        Keyframe[] key_rightKneePosition_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightKneePosition_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightKneePosition_Z = new Keyframe[headPosition.Count];

        Keyframe[] key_rightKneeRotation_X = new Keyframe[headPosition.Count];
        Keyframe[] key_rightKneeRotation_Y = new Keyframe[headPosition.Count];
        Keyframe[] key_rightKneeRotation_Z = new Keyframe[headPosition.Count];
        Keyframe[] key_rightKneeRotation_W = new Keyframe[headPosition.Count];

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

            key_leftElbowPosition_X[i] = new Keyframe(timeline, leftElbowPosition[i].x);
            key_leftElbowPosition_Y[i] = new Keyframe(timeline, leftElbowPosition[i].y);
            key_leftElbowPosition_Z[i] = new Keyframe(timeline, leftElbowPosition[i].z);

            key_leftElbowRotation_X[i] = new Keyframe(timeline, leftElbowRotation[i].x);
            key_leftElbowRotation_Y[i] = new Keyframe(timeline, leftElbowRotation[i].y);
            key_leftElbowRotation_Z[i] = new Keyframe(timeline, leftElbowRotation[i].z);
            key_leftElbowRotation_W[i] = new Keyframe(timeline, leftElbowRotation[i].w);

            key_leftHandPosition_X[i] = new Keyframe(timeline, leftArmPosition[i].x);
            key_leftHandPosition_Y[i] = new Keyframe(timeline, leftArmPosition[i].y);
            key_leftHandPosition_Z[i] = new Keyframe(timeline, leftArmPosition[i].z);

            key_leftHandRotation_X[i] = new Keyframe(timeline, leftArmRotation[i].x);
            key_leftHandRotation_Y[i] = new Keyframe(timeline, leftArmRotation[i].y);
            key_leftHandRotation_Z[i] = new Keyframe(timeline, leftArmRotation[i].z);
            key_leftHandRotation_W[i] = new Keyframe(timeline, leftArmRotation[i].w);

            key_rightElbowPosition_X[i] = new Keyframe(timeline, rightElbowPosition[i].x);
            key_rightElbowPosition_Y[i] = new Keyframe(timeline, rightElbowPosition[i].y);
            key_rightElbowPosition_Z[i] = new Keyframe(timeline, rightElbowPosition[i].z);

            key_rightElbowRotation_X[i] = new Keyframe(timeline, rightElbowRotation[i].x);
            key_rightElbowRotation_Y[i] = new Keyframe(timeline, rightElbowRotation[i].y);
            key_rightElbowRotation_Z[i] = new Keyframe(timeline, rightElbowRotation[i].z);
            key_rightElbowRotation_W[i] = new Keyframe(timeline, rightElbowRotation[i].w);

            key_rightHandPosition_X[i] = new Keyframe(timeline, rightArmPosition[i].x);
            key_rightHandPosition_Y[i] = new Keyframe(timeline, rightArmPosition[i].y);
            key_rightHandPosition_Z[i] = new Keyframe(timeline, rightArmPosition[i].z);

            key_rightHandRotation_X[i] = new Keyframe(timeline, rightArmRotation[i].x);
            key_rightHandRotation_Y[i] = new Keyframe(timeline, rightArmRotation[i].y);
            key_rightHandRotation_Z[i] = new Keyframe(timeline, rightArmRotation[i].z);
            key_rightHandRotation_W[i] = new Keyframe(timeline, rightArmRotation[i].w);


            key_pelvisPosition_X[i] = new Keyframe(timeline, pelvisPosition[i].x);
            key_pelvisPosition_Y[i] = new Keyframe(timeline, pelvisPosition[i].y);
            key_pelvisPosition_Z[i] = new Keyframe(timeline, pelvisPosition[i].z);

            key_pelvisRotation_X[i] = new Keyframe(timeline, pelvisRotation[i].x);
            key_pelvisRotation_Y[i] = new Keyframe(timeline, pelvisRotation[i].y);
            key_pelvisRotation_Z[i] = new Keyframe(timeline, pelvisRotation[i].z);
            key_pelvisRotation_W[i] = new Keyframe(timeline, pelvisRotation[i].w);

            key_leftKneePosition_X[i] = new Keyframe(timeline, leftKneePosition[i].x);
            key_leftKneePosition_Y[i] = new Keyframe(timeline, leftKneePosition[i].y);
            key_leftKneePosition_Z[i] = new Keyframe(timeline, leftKneePosition[i].z);

            key_leftKneeRotation_X[i] = new Keyframe(timeline, leftKneeRotation[i].x);
            key_leftKneeRotation_Y[i] = new Keyframe(timeline, leftKneeRotation[i].y);
            key_leftKneeRotation_Z[i] = new Keyframe(timeline, leftKneeRotation[i].z);
            key_leftKneeRotation_W[i] = new Keyframe(timeline, leftKneeRotation[i].w);

            key_leftLegPosition_X[i] = new Keyframe(timeline, leftLegPosition[i].x);
            key_leftLegPosition_Y[i] = new Keyframe(timeline, leftLegPosition[i].y);
            key_leftLegPosition_Z[i] = new Keyframe(timeline, leftLegPosition[i].z);

            key_leftLegRotation_X[i] = new Keyframe(timeline, leftLegRotation[i].x);
            key_leftLegRotation_Y[i] = new Keyframe(timeline, leftLegRotation[i].y);
            key_leftLegRotation_Z[i] = new Keyframe(timeline, leftLegRotation[i].z);
            key_leftLegRotation_W[i] = new Keyframe(timeline, leftLegRotation[i].w);

            key_rightKneePosition_X[i] = new Keyframe(timeline, rightKneePosition[i].x);
            key_rightKneePosition_Y[i] = new Keyframe(timeline, rightKneePosition[i].y);
            key_rightKneePosition_Z[i] = new Keyframe(timeline, rightKneePosition[i].z);

            key_rightKneeRotation_X[i] = new Keyframe(timeline, rightKneeRotation[i].x);
            key_rightKneeRotation_Y[i] = new Keyframe(timeline, rightKneeRotation[i].y);
            key_rightKneeRotation_Z[i] = new Keyframe(timeline, rightKneeRotation[i].z);
            key_rightKneeRotation_W[i] = new Keyframe(timeline, rightKneeRotation[i].w);

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

        curve = new AnimationCurve(key_leftElbowPosition_X);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_leftElbowPosition_Y);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_leftElbowPosition_Z);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_leftElbowRotation_X);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_leftElbowRotation_Y);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_leftElbowRotation_Z);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_leftElbowRotation_W);
        clip.SetCurve("Left Elbow Target Parent", typeof(Transform), "localRotation.w", curve);

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

        curve = new AnimationCurve(key_rightElbowPosition_X);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_rightElbowPosition_Y);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_rightElbowPosition_Z);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_rightElbowRotation_X);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_rightElbowRotation_Y);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_rightElbowRotation_Z);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_rightElbowRotation_W);
        clip.SetCurve("Right Elbow Target Parent", typeof(Transform), "localRotation.w", curve);

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

        curve = new AnimationCurve(key_leftKneePosition_X);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_leftKneePosition_Y);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_leftKneePosition_Z);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_leftKneeRotation_X);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_leftKneeRotation_Y);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_leftKneeRotation_Z);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_leftKneeRotation_W);
        clip.SetCurve("Left Knee Target Parent", typeof(Transform), "localRotation.w", curve);

        curve = new AnimationCurve(key_leftLegPosition_X);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_leftLegPosition_Y);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_leftLegPosition_Z);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_leftLegRotation_X);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_leftLegRotation_Y);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_leftLegRotation_Z);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_leftLegRotation_W);
        clip.SetCurve("Left Leg Target Parent", typeof(Transform), "localRotation.w", curve);

        curve = new AnimationCurve(key_rightKneePosition_X);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_rightKneePosition_Y);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_rightKneePosition_Z);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_rightKneeRotation_X);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_rightKneeRotation_Y);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_rightKneeRotation_Z);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_rightKneeRotation_W);
        clip.SetCurve("Right Knee Target Parent", typeof(Transform), "localRotation.w", curve);

        curve = new AnimationCurve(key_rightLegPosition_X);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(key_rightLegPosition_Y);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localPosition.y", curve);
        curve = new AnimationCurve(key_rightLegPosition_Z);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localPosition.z", curve);

        curve = new AnimationCurve(key_rightLegRotation_X);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localRotation.x", curve);
        curve = new AnimationCurve(key_rightLegRotation_Y);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localRotation.y", curve);
        curve = new AnimationCurve(key_rightLegRotation_Z);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localRotation.z", curve);
        curve = new AnimationCurve(key_rightLegRotation_W);
        clip.SetCurve("Right Leg Target Parent", typeof(Transform), "localRotation.w", curve);

        ///Clear lists in case the converter is used multiple times during one session.///
        headPosition.Clear();
        headRotation.Clear();
        leftElbowPosition.Clear();
        leftElbowRotation.Clear();
        leftArmPosition.Clear();
        leftArmRotation.Clear();
        rightElbowPosition.Clear();
        rightElbowRotation.Clear();
        rightArmPosition.Clear();
        rightArmRotation.Clear();
        pelvisPosition.Clear();
        pelvisRotation.Clear();
        leftKneePosition.Clear();
        leftKneeRotation.Clear();
        leftLegPosition.Clear();
        leftLegRotation.Clear();
        rightKneePosition.Clear();
        rightKneeRotation.Clear();
        rightLegPosition.Clear();
        rightLegRotation.Clear();

#if UNITY_EDITOR
        AssetDatabase.CreateAsset(clip, "Assets/Clips/" + animationName + ".anim");
        AssetDatabase.SaveAssets();
#endif

    }
}
