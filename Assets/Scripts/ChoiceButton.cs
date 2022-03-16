using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public int selected;
    public NextTextButton nTB;

    public void setChoice(int choice)
    {
      nTB.registerChoice(choice);
    }
}
