using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Xml;

[XmlRoot("Workout Animation")]
public class AnimationSerializer : MonoBehaviour
{
    private static readonly string animationDirectoryName = "AnimationRecordings";
    private static readonly string animationFileName = "Animation.xml";
    private static readonly string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static readonly string animationRelativeFilePath = Path.Combine(animationDirectoryName, animationFileName);
    public static readonly string animationDirectoryPath = Path.Combine(directoryPath, animationDirectoryName);
    public static readonly string animationFilePath = Path.Combine(directoryPath, animationRelativeFilePath);

    public bool isRecording = false;

    public Transform head;
    public Transform elbow_l;
    public Transform hand_l;
    public Transform elbow_r;
    public Transform hand_r;
    public Transform pelvis;
    public Transform knee_l;
    public Transform foot_l;
    public Transform knee_r;
    public Transform foot_r;

    private List<WorkoutAnimationNode> nodeList = new List<WorkoutAnimationNode>();
    [HideInInspector]
    public WorkoutAnimation workout;


    public void StartRecording()
    {

        if (!isRecording)
        {
            isRecording = true;
        }

    }

    public void StopRecording()
    {

        if (isRecording)
        {
            isRecording = false;
            PrepareSerializedData();
            nodeList.Clear();
            CheckForPath();
            SerializeWorkoutAnimation();
            Debug.Log("Finished Serializing Movement Parameters.");

        }
    }

    public void FixedUpdate()
    {
        if (!isRecording)
            return;
        WriteNode();
    }

    public void WriteNode()
    {
        WorkoutAnimationNode node = new WorkoutAnimationNode()
        {
            headposition = new SerializableVector3(head.localPosition.x, head.localPosition.y, head.localPosition.z),
            //headrotation = new SerializableVector3(head.rotation.eulerAngles.x, head.rotation.eulerAngles.y, head.rotation.eulerAngles.z),
            headrotation = new SerializableQuaternion(head.localRotation.x, head.localRotation.y, head.localRotation.z, head.localRotation.w),
            elbowposition_l = new SerializableVector3(elbow_l.localPosition.x, elbow_l.localPosition.y, elbow_l.localPosition.z),
            elbowrotation_l = new SerializableQuaternion(elbow_l.localRotation.x, elbow_l.localRotation.y, elbow_l.localRotation.z, elbow_l.localRotation.w),
            handposition_l = new SerializableVector3(hand_l.localPosition.x, hand_l.localPosition.y, hand_l.localPosition.z),
            handrotation_l = new SerializableQuaternion(hand_l.localRotation.x, hand_l.localRotation.y, hand_l.localRotation.z, hand_l.localRotation.w),
            elbowposition_r = new SerializableVector3(elbow_r.localPosition.x, elbow_r.localPosition.y, elbow_r.localPosition.z),
            elbowrotation_r = new SerializableQuaternion(elbow_r.localRotation.x, elbow_r.localRotation.y, elbow_r.localRotation.z, elbow_r.localRotation.w),
            handposition_r = new SerializableVector3(hand_r.localPosition.x, hand_r.localPosition.y, hand_r.localPosition.z),
            handrotation_r = new SerializableQuaternion(hand_r.localRotation.x, hand_r.localRotation.y, hand_r.localRotation.z, hand_r.localRotation.w),
            pelvisposition = new SerializableVector3(pelvis.localPosition.x, pelvis.localPosition.y, pelvis.localPosition.z),
            pelvisrotation = new SerializableQuaternion(pelvis.localRotation.x, pelvis.localRotation.y, pelvis.localRotation.z, pelvis.localRotation.w),
            kneeposition_l = new SerializableVector3(knee_l.localPosition.x, knee_l.localPosition.y, knee_l.localPosition.z),
            kneerotation_l = new SerializableQuaternion(knee_l.localRotation.x, knee_l.localRotation.y, knee_l.localRotation.z, knee_l.localRotation.w),
            footposition_l = new SerializableVector3(foot_l.localPosition.x, foot_l.localPosition.y, foot_l.localPosition.z),
            footrotation_l = new SerializableQuaternion(foot_l.localRotation.x, foot_l.localRotation.y, foot_l.localRotation.z, foot_l.localRotation.w),
            kneeposition_r = new SerializableVector3(knee_r.localPosition.x, knee_r.localPosition.y, knee_r.localPosition.z),
            kneerotation_r = new SerializableQuaternion(knee_r.localRotation.x, knee_r.localRotation.y, knee_r.localRotation.z, knee_r.localRotation.w),
            footposition_r = new SerializableVector3(foot_r.localPosition.x, foot_r.localPosition.y, foot_r.localPosition.z),
            footrotation_r = new SerializableQuaternion(foot_r.localRotation.x, foot_r.localRotation.y, foot_r.localRotation.z, foot_r.localRotation.w)
        };
        nodeList.Add(node);
    }

