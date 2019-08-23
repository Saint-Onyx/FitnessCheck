//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml;
//using System.IO;

//public class AiPathConverter : MonoBehaviour {

//    public TextAsset GameAsset;

//    public List<Dictionary<string, string>> levels = new List<Dictionary<string, string>>();
//    Dictionary<string, string> obj;

//    public List<string> nodeList;
//    public List<Vector3> positionList;
//    public List<Quaternion> rotationList;

//    public List<Vector3> upVectorList;
//    public List<Vector3> forwardVectorList;

//    public List<float> rotasY;
//    public List<float> speedList; 

//    public double finishTime;

//    void Start()
//    {
//        GetDataFromXML();
//        SetAnimationData();
//    }

//    public void GetDataFromXML()
//    {
//        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
//        xmlDoc.LoadXml(GameAsset.text); // load the file.

//        XmlNodeList aiPathNodeList_Positions = xmlDoc.GetElementsByTagName("Position");
//        XmlNodeList aiPathNodeList_Rotations = xmlDoc.GetElementsByTagName("Rotation");
//        XmlNodeList aiPathNodeList_UpVectors = xmlDoc.GetElementsByTagName("UpVector");
//        XmlNodeList aiPathNodeList_ForwardVectors = xmlDoc.GetElementsByTagName("ForwardVector");

//        XmlNodeList aiPathNodeList_Times = xmlDoc.GetElementsByTagName("DeltaTime");
//        XmlNodeList aiPathNodeList_Speed = xmlDoc.GetElementsByTagName("Speed");

//        foreach (XmlNode positionInfo in aiPathNodeList_Positions)
//        {
//            Vector3 position = new Vector3();
//            XmlNodeList positionContent = positionInfo.ChildNodes;

//            foreach (XmlNode pathNodeItems in positionContent) 
//            {
//                if (pathNodeItems.Name == "X")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out position.x);
//                    //string xString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(xString, out position.x);
//                }

//                if (pathNodeItems.Name == "Y")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out position.y);
//                    //string yString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(yString, out position.y);
//                }

//                if (pathNodeItems.Name == "Z")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out position.z);
//                    //string zString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(zString, out position.z);
//                }
//            }
//            positionList.Add(position);

//        }

//        foreach (XmlNode rotationInfo in aiPathNodeList_Rotations)
//        {
//            Quaternion rotation = new Quaternion();
//            XmlNodeList rotationContent = rotationInfo.ChildNodes;

//            float rotX = 0;
//            float rotY = 0;
//            float rotZ = 0;

//            foreach (XmlNode pathNodeItems in rotationContent)
//            {
//                if (pathNodeItems.Name == "X")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out rotation.x);
//                    rotX = (rotX + 360) % 360;
//                    //string xString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(xString, out rotation.x);
//                }

//                if (pathNodeItems.Name == "Y")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out rotation.y);
//                    //Debug.Log("After Parse: " + rotY);
//                    //rotY = (rotY + 360) % 360;
//                    //Debug.Log("After Calc: " + rotY);
//                    //rotasY.Add(rotY);
//                    //string yString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(yString, out rotation.y);
//                }

//                if (pathNodeItems.Name == "Z")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out rotation.z);
//                    rotZ = (rotZ + 360) % 360;
//                    //string zString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(zString, out rotation.z);
//                }

//                if (pathNodeItems.Name == "W")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out rotation.w);

//                    //string zString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(zString, out rotation.z);
//                }

//                Vector3 euler = rotation.eulerAngles;
//                rotY = euler.y;
//                Debug.Log("After Parse: " + rotY);
//                rotY = (rotY + 360) % 360;
//                Debug.Log("After Calc: " + rotY);
//                rotasY.Add(rotY);

//            }



//            rotationList.Add(rotation);
//        }

//        foreach (XmlNode upVectorInfo in aiPathNodeList_UpVectors)
//        {
//            Vector3 vector = new Vector3();
//            XmlNodeList vectorContent = upVectorInfo.ChildNodes;

//            foreach (XmlNode pathNodeItems in vectorContent)
//            {
//                if (pathNodeItems.Name == "X")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out vector.x);
//                    //string xString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(xString, out position.x);
//                }

//                if (pathNodeItems.Name == "Y")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out vector.y);
//                    //string yString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(yString, out position.y);
//                }

