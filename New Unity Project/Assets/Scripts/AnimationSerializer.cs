using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot("Workout Animation")]
public class AnimationSerializer : MonoBehaviour
{

}

public class WorkoutAnimationNode
{

    [XmlElement("Headposition")]
    public SerializableVector3 headposition { get; set; }

    [XmlElement("Headrotation")]
    public SerializableQuaternion headrotation { get; set; }

    [XmlElement("Handposition_Right")]
    public SerializableVector3 handposition_r { get; set; }

    [XmlElement("Handrotation_Right")]
    public SerializableQuaternion handrotation_r { get; set; }

    [XmlElement("Handposition_Left")]
    public SerializableVector3 handposition_l { get; set; }

    [XmlElement("Handrotation_Left")]
    public SerializableQuaternion handrotation_l { get; set; }

    [XmlElement("Pelvisposition")]
    public SerializableVector3 pelvisposition { get; set; }

    [XmlElement("Pelvisrotation")]
    public SerializableQuaternion pelvisrotation { get; set; }

    [XmlElement("Footposition_Right")]
    public SerializableVector3 footposition_r { get; set; }

    [XmlElement("Footrotation_Right")]
    public SerializableQuaternion footrotation_r { get; set; }

    [XmlElement("Footposition_Left")]
    public SerializableVector3 footposition_l { get; set; }

    [XmlElement("Footrotation_Left")]
    public SerializableVector3 footrotation_l { get; set; }

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