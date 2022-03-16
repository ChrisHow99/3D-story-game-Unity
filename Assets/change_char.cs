
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;

    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKey(KeyCode.Space))
        {
            m_Image.sprite = m_Sprite;
        }
    }
}