using UnityEngine;
using System.IO;

public class TestReadWrite : MonoBehaviour
{
    public string textFileName;
    public string[] textFileContents;

    private bool debug = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textFileName = "easyWords";
        CreateNewTextFile(textFileName);

        WriteToTextFile(textFileName, "append this message to txt file");

        textFileContents = ReadTextFileContents(textFileName);
    }

    
    public void CreateNewTextFile(string filename)
    {
        string directoryPath = Application.dataPath + "/DataFile/" + filename + ".txt";

        if (debug == true)
        {
            Debug.Log(directoryPath);
        }

        if (File.Exists(directoryPath) == false)
        { 
            Directory.CreateDirectory(Application.dataPath + "/DataFile/");
            File.WriteAllText(directoryPath, filename + "\n\n" + "hello world!");
        }


    }

    public void WriteToTextFile(string filename, string data)
    {
        string directoryPath = Application.dataPath + "/DataFile/" + filename + ".txt";

        File.AppendAllText(directoryPath, data);
    }

    public string[] ReadTextFileContents(string filename)
    {
        string directoryPath = Application.dataPath + "/DataFile/" + filename + ".txt";

        string[] fileContents = new string[0];

        if (File.Exists(directoryPath) == false)
        {
            textFileContents = File.ReadAllLines(directoryPath);
        }


        return fileContents;
    }

}
