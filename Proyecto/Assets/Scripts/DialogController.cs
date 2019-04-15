using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField]
    GameObject[] actionGround;
    [SerializeField]
    GameObject dialogBox;
    [SerializeField]
    Text dialogText;

    //Writting letter by letter
    public float letterPause = 0.2f;

    private void Start()
    {
        dialogText = dialogText.GetComponent<Text>();
    }

    [TextArea]
    public string[] Dialog;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject item in actionGround)
        {
            if (item.name == other.name)
            {
                int index = System.Array.IndexOf(actionGround, item);
                StartCoroutine(TypeText(index));
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogBox.SetActive(false);
        dialogText.text = "";                      
    }

    IEnumerator TypeText(int index)
    {
        dialogBox.SetActive(true);
        foreach (char letter in Dialog[index].ToCharArray())
        {
                dialogText.text += letter;
                yield return 0;
                yield return new WaitForSeconds(letterPause);          
        }
    }
}