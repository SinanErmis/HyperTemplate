using System;
using UnityEngine;

namespace Rhodos
{
    public class CsvUtility
    {

        public static string[,] Parse(string text)
        {
            string[] lines = text.Trim().Split('\n');

            string[,] returnValues = new string[lines.Length, lines[0].Split(',').Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] cellsOfLine = lines[i].Split(',');

                for (int j = 0; j < cellsOfLine.Length; j++)
                {
                    string cellValue = cellsOfLine[j].Trim().Trim('\n');
                    returnValues[i, j] = cellValue;
                }
            }

            return returnValues;
        }
        public static string[,] Parse(ref TextAsset txt)
        {
            return Parse(txt.text);
        }

        public static void SaveAsCsv(ref char[,] chars, string path)
        {
            string stringToSave = String.Empty;

            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = 0; j < chars.GetLength(1); j++)
                {
                    stringToSave += chars[i, j];
                    stringToSave += ',';
                }

                if (i != chars.GetLength(0))
                    stringToSave += '\n';
            }

            System.IO.File.WriteAllText(path, stringToSave);
        }
        public static void SaveAsCsv(in string[,] strings, string path)
        {
            char[,] chars = new char[strings.GetLength(0), strings.GetLength(1)];
            
            for (int i = 0; i < strings.GetLength(0); i++)
            {
                for (int j = 0; j < strings.GetLength(1); j++)
                {
                    chars[i, j] = strings[i, j].Trim().Trim('\n').ToCharArray(0, 1)[0];
                }    
            }
            SaveAsCsv(ref chars, path);
        }

    }
}