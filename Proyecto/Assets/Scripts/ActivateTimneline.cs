using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ActivateTimneline : MonoBehaviour
{
    [SerializeField]
    PlayableDirector timeline;
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(timeline.Play);
    }
}
