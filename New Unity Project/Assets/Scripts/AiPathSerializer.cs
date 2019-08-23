//using Helpers;
//using Networking;
//using Player;
//using SteroidsSharedData.Serialization;
//using System.Collections.Generic;
//using System.IO;
//using System.Xml;
//using System.Xml.Serialization;
//using UnityEngine;
//using static SteroidsSharedData.Helpers.Constants;
//using System;

//namespace Serialization
//{
//    /// <summary>
//    /// Should be attached on the object in the scene that needs to have its path created
//    /// Serializes all the data to a file which can be then later transferred to the server
//    /// </summary>
//    public class AiPathSerializer : MonoBehaviour
//    {
//        private static readonly string aiPathDirectoryPath = Constants.Serialization.AiPathAbsoluteDirectoryPath;
//        private static readonly string aiPathFilePath = Constants.Serialization.AiPathAbsoluteFilePath;
//        private static readonly float serializationFrequency = Constants.AiMovementParameters.SerializationFrequency;

//        private AvailableLevels level;
//        private AiPath aiPath;
//        private List<AiPathNode> pathNodes = new List<AiPathNode>();
//        private int bookedLaps;
//        private float elapsedTime;

//        private double totalTime;
//        private double bestTime;
//        private int startPositionIndex;

//        private bool shouldWrite;
//        LocalPlayer localPlayer;
//        private int frameCounter = 0;
//        private int framesToSkip = 5;
//        private float frames = 0.0f;

//        private bool isStartedRecordingOnce = false;

//        //public BikeRecorder bikeRecorder;

//        private int lapTimeSeconds = 0;


//        private void Start()
//        {
//            localPlayer = LocalPlayer.Instance;
//            ServerMessageReader.LoadLevelReceived += (e) => { level = e; };
//            ServerMessageReader.ShowLevelReceived += () => { bookedLaps = LocalPlayer.Instance.bookedLaps; };
//            //FinishLine.PlayerCrossedFinishLine += RegisterFinishTime;
//            ServerMessageReader.RaceTimedOut += StopCreatingPath;
//            frameCounter = framesToSkip;

//        }

//        public void RegisterFinishTime(TimeSpan _totalTime, TimeSpan _bestTime)
//        {
//            //finishIndex = pathNodes.Count - 1;
//            totalTime = _totalTime.TotalMilliseconds;
//            bestTime = _bestTime.TotalMilliseconds;
//        }

//        public void RegisterStartPosition(int index)
//        {
//            startPositionIndex = index;
//            switch (level)
//            {
//                case AvailableLevels.DefaultCity:
//                    lapTimeSeconds = (int) LevelLapTimes.SteroidsCity;
//                    break;
//                case AvailableLevels.Dune:
//                    lapTimeSeconds = (int)LevelLapTimes.Dune;
//                    break;
//                default:
//                    break;
//            }
//                    Debug.Log("lap duration set to: " + lapTimeSeconds);
//        }

//        //private void Update()
//        //{
//        //    shouldWrite = localPlayer.isRaceStarted;

//        //    if (!shouldWrite)
//        //        return;

//        //    if(!isStartedRecordingOnce)
//        //    {
//        //        InvokeRepeating("Recording", 0, 0.1f);
//        //        isStartedRecordingOnce = true;
//        //    }

//        //    //elapsedTime += Time.deltaTime;
//        //    //if (elapsedTime < serializationFrequency)
//        //    //    return;

//        //    //elapsedTime = 0;
//        //    //Vector3 position = transform.position;
//        //    //Quaternion rotation = transform.rotation;
//        //    //Vector3 upVector = transform.up;
//        //    //Vector3 forwardVector = transform.forward;

//        //    //AiPathNode node = new AiPathNode()
//        //    //{
//        //    //    Position = new SerializableVector3(position.x, position.y, position.z),
//        //    //    Rotation = new SerializableQuaternion(rotation.x, rotation.y, rotation.z, rotation.w),
//        //    //    UpVector = new SerializableVector3(upVector.x, upVector.y, upVector.z),
//        //    //    ForwardVector = new SerializableVector3(forwardVector.x, forwardVector.y, forwardVector.z),
//        //    //    Speed = LocalPlayer.Instance.MoveSpeed,
//        //    //    DeltaTime = serializationFrequency
//        //    //};
//        //    //pathNodes.Add(node);
//        //}

