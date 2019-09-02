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
    private static readonly string animationFileName = "Animation " + DateTime.Now.ToString("dd MMMM HH:mm") + ".xml";
    private static readonly string directoryPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    public static readonly string animationRelativeFilePath = Path.Combine(animationDirectoryName, animationFileName);
    public static readonly string animationDirectoryPath = Path.Combine(directoryPath, animationDirectoryName);
    public static readonly string animationFilePath = Path.Combine(directoryPath, animationRelativeFilePath);

    public bool isRecording = false;

    public Transform head;
    public Transform elbow_r;
    public Transform hand_r;
    public Transform elbow_l;
    public Transform hand_l;
    public Transform pelvis;
    public Transform knee_r;
    public Transform foot_r;
    public Transform knee_l;
    public Transform foot_l;

    private List<WorkoutAnimationNode> nodeList = new List<WorkoutAnimationNode>();
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
            headposition = new SerializableVector3(head.position.x, head.position.y, head.position.z),
            headrotation = new SerializableQuaternion(head.rotation.x, head.rotation.y, head.rotation.z, head.rotation.w),
            elbowposition_r = new SerializableVector3(elbow_r.position.x, elbow_r.position.y, elbow_r.position.z),
            elbowrotation_r = new SerializableQuaternion(elbow_r.rotation.x, elbow_r.rotation.y, elbow_r.rotation.z, elbow_r.rotation.w),
            handposition_r = new SerializableVector3(hand_r.position.x, hand_r.position.y, hand_r.position.z),
            handrotation_r = new SerializableQuaternion(hand_r.rotation.x, hand_r.rotation.y, hand_r.rotation.z, hand_r.rotation.w),
            elbowposition_l = new SerializableVector3(elbow_l.position.x, elbow_l.position.y, elbow_l.position.z),
            elbowrotation_l = new SerializableQuaternion(elbow_l.rotation.x, elbow_l.rotation.y, elbow_l.rotation.z, elbow_l.rotation.w),
            handposition_l = new SerializableVector3(hand_l.position.x, hand_l.position.y, hand_l.position.z),
            handrotation_l = new SerializableQuaternion(hand_l.rotation.x, hand_l.rotation.y, hand_l.rotation.z, hand_l.rotation.w),
            pelvisposition = new SerializableVector3(pelvis.position.x, pelvis.position.y, pelvis.position.z),
            pelvisrotation = new SerializableQuaternion(pelvis.rotation.x, pelvis.rotation.y, pelvis.rotation.z, pelvis.rotation.w),
            kneeposition_r = new SerializableVector3(knee_r.position.x, knee_r.position.y, knee_r.position.z),
            kneerotation_r = new SerializableQuaternion(knee_r.rotation.x, knee_r.rotation.y, knee_r.rotation.z, knee_r.rotation.w),
            footposition_r = new SerializableVector3(foot_r.position.x, foot_r.position.y, foot_r.position.z),
            footrotation_r = new SerializableQuaternion(foot_r.rotation.x, foot_r.rotation.y, foot_r.rotation.z, foot_r.rotation.w),
            kneeposition_l = new SerializableVector3(knee_l.position.x, knee_l.position.y, knee_l.position.z),
            kneerotation_l = new SerializableQuaternion(knee_l.rotation.x, knee_l.rotation.y, knee_l.rotation.z, knee_l.rotation.w),
            footposition_l = new SerializableVector3(foot_l.position.x, foot_l.position.y, foot_l.position.z),
            footrotation_l = new SerializableQuaternion(foot_l.rotation.x, foot_l.rotation.y, foot_l.rotation.z, foot_l.rotation.w)
        };
        Debug.Log(node);
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

    [XmlElement("Elbowposition_Right")]
    public SerializableVector3 elbowposition_r { get; set; }

    [XmlElement("Elbowrotation_Right")]
    public SerializableQuaternion elbowrotation_r { get; set; }

    [XmlElement("Handposition_Right")]
    public SerializableVector3 handposition_r { get; set; }

    [XmlElement("Handrotation_Right")]
    public SerializableQuaternion handrotation_r { get; set; }

    [XmlElement("Elbowposition_Left")]
    public SerializableVector3 elbowposition_l { get; set; }

    [XmlElement("Elbowrotation_Left")]
    public SerializableQuaternion elbowrotation_l { get; set; }

    [XmlElement("Handposition_Left")]
    public SerializableVector3 handposition_l { get; set; }

    [XmlElement("Handrotation_Left")]
    public SerializableQuaternion handrotation_l { get; set; }

    [XmlElement("Pelvisposition")]
    public SerializableVector3 pelvisposition { get; set; }

    [XmlElement("Pelvisrotation")]
    public SerializableQuaternion pelvisrotation { get; set; }

    [XmlElement("Kneeposition_Right")]
    public SerializableVector3 kneeposition_r { get; set; }

    [XmlElement("Kneerotation_Right")]
    public SerializableQuaternion kneerotation_r { get; set; }

    [XmlElement("Footposition_Right")]
    public SerializableVector3 footposition_r { get; set; }

    [XmlElement("Footrotation_Right")]
    public SerializableQuaternion footrotation_r { get; set; }

    [XmlElement("Kneeposition_Left")]
    public SerializableVector3 kneeposition_l { get; set; }

    [XmlElement("Kneerotation_Left")]
    public SerializableQuaternion kneerotation_l { get; set; }

    [XmlElement("Footposition_Left")]
    public SerializableVector3 footposition_l { get; set; }

    [XmlElement("Footrotation_Left")]
    public SerializableQuaternion footrotation_l { get; set; }

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