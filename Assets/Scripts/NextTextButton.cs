using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTextButton : MonoBehaviour
{
    CSVInterpreter csvInterpreter;
    Sprite REGAN;
    Sprite HELLGA;
    Sprite NONE;

    public GameObject classroom_bg;
    public GameObject rehan_room_bg;
    public GameObject hellga_room_bg;
    public GameObject bar_bg;
    public GameObject park_bg;

    // Start is called before the first frame update
    void Start()
    {
        csvInterpreter = new CSVInterpreter();
        csvInterpreter.readCSV("game.csv");

        setFromCSVCurrLine();
    }

    public void next()
    {
       csvInterpreter.loadNextLine();
       setFromCSVCurrLine();
    }

    public void registerChoice(int choice)
    {
      Debug.Log("Choice registered : " + choice);

      // (1) Hide/show the correct buttons
      GameObject.Find("Choice1").GetComponent<Image>().enabled = false;
      GameObject.Find("Choice1").GetComponentInChildren<Text>().enabled = false;

      GameObject.Find("Choice2").GetComponent<Image>().enabled = false;
      GameObject.Find("Choice2").GetComponentInChildren<Text>().enabled = false;

      GameObject.Find("Choice3").GetComponent<Image>().enabled = false;
      GameObject.Find("Choice3").GetComponentInChildren<Text>().enabled = false;

      GameObject.Find("Button").GetComponent<Image>().enabled = true;
      GameObject.Find("Button").GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = true;

      //(2) Apply bar effects
      switch (choice)
      {
        case 1 :
          GameObject.Find("ReganLoveBar").GetComponent<Slider>().value =
            GameObject.Find("ReganLoveBar").GetComponent<Slider>().value + csvInterpreter.getChoice1RehanEffect();
          GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value =
            GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value + csvInterpreter.getChoice1HellgaEffect();
          break;
        case 2:
          GameObject.Find("ReganLoveBar").GetComponent<Slider>().value =
            GameObject.Find("ReganLoveBar").GetComponent<Slider>().value + csvInterpreter.getChoice2RehanEffect();
          GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value =
            GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value + csvInterpreter.getChoice2HellgaEffect();
          break;
        case 3:
          GameObject.Find("ReganLoveBar").GetComponent<Slider>().value =
            GameObject.Find("ReganLoveBar").GetComponent<Slider>().value + csvInterpreter.getChoice3RehanEffect();
          GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value =
            GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value + csvInterpreter.getChoice3HellgaEffect();
          break;
      }

      //(3) Prep to load a different CSV if applicable
      string nextCsv = "";
      switch (choice)
      {
        case 1 :
          nextCsv = csvInterpreter.getChoice1ResultCSV();
          break;
        case 2:
          nextCsv = csvInterpreter.getChoice2ResultCSV();
          break;
        case 3:
          nextCsv = csvInterpreter.getChoice3ResultCSV();
          break;
      }

      if (!nextCsv.Equals("-1"))
      {
        csvInterpreter = new CSVInterpreter();
        csvInterpreter.readCSV(nextCsv);
        setFromCSVCurrLine();
      }
    }

    void setFromCSVCurrLine()
    {
        int speaker = csvInterpreter.getSpeaker();
        string speakerName = "Error";
        switch(speaker)
        {
          case 0 :
            speakerName = "Player";
            break;
          case 1 :
            speakerName = "Helga";
            break;
          case 2 :
            speakerName = "Rehan";
            break;
          case 3 :
            speakerName = "Narrator";
            break;
          default :
            speakerName = "Error";
            break;
        }
        GameObject.Find("CharcterName").GetComponent<Text>().text = speakerName;

        GameObject.Find("DialogText").GetComponent<TMPro.TextMeshProUGUI>().text = csvInterpreter.getSpeechText();
        if (csvInterpreter.getSpeechText().Equals("%commence_ending%"))
        {
          float hellga_love = GameObject.Find("HellnaLoveBar").GetComponent<Slider>().value;
          float rehan_love = GameObject.Find("ReganLoveBar").GetComponent<Slider>().value;

          if (hellga_love >= rehan_love)
          {
            csvInterpreter.readCSV("hellga_ending.csv");
            setFromCSVCurrLine();
          }
          else
          {
            csvInterpreter.readCSV("rehan_ending.csv");
            setFromCSVCurrLine();
          }
        }
        else
        {
          if (csvInterpreter.getIsChar1Present() == 0)
          {
            GameObject.Find("CharHellga").GetComponent<Image>().enabled = false;
            GameObject.Find("CharHellga_Dark").GetComponent<Image>().enabled = false;
          }
          else if (csvInterpreter.getIsChar1Present() == 1)
          {
            GameObject.Find("CharHellga").GetComponent<Image>().enabled = true;
            GameObject.Find("CharHellga_Dark").GetComponent<Image>().enabled = false;
          }
          else if (csvInterpreter.getIsChar1Present() == 2)
          {
            GameObject.Find("CharHellga").GetComponent<Image>().enabled = false;
            GameObject.Find("CharHellga_Dark").GetComponent<Image>().enabled = true;
          }

          if (csvInterpreter.getIsChar2Present() == 0)
          {
            GameObject.Find("CharRehan").GetComponent<Image>().enabled = false;
            GameObject.Find("CharRehan_Dark").GetComponent<Image>().enabled = false;
          }
          else if (csvInterpreter.getIsChar2Present() == 1)
          {
            GameObject.Find("CharRehan").GetComponent<Image>().enabled = true;
            GameObject.Find("CharRehan_Dark").GetComponent<Image>().enabled = false;
          }
          else if (csvInterpreter.getIsChar2Present() == 2)
          {
            GameObject.Find("CharRehan").GetComponent<Image>().enabled = false;
            GameObject.Find("CharRehan_Dark").GetComponent<Image>().enabled = true;
          }

          string choice1text = csvInterpreter.getChoice1Text();
          string choice2text = csvInterpreter.getChoice2Text();
          string choice3text = csvInterpreter.getChoice3Text();
          bool isChoice = false;
          if (!choice1text.Equals("-1"))
          {
            GameObject.Find("Choice1").GetComponent<Image>().enabled = true;
            GameObject.Find("Choice1").GetComponentInChildren<Text>().enabled = true;
            GameObject.Find("Choice1").GetComponentInChildren<Text>().text = choice1text;
            isChoice = true;
          }
          else
          {
            GameObject.Find("Choice1").GetComponent<Image>().enabled = false;
            GameObject.Find("Choice1").GetComponentInChildren<Text>().enabled = false;
          }
          if (!choice2text.Equals("-1"))
          {
            GameObject.Find("Choice2").GetComponent<Image>().enabled = true;
            GameObject.Find("Choice2").GetComponentInChildren<Text>().enabled = true;
            GameObject.Find("Choice2").GetComponentInChildren<Text>().text = choice2text;
            isChoice = true;
          }
          else
          {
            GameObject.Find("Choice2").GetComponent<Image>().enabled = false;
            GameObject.Find("Choice2").GetComponentInChildren<Text>().enabled = false;
          }
          if (!choice3text.Equals("-1"))
          {
            GameObject.Find("Choice3").GetComponent<Image>().enabled = true;
            GameObject.Find("Choice3").GetComponentInChildren<Text>().enabled = true;
            GameObject.Find("Choice3").GetComponentInChildren<Text>().text = choice3text;
            isChoice = true;
          }
          else
          {
            GameObject.Find("Choice3").GetComponent<Image>().enabled = false;
            GameObject.Find("Choice3").GetComponentInChildren<Text>().enabled = false;
          }
          if (isChoice)
          {
            GameObject.Find("Button").GetComponent<Image>().enabled = false;
            GameObject.Find("Button").GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
          }
          else
          {
            GameObject.Find("Button").GetComponent<Image>().enabled = true;
            GameObject.Find("Button").GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = true;
          }

          string background = csvInterpreter.getBackground();
          Debug.Log("background requested : " + background);
          if (background.Equals("RehanRoom"))
          {
            rehan_room_bg.SetActive(true);
            hellga_room_bg.SetActive(false);
            park_bg.SetActive(false);
            classroom_bg.SetActive(false);
            bar_bg.SetActive(false);
          }
          else if (background.Equals("HellgaRoom"))
          {
            rehan_room_bg.SetActive(false);
            hellga_room_bg.SetActive(true);
            park_bg.SetActive(false);
            classroom_bg.SetActive(false);
            bar_bg.SetActive(false);
          }
          else if (background.Equals("Garden"))
          {
            rehan_room_bg.SetActive(false);
            hellga_room_bg.SetActive(false);
            park_bg.SetActive(true);
            classroom_bg.SetActive(false);
            bar_bg.SetActive(false);
          }
          else if (background.Equals("class"))
          {
            rehan_room_bg.SetActive(false);
            hellga_room_bg.SetActive(false);
            park_bg.SetActive(false);
            classroom_bg.SetActive(true);
            bar_bg.SetActive(false);
          }
          else if (background.Equals("bar"))
          {
            rehan_room_bg.SetActive(false);
            hellga_room_bg.SetActive(false);
            park_bg.SetActive(false);
            classroom_bg.SetActive(false);
            bar_bg.SetActive(true);
          }
      }
    }
}
