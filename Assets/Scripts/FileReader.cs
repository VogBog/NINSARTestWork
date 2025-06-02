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
        var lines = text.Split(Environment.NewLine);
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
            File.WriteAllText(PersistentFilePath, "111\n222\n333\n");
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
        int width = lines[0].Length;
        int height = 0;
        foreach (var line in lines)
        {
            if (line.Length == 0) break;

            height++;
        }
        
        int[,] data = new int[width, height];

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length != width)
            {
                throw new Exception("Array is not a matrix");
            }
            
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (!int.TryParse(lines[i][j].ToString(), out int number))
                {
                    throw new Exception($"Cannot parse the number {lines[i][j]} at indexes {i} {j}");
                }
                data[i, j] = number;
            }
        }

        return data;
    }
}