//                if (pathNodeItems.Name == "Z")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out vector.z);
//                    //string zString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(zString, out position.z);
//                }
//            }
//            upVectorList.Add(vector);

//        }

//        foreach (XmlNode forwardVectorInfo in aiPathNodeList_ForwardVectors)
//        {
//            Vector3 vector = new Vector3();
//            XmlNodeList vectorContent = forwardVectorInfo.ChildNodes;

//            foreach (XmlNode pathNodeItems in vectorContent)
//            {
//                if (pathNodeItems.Name == "X")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out vector.x);
//                    //string xString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(xString, out position.x);
//                }

//                if (pathNodeItems.Name == "Y")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out vector.y);
//                    //string yString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(yString, out position.y);
//                }

//                if (pathNodeItems.Name == "Z")
//                {
//                    float.TryParse(pathNodeItems.InnerText, out vector.z);
//                    //string zString = pathNodeItems.InnerText.Replace(".", ",");
//                    //float.TryParse(zString, out position.z);
//                }
//            }
//            forwardVectorList.Add(vector);

//        }


//        foreach (XmlNode speedItems in aiPathNodeList_Speed)
//        {
//            speedList.Add(float.Parse(speedItems.InnerText));
//        }


//        XmlNodeList aiFinishtime = xmlDoc.GetElementsByTagName("TotalTime");
//        foreach (XmlNode timeItems in aiFinishtime)
//        {
//            double.TryParse(timeItems.InnerText, out finishTime);
//        }

//    }

//    void SetAnimationData()
//    {

//        Animation anim = GetComponent<Animation>();
//        AnimationCurve curve;

//        // create a new AnimationClip
//        AnimationClip clip = new AnimationClip();
//        clip.legacy = true;

//        AnimationEvent finishEvent = new AnimationEvent();
//        finishEvent.time = (float) (finishTime/1000);
//        finishEvent.functionName = "PrintFinishTimes";
//        clip.AddEvent(finishEvent);

//        // new event created
//        AnimationEvent evt;
//        evt = new AnimationEvent();
//        evt.intParameter = 12345;
//        evt.time = 0f;
//        evt.functionName = "PrintEvent";
//        clip.AddEvent(evt);


//        // create a curve to move the GameObject and assign to the clip
//        Keyframe[] keys;
//        keys = new Keyframe[positionList.Count * 3];

//        float timeLine = 0;
        
//        Keyframe[] keysPosition_X = new Keyframe[positionList.Count];
//        Keyframe[] keysPosition_Y = new Keyframe[positionList.Count];
//        Keyframe[] keysPosition_Z = new Keyframe[positionList.Count];

//        Keyframe[] keysRotation_X = new Keyframe[rotationList.Count];
//        Keyframe[] keysRotation_Y = new Keyframe[rotationList.Count];
//        Keyframe[] keysRotation_Z = new Keyframe[rotationList.Count];
//        Keyframe[] keysRotation_W = new Keyframe[rotationList.Count];

//        Keyframe[] keysUpVector_X = new Keyframe[positionList.Count];
//        Keyframe[] keysUpVector_Y = new Keyframe[positionList.Count];
//        Keyframe[] keysUpVector_Z = new Keyframe[positionList.Count];

//        Keyframe[] keysForwardVector_X = new Keyframe[positionList.Count];
//        Keyframe[] keysForwardVector_Y = new Keyframe[positionList.Count];
//        Keyframe[] keysForwardVector_Z = new Keyframe[positionList.Count];


//        Keyframe[] keysSpeed = new Keyframe[rotationList.Count];


//        for (int i = 0; i < keysPosition_X.Length; i++)
//        {
//            keysPosition_X[i] = new Keyframe(timeLine, positionList[i].x);
//            keysPosition_Y[i] = new Keyframe(timeLine, positionList[i].y);
//            keysPosition_Z[i] = new Keyframe(timeLine, positionList[i].z);

//            keysRotation_X[i] = new Keyframe(timeLine, rotationList[i].x);
//            keysRotation_Y[i] = new Keyframe(timeLine, rotationList[i].y);
//            keysRotation_Z[i] = new Keyframe(timeLine, rotationList[i].z);
//            keysRotation_W[i] = new Keyframe(timeLine, rotationList[i].w);

//            keysUpVector_X[i] = new Keyframe(timeLine, upVectorList[i].x);
//            keysUpVector_Y[i] = new Keyframe(timeLine, upVectorList[i].y);
//            keysUpVector_Z[i] = new Keyframe(timeLine, upVectorList[i].z);

