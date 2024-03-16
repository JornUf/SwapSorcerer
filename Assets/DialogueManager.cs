using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<string> dialogue = new List<string>();

    public List<string> triggereddialogue = new List<string>();

    [SerializeField] private TextMeshProUGUI UItext;

    [SerializeField] private RectTransform container;

    [SerializeField] private RectTransform goal;

    [SerializeField] private RectTransform goalout;

    [SerializeField] private UnityEvent starttalk = new UnityEvent();

    [SerializeField] private UnityEvent stoptalk = new UnityEvent();

    [SerializeField] private float speed = 2;

    private currentdialogue _currentdialogue = currentdialogue.none;
    private int dialoguect = 0;

    private bool movein = false;
    private bool moveout = false;


    enum currentdialogue
    {
        startdialogue,
        triggereddialogue,
        none
    }
    // Start is called before the first frame update
    void Start()
    {
        dialoguect = 0;
        _currentdialogue = currentdialogue.startdialogue;
        movein = true;
        dodialogue(dialogue);
        starttalk.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (movein)
        {
            if (container.position.x <= goal.position.x)
            {
                container.position += new Vector3(speed, 0, 0);
                return;
            }
            else
            {
                movein = false;
            }
        }

        if (moveout)
        {
            if (container.position.x >= goalout.position.x)
            {
                container.position -= new Vector3(speed, 0, 0);
                return;
            }
            else
            {
                moveout = false;
            }
        } 
        if (Input.GetMouseButtonUp(0) && _currentdialogue != currentdialogue.none)
        {
            if (_currentdialogue == currentdialogue.startdialogue)
            {
                if (dialoguect < dialogue.Count)
                {
                    dodialogue(dialogue);
                }
                else
                {
                    stopdialogue();
                }
            }

            if (_currentdialogue == currentdialogue.triggereddialogue)
            {
                if (dialoguect < triggereddialogue.Count)
                {
                    dodialogue(triggereddialogue);

                }
                else
                {
                    stopdialogue();
                }
            }
        }
    }

    void dodialogue(List<string> dia)
    {
        UItext.text = dia[dialoguect];
        dialoguect++;
    }

    public void triggerdia()
    {
        dialoguect = 0;
        _currentdialogue = currentdialogue.triggereddialogue;
        movein = true;
        dodialogue(triggereddialogue);
    }

    void stopdialogue()
    {
        dialoguect = 0;
        _currentdialogue = currentdialogue.none;
        moveout = true;
        stoptalk.Invoke();
    }
}