    public void PrepareSerializedData()
    {
        WorkoutAnimationNode[] storedNodes = new WorkoutAnimationNode[nodeList.Count];
        for (int i = 0; i < storedNodes.Length; ++i)
        {
            storedNodes[i] = nodeList[i];

            workout = new WorkoutAnimation() { animationNodeCollection = storedNodes};
        }
    }

    public void CheckForPath()
    {
        if (!Directory.Exists(animationDirectoryPath))
        {
            Directory.CreateDirectory(animationDirectoryPath);
            File.Create(animationFilePath).Dispose();
        }

        else if (!File.Exists(animationFilePath))
        {
            Debug.Log(animationFilePath);
            File.Create(animationFilePath).Dispose();
        }

        //TODO Make sure animationFilePath doesnt make any problems
    }

    public void SerializeWorkoutAnimation()
    {
        var serializer = new XmlSerializer(typeof(WorkoutAnimation));
        using (var writer = XmlWriter.Create(animationFilePath))
        {
            serializer.Serialize(writer, workout);
        }
    }

}

[Serializable]
[XmlRoot(nameof(WorkoutAnimation))]
public class WorkoutAnimation
{
    [XmlArray(nameof(animationNodeCollection))]
    [XmlArrayItem(nameof(WorkoutAnimationNode), typeof(WorkoutAnimationNode))]
    public WorkoutAnimationNode[] animationNodeCollection { get; set; }

}

public class WorkoutAnimationNode
{

    [XmlElement("Headposition")]
    public SerializableVector3 headposition { get; set; }

    [XmlElement("Headrotation")]
    public SerializableQuaternion headrotation { get; set; }
    //public SerializableVector3 headrotation { get; set; }

    [XmlElement("Elbowposition_Left")]
    public SerializableVector3 elbowposition_l { get; set; }

    [XmlElement("Elbowrotation_Left")]
    public SerializableQuaternion elbowrotation_l { get; set; }

    [XmlElement("Handposition_Left")]
    public SerializableVector3 handposition_l { get; set; }

    [XmlElement("Handrotation_Left")]
    public SerializableQuaternion handrotation_l { get; set; }

    [XmlElement("Elbowposition_Right")]
    public SerializableVector3 elbowposition_r { get; set; }

    [XmlElement("Elbowrotation_Right")]
    public SerializableQuaternion elbowrotation_r { get; set; }

    [XmlElement("Handposition_Right")]
    public SerializableVector3 handposition_r { get; set; }

    [XmlElement("Handrotation_Right")]
    public SerializableQuaternion handrotation_r { get; set; }

    [XmlElement("Pelvisposition")]
    public SerializableVector3 pelvisposition { get; set; }

    [XmlElement("Pelvisrotation")]
    public SerializableQuaternion pelvisrotation { get; set; }

    [XmlElement("Kneeposition_Left")]
    public SerializableVector3 kneeposition_l { get; set; }

    [XmlElement("Kneerotation_Left")]
    public SerializableQuaternion kneerotation_l { get; set; }

    [XmlElement("Footposition_Left")]
    public SerializableVector3 footposition_l { get; set; }

    [XmlElement("Footrotation_Left")]
    public SerializableQuaternion footrotation_l { get; set; }

    [XmlElement("Kneeposition_Right")]
    public SerializableVector3 kneeposition_r { get; set; }

    [XmlElement("Kneerotation_Right")]
    public SerializableQuaternion kneerotation_r { get; set; }

    [XmlElement("Footposition_Right")]
    public SerializableVector3 footposition_r { get; set; }

    [XmlElement("Footrotation_Right")]
    public SerializableQuaternion footrotation_r { get; set; }

}

public class SerializableVector3
{

    [XmlElement("X")]
    public float X { get; set; }

    [XmlElement("Y")]
    public float Y { get; set; }

    [XmlElement("Z")]
    public float Z { get; set; }

    public static SerializableVector3 Zero => new SerializableVector3(0, 0, 0);

    public SerializableVector3() { }

    public SerializableVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}

public class SerializableQuaternion
{
    [XmlElement("X")]
    public float X { get; set; }

    [XmlElement("Y")]
    public float Y { get; set; }

    [XmlElement("Z")]
    public float Z { get; set; }

    [XmlElement("W")]
    public float W { get; set; }

    public static SerializableQuaternion Identity => new SerializableQuaternion(0, 0, 0, 0);

    public SerializableQuaternion() { }

    public SerializableQuaternion(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }

}