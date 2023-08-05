using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveObjectTransform : MonoBehaviour
{
    [ContextMenu("Save Transform")]
    public void SaveTransform()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/objectsTransform.sv";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        Transform[] objects = transform.GetComponentsInChildren<Transform>();
        float[,] objectsData = new float[objects.Length, 6];
        for (int i = 0; i < objects.Length; i++)
        {
            objectsData[i, 0] = objects[i].position.x;
            objectsData[i, 1] = objects[i].position.y;
            objectsData[i, 2] = objects[i].position.z;
            objectsData[i, 3] = objects[i].localEulerAngles.x;
            objectsData[i, 4] = objects[i].localEulerAngles.y;
            objectsData[i, 5] = objects[i].localEulerAngles.z;
        }

        formatter.Serialize(stream, objectsData);
        stream.Close();

        Debug.Log("Data saved in " + path);
    }

    [ContextMenu("Load Transform")]
    public void LoadTransform()
    {
        string path = Application.persistentDataPath + "/objectsTransform.sv";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            float[,] objectsData = formatter.Deserialize(stream) as float[,];
            stream.Close();

            Debug.Log("Data loaded from path " + path);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).position = new Vector3(objectsData[i, 0], objectsData[i, 1], objectsData[i, 2]);
                transform.GetChild(i).localEulerAngles = new Vector3(objectsData[i, 3], objectsData[i, 4], objectsData[i, 5]);
            }
        } else
        {
            Debug.Log("No saved data exist in " + path);
        }
    }
}
