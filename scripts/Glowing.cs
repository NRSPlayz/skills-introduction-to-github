using System.Collections;
using UnityEngine;

public class Glowing : MonoBehaviour
{
    // Public references to the 6 objects
    public GameObject RightUp;
    public GameObject LeftUp;
    public GameObject LeftDown;
    public GameObject RightDown;
    public GameObject RightFoot;
    public GameObject LeftFoot;

    private float timer = 3f; // Time interval to change the tag (3 seconds)

    void Start()
    {
        StartCoroutine(AssignGlowingTag());
    }

    // Coroutine to assign the glowing tag randomly every 3 seconds
    IEnumerator AssignGlowingTag()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);

            // Remove the "Glowing" tag from all objects
            RightUp.tag = "Untagged";
            LeftUp.tag = "Untagged";
            LeftDown.tag = "Untagged";
            RightDown.tag = "Untagged";
            RightFoot.tag = "Untagged";
            LeftFoot.tag = "Untagged";

            // Randomly pick one object and assign the "Glowing" tag
            int randomIndex = Random.Range(0, 6);
            switch (randomIndex)
            {
                case 0:
                    RightUp.tag = "Glowing";
                    RightUp.SetActive(true);
                    Debug.Log("RightUp");
                    break;
                case 1:
                    LeftUp.tag = "Glowing";
                    LeftUp.SetActive(true);
                    Debug.Log("LeftUp");
                    break;
                case 2:
                    LeftDown.tag = "Glowing";
                    LeftDown.SetActive(true);
                    Debug.Log("LeftDown");
                    break;
                case 3:
                    RightDown.tag = "Glowing";
                    RightDown.SetActive(true);
                    Debug.Log("RightDown");
                    break;
                case 4:
                    RightFoot.tag = "Glowing";
                    RightFoot.SetActive(true);
                    Debug.Log("RightFoot");
                    break;
                case 5:
                    LeftFoot.tag = "Glowing";
                    LeftFoot.SetActive(true);
                    Debug.Log("LeftFoot");
                    break;
            }
        }
    }
}