using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;

using Varjo.XR;

public class Controller : MonoBehaviour
{
    public SetupPattern pattern;
    public string eventLog = "events.csv";
    public string frameLog = "frames.csv";

    public GameObject head;

    private bool curShowing = false;
    private bool finished = false;

    private StreamWriter eventWriter;
    private StreamWriter frameWriter;

    private FileStream eventStream;
    private FileStream frameStream;

    private string curPattern = "";

    private List<string> eventLines = new List<string>();
    private List<string> frameLines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        string datetimeString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string realistic = pattern.realistic ? "realistic" : "abstract";
        eventStream = new FileStream($"Output\\{datetimeString}_{realistic}_{eventLog}", FileMode.CreateNew);
        frameStream = new FileStream($"Output\\{datetimeString}_{realistic}_{frameLog}", FileMode.CreateNew);

        using (StreamWriter writer = new StreamWriter(eventStream, Encoding.UTF8, 512, true))
        {
            writer.WriteLine("SysTime,GameTime,Event");
        }

        using (StreamWriter writer = new StreamWriter(frameStream, Encoding.UTF8, 512, true))
        {
            writer.WriteLine("SysTime,GameTime,Condition,HeadPosX,HeadPosY,HeadPosZ,HeadRotX,HeadRotY,HeadRotZ,EyeGazeOriginX,EyeGazeOriginY,EyeGazeOriginZ,EyeGazeDirX,EyeGazeDirY,EyeGazeDirZ,LeftPupilDiameter,RightPupilDiameter");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (curShowing)
                {
                    eventLines.Add($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")},{Time.time},hide {curPattern}");
                    finished = pattern.Hide();
                    curShowing = false;

                    DumpEventLines();
                    DumpFrameLines();
                }
                else
                {
                    curPattern = pattern.Show();
                    eventLines.Add($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")},{Time.time},show {curPattern}");
                    
                    curShowing = true;
                }
            }

            if (curShowing)
            {
                Vector3 headPos = head.transform.position;
                Vector3 headRot = head.transform.rotation.eulerAngles;

                VarjoEyeTracking.GazeData gazeData = VarjoEyeTracking.GetGaze();
                VarjoEyeTracking.EyeMeasurements eyeMeasurements = VarjoEyeTracking.GetEyeMeasurements();

                Vector3 rayOrigin = gazeData.gaze.origin;
                Vector3 rayDir = gazeData.gaze.forward;


                frameLines.Add($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")},{Time.time},{curPattern},{headPos.x},{headPos.y},{headPos.z},{headRot.x},{headRot.y},{headRot.z},{rayOrigin.x},{rayOrigin.y},{rayOrigin.z},{rayDir.x},{rayDir.y},{rayDir.z},{eyeMeasurements.leftPupilDiameterInMM},{eyeMeasurements.rightPupilDiameterInMM}");
            }
        }
    }

    private void DumpEventLines()
    {
        using (StreamWriter writer = new StreamWriter(eventStream, Encoding.UTF8, 512, true))
        {
            foreach (string line in eventLines)
            {
                writer.WriteLine(line);
            }

            eventLines.Clear();
        }
    }

    private void DumpFrameLines()
    {
        using (StreamWriter writer = new StreamWriter(frameStream, Encoding.UTF8, 512, true))
        {
            foreach (string line in frameLines)
            {
                writer.WriteLine(line);
            }

            frameLines.Clear();
        }
    }

    void OnApplicationQuit()
    {
        DumpEventLines();
        using (StreamWriter writer = new StreamWriter(eventStream, Encoding.UTF8, 512, true))
        {
            writer.Close();
        }

        DumpFrameLines();
        using (StreamWriter writer = new StreamWriter(frameStream, Encoding.UTF8, 512, true))
        {
            writer.Close();
        }
    }
}