//            keysForwardVector_X[i] = new Keyframe(timeLine, forwardVectorList[i].x);
//            keysForwardVector_Y[i] = new Keyframe(timeLine, forwardVectorList[i].y);
//            keysForwardVector_Z[i] = new Keyframe(timeLine, forwardVectorList[i].z);


//            keysSpeed[i] = new Keyframe(timeLine, speedList[i]);

//            timeLine += 0.1f;
//        }

//        curve = new AnimationCurve(keysPosition_X);
//        clip.SetCurve("", typeof(Transform), "localPosition.x", curve);
//        curve = new AnimationCurve(keysPosition_Y);
//        clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
//        curve = new AnimationCurve(keysPosition_Z);
//        clip.SetCurve("", typeof(Transform), "localPosition.z", curve);

//        //curve = new AnimationCurve(keysRotation_X);
//        //clip.SetCurve("", typeof(Transform), "localRotation.x", curve);
//        //curve = new AnimationCurve(keysRotation_Y);
//        //clip.SetCurve("", typeof(Transform), "localRotation.y", curve);
//        //curve = new AnimationCurve(keysRotation_Z);
//        //clip.SetCurve("", typeof(Transform), "localRotation.z", curve);
//        //curve = new AnimationCurve(keysRotation_W);
//        //clip.SetCurve("", typeof(Transform), "localRotation.w", curve);

//        curve = new AnimationCurve(keysRotation_X);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_x", curve);
//        curve = new AnimationCurve(keysRotation_Y);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_y", curve);
//        curve = new AnimationCurve(keysRotation_Z);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_z", curve);
//        curve = new AnimationCurve(keysRotation_W);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_w", curve);

//        curve = new AnimationCurve(keysRotation_X);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_x", curve);
//        curve = new AnimationCurve(keysRotation_Y);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_y", curve);
//        curve = new AnimationCurve(keysRotation_Z);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_z", curve);
//        curve = new AnimationCurve(keysRotation_W);
//        clip.SetCurve("", typeof(AnimationStats), "rotation_w", curve);

//        curve = new AnimationCurve(keysUpVector_X);
//        clip.SetCurve("", typeof(AnimationStats), "upVector_x", curve);
//        curve = new AnimationCurve(keysUpVector_Y);
//        clip.SetCurve("", typeof(AnimationStats), "upVector_y", curve);
//        curve = new AnimationCurve(keysUpVector_Z);
//        clip.SetCurve("", typeof(AnimationStats), "upVector_z", curve);

//        curve = new AnimationCurve(keysForwardVector_X);
//        clip.SetCurve("", typeof(AnimationStats), "forwardVector_x", curve);
//        curve = new AnimationCurve(keysForwardVector_Y);
//        clip.SetCurve("", typeof(AnimationStats), "forwardVector_y", curve);
//        curve = new AnimationCurve(keysForwardVector_Z);
//        clip.SetCurve("", typeof(AnimationStats), "forwardVector_z", curve);


//        curve = new AnimationCurve(keysSpeed);
//        clip.SetCurve("", typeof(AnimationStats), "speed", curve);
//        //keys[0] = new Keyframe(0.0f, 0.0f);
//        //keys[1] = new Keyframe(1.0f, 1.5f);
//        //keys[2] = new Keyframe(2.0f, 0.0f);
//        //curve = new AnimationCurve(keys);
//        //clip.SetCurve("", typeof(Transform), "localPosition.x", curve);

//        // now animate the GameObject
//        anim.AddClip(clip, clip.name);
//        anim.Play(clip.name);

//#if UNITY_EDITOR
//        AssetDatabase.CreateAsset(clip, "Assets/Prefabs/AI/" + GameAsset.name + ".anim");
//        AssetDatabase.SaveAssets();
//#endif


//    }

//    public void PrintFinishTimes()
//    {
//        int seconds = (int)(finishTime / 1000);
//        int mins = seconds / 60;
//        seconds = seconds % 60;
//        int miliseconds = (int)(finishTime % 1000);



//        print("FinishTime: " + mins +":"+seconds+"."+miliseconds);
//    }

//    public void PrintEvent(int i)
//    {
//        print("PrintEvent: " + i + " called at: " + Time.time);
//    }


//}