//using System;
//using System.Xml.Serialization;
//using static SteroidsSharedData.Helpers.Constants;

//namespace SteroidsSharedData.Serialization
//{
//    /// <summary>
//    /// Class used for storing a path used for ai instances, and then is later deserialized on the server side
//    /// </summary>
//    [Serializable()]
//    [XmlRoot(nameof(AiPath))]
//    public class AiPath
//    {
//        /// <summary>
//        /// Collection holding path nodes
//        /// </summary>
//        [XmlArray(nameof(PathNodeCollection))]
//        [XmlArrayItem(nameof(AiPathNode), typeof(AiPathNode))]
//        public AiPathNode[] PathNodeCollection { get; set; }

//        /// <summary>
//        /// Name of the level
//        /// </summary>
//        [XmlElement(nameof(LevelName))]
//        public AvailableLevels LevelName { get; set; }

//        /// <summary>
//        /// Finish index of this path (finish line crossing moment)
//        /// </summary>
//        [XmlElement(nameof(BookedLaps))]
//        public int BookedLaps { get; set; }

//        /// <summary>
//        /// Index for the Startposition
//        /// </summary>
//        [XmlElement(nameof(StartPositionIndex))]
//        public int StartPositionIndex { get; set; }

//        /// <summary>
//        /// FinishTime of this path (finish line crossing moment)
//        /// </summary>
//        [XmlElement(nameof(TotalTime))]
//        public double TotalTime { get; set; }

//        /// <summary>
//        /// BestTime of this path (finish line crossing moment)
//        /// </summary>
//        [XmlElement(nameof(BestTime))]
//        public double BestTime { get; set; }
//    }

//    /// <summary>
//    /// An element of the entire ai path that is stored
//    /// </summary>
//    public class AiPathNode
//    {
//        /// <summary>
//        /// Position of the object
//        /// </summary>
//        [XmlElement(nameof(Position))]
//        public SerializableVector3 Position { get; set; }

//        /// <summary>
//        /// Rotation of the object expressed as a Quaternion
//        /// </summary>
//        [XmlElement(nameof(Rotation))]
//        public SerializableQuaternion Rotation { get; set; }

//        /// <summary>
//        /// UpVector of the Object
//        /// </summary>
//        [XmlElement(nameof(UpVector))]
//        public SerializableVector3 UpVector { get; set; }

//        /// <summary>
//        /// ForwardVector of the Object
//        /// </summary>
//        [XmlElement(nameof(ForwardVector))]
//        public SerializableVector3 ForwardVector { get; set; }


//        /// <summary>
//        /// Speed of the object 
//        /// </summary>
//        [XmlElement(nameof(Speed))]
//        public float Speed { get; set; }

//        /// <summary>
//        /// Delta time of the movement frame
//        /// </summary>
//        [XmlElement(nameof(DeltaTime))]
//        public float DeltaTime { get; set; }
//    }

//    /// <summary>
//    /// Serializable version of the Vector3
//    /// </summary>
//    public class SerializableVector3
//    {
//        /// <summary>
//        /// X vector component
//        /// </summary>
//        [XmlElement(nameof(X))]
//        public float X { get; set; }

//        /// <summary>
//        /// Y vector component
//        /// </summary>
//        [XmlElement(nameof(Y))]
//        public float Y { get; set; }

//        /// <summary>
//        /// Z vector component
//        /// </summary>
//        [XmlElement(nameof(Z))]
//        public float Z { get; set; }

//        /// <summary>
//        /// Serializable vector with all coordinates set to zero
//        /// </summary>
//        public static SerializableVector3 Zero => new SerializableVector3(0,0,0);

//        public SerializableVector3() { }

//        public SerializableVector3(float x, float y, float z)
//        {
//            X = x;
//            Y = y;
//            Z = z;
//        }

//        /// <summary>
//        /// Returns the string representation of the SerializableVector3
//        /// </summary>
//        public override string ToString()
//        {
//            return $"({X}, {Y}, {Z})";
//        }
//    }

//    /// <summary>
//    /// Serializable version of the Quaternion
//    /// </summary>
//    public class SerializableQuaternion
//    {
//        /// <summary>
//        /// X quaternion component
//        /// </summary>
//        [XmlElement(nameof(X))]
//        public float X { get; set; }

//        /// <summary>
//        /// Y quaternion component
//        /// </summary>
//        [XmlElement(nameof(Y))]
//        public float Y { get; set; }

//        /// <summary>
//        /// Z quaternion component
//        /// </summary>
//        [XmlElement(nameof(Z))]
//        public float Z { get; set; }

//        /// <summary>
//        /// W quaternion component
//        /// </summary>
//        [XmlElement(nameof(W))]
//        public float W { get; set; }

//        /// <summary>
//        /// Serializable vector with all coordinates set to zero
//        /// </summary>
//        public static SerializableQuaternion Identity => new SerializableQuaternion(0, 0, 0, 0);

//        public SerializableQuaternion() { }

//        public SerializableQuaternion(float x, float y, float z, float w)
//        {
//            X = x;
//            Y = y;
//            Z = z;
//            W = w;
//        }

//        /// <summary>
//        /// Returns the string representation of the SerializableQuaternion
//        /// </summary>
//        public override string ToString()
//        {
//            return $"({X}, {Y}, {Z}, {W})";
//        }
//    }


//}

