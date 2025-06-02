using System;
using System.IO;
using UnityEngine;

public class FileReader
{
    public string PersistentFilePath => Path.Combine(Application.persistentDataPath, "data.txt");
    public string ResourcesFilePath => "data";

    public int[,] ReadFromResourcesFile()
    {
        var textAsset = Resources.Load<TextAsset>(ResourcesFilePath);
        if (textAsset == null)
            throw new NullReferenceException("Cannot find resources file");

        var text = textAsset.text;
        var lines = text.Split('\n');
        if(lines.Length == 0 || lines[0].Length == 0)
            throw new NullReferenceException("File is empty");

        var data = Parse(lines);
        return data;
    }

    public int[,] ReadFromPersistentFile()
    {
        if (!File.Exists(PersistentFilePath))
        {
            File.Create(PersistentFilePath).Close();
            File.WriteAllText(PersistentFilePath, "1 1 1\n2 2 2\n3 3 3\n");
        }
        
        string[] lines = File.ReadAllLines(PersistentFilePath);

        if (lines.Length == 0 || lines[0].Length == 0)
        {
            throw new NullReferenceException("File is empty");
        }

        int[,] data = Parse(lines);
        return data;
    }

    private int[,] Parse(string[] lines)
    {
        int width = lines[0].Split(' ').Length;
        int height = 0;
        foreach (var line in lines)
        {
            if (line.Length == 0) break;

            height++;
        }
        
        int[,] data = new int[width, height];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] strNumber = lines[i].Split(' ');
            
            if (strNumber.Length != width)
            {
                throw new Exception("Array is not a matrix");
            }
            
            for (int j = 0; j < strNumber.Length; j++)
            {
                if (!int.TryParse(strNumber[j], out int number))
                {
                    throw new Exception($"Cannot parse the number {strNumber[j]}");
                }
                data[i, j] = number;
            }
        }

        return data;
    }
}