//        private void FixedUpdate()
//        {
//            //shouldWrite = localPlayer.isRaceStarted;

//            if (!shouldWrite)
//                return;

//            frameCounter--;
//            if (frameCounter <= 0)
//            {
//                WriteNode();
//            }

//        }


//        public void StartRecording()
//        {
//            shouldWrite = true;
//            //bikeRecorder.enabled = true;
//        }

//        public void WriteNode()
//        {

//            if (localPlayer.bookedLaps * lapTimeSeconds * 10 + 1 <= pathNodes.Count)
//            {
//                return;
//            }

//            Vector3 position = transform.position;
//            Quaternion rotation = transform.rotation;
//            Vector3 upVector = transform.up;
//            Vector3 forwardVector = transform.forward;

//            AiPathNode node = new AiPathNode()
//            {
//                Position = new SerializableVector3(position.x, position.y, position.z),
//                Rotation = new SerializableQuaternion(rotation.x, rotation.y, rotation.z, rotation.w),
//                UpVector = new SerializableVector3(upVector.x, upVector.y, upVector.z),
//                ForwardVector = new SerializableVector3(forwardVector.x, forwardVector.y, forwardVector.z),
//                Speed = LocalPlayer.Instance.MoveSpeed,
//                DeltaTime = serializationFrequency
//            };
//            pathNodes.Add(node);
//            frameCounter = framesToSkip;
//        }


//        private void StopCreatingPath()
//        {
//            Debug.Log("framecounter: " + frameCounter);
//            Debug.Log("StopRecord Write: " + Time.time + " nodes: " + pathNodes.Count);
//            WriteNode();
//            //CancelInvoke("Recording");
//            shouldWrite = false;
//            //bikeRecorder.enabled = false;
//            elapsedTime = 0;

//            FillDataForSerialization();
//            pathNodes.Clear();

//            EnsureFileExistance();
//            SerializeAiPath();
//        }

//        void Recording()
//        {
//            Vector3 position = transform.position;
//            Quaternion rotation = transform.rotation;
//            Vector3 upVector = transform.up;
//            Vector3 forwardVector = transform.forward;

//            AiPathNode node = new AiPathNode()
//            {
//                Position = new SerializableVector3(position.x, position.y, position.z),
//                Rotation = new SerializableQuaternion(rotation.x, rotation.y, rotation.z, rotation.w),
//                UpVector = new SerializableVector3(upVector.x, upVector.y, upVector.z),
//                ForwardVector = new SerializableVector3(forwardVector.x, forwardVector.y, forwardVector.z),
//                Speed = LocalPlayer.Instance.MoveSpeed,
//                DeltaTime = serializationFrequency
//            };
//            pathNodes.Add(node);
//        }

//        private void EnsureFileExistance()
//        {
//            if (!Directory.Exists(aiPathDirectoryPath))
//            {
//                Directory.CreateDirectory(aiPathDirectoryPath);
//                File.Create(aiPathFilePath).Dispose();
//            }
//            else if (!File.Exists(aiPathFilePath))
//            {
//                File.Create(aiPathFilePath.AppendTimeStamp()).Dispose();
//            }
//        }

//        private void FillDataForSerialization()
//        {
//            AiPathNode[] nodesToStore = new AiPathNode[pathNodes.Count];
//            for (int i = 0; i < nodesToStore.Length; ++i)
//                nodesToStore[i] = pathNodes[i];

//            aiPath = new AiPath() { PathNodeCollection = nodesToStore, LevelName = level, StartPositionIndex = startPositionIndex, BookedLaps = bookedLaps, TotalTime = totalTime, BestTime = bestTime };
//        }

//        private void SerializeAiPath()
//        {
//            var serializer = new XmlSerializer(typeof(AiPath));
//            using (var writer = XmlWriter.Create(aiPathFilePath))
//            {
//                serializer.Serialize(writer, aiPath);
//            }
//        }

//    }
//}
