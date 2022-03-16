using System;
using UnityEngine;

public class CSVInterpreter
{
    const int isChar1Present = 0;
    const int isChar2Present = 1;
    const int text = 2;
    const int speaker = 3;

    const int choice1_text = 4;
    const int choice1_split = 5;
    const int choice1_helga_effect = 6;
    const int choice1_rehan_effect = 7;

    const int choice2_text = 8;
    const int choice2_split = 9;
    const int choice2_helga_effect = 10;
    const int choice2_rehan_effect = 11;

    const int choice3_text = 12;
    const int choice3_split = 13;
    const int choice3_helga_effect = 14;
    const int choice3_rehan_effect = 15;

    const int background = 16;

    string[] loadedLines;
    string[] currentLine;
    int currentIndex;

    // Update is called once per frame
    public void readCSV(string name)
    {
      string csvPath = "Assets/CSVScenes/" + name;
      string fileContents  = System.IO.File.ReadAllText(csvPath);
      loadedLines = fileContents.Split("\n"[0]);

      currentIndex = 1;
      currentLine = loadedLines[currentIndex].Trim().Split(","[0]);

      //Debug.Log("Loaded CSV file " + name + ";");
      //foreach(string s in loadedLines)
      //{
      //  Debug.Log("CSV line : " + s);
      //}
    }

    public void loadNextLine()
    {
      currentIndex++;
      currentLine = loadedLines[currentIndex].Trim().Split(","[0]);

      Debug.Log("loadNextLine() :");
      foreach (string s in currentLine)
      {
          Debug.Log(s);
      }
    }

    public int getIsChar1Present()
    {
      return Int32.Parse(currentLine[isChar1Present]);
    }

    public int getIsChar2Present()
    {
      return Int32.Parse(currentLine[isChar2Present]);
    }

    // 0 = player, 1 = char 1, 2 = char 2
    public int getSpeaker()
    {
      Debug.Log("getSpeaker() trying to get entry " + speaker);
      Debug.Log("getSpeaker() trying to parse" + currentLine[speaker] + " into an Int");

      return Int32.Parse(currentLine[speaker]);
    }

    public string getSpeechText()
    {
      return currentLine[text];
    }

    public string getChoice1Text()
    {
      return currentLine[choice1_text];
    }

    public string getChoice1ResultCSV()
    {
      return currentLine[choice1_split];
    }

    public int getChoice1HellgaEffect()
    {
      return Int32.Parse(currentLine[choice1_helga_effect]);
    }

    public int getChoice1RehanEffect()
    {
      return Int32.Parse(currentLine[choice1_rehan_effect]);
    }


    public string getChoice2Text()
    {
      return currentLine[choice2_text];
    }

    public string getChoice2ResultCSV()
    {
      return currentLine[choice2_split];
    }

    public int getChoice2HellgaEffect()
    {
      return Int32.Parse(currentLine[choice2_helga_effect]);
    }

    public int getChoice2RehanEffect()
    {
      return Int32.Parse(currentLine[choice2_rehan_effect]);
    }


    public string getChoice3Text()
    {
      return currentLine[choice3_text];
    }

    public string getChoice3ResultCSV()
    {
      return currentLine[choice3_split];
    }

    public int getChoice3HellgaEffect()
    {
      return Int32.Parse(currentLine[choice3_helga_effect]);
    }

    public int getChoice3RehanEffect()
    {
      return Int32.Parse(currentLine[choice3_rehan_effect]);
    }

    public string getBackground()
    {
      return currentLine[background];
    }

}
