using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangerTimer : MonoBehaviour
{

    public float offset=0f;
    public float greenTime=0f;
    public float yellowTime=0f;
    public float redTime=0f;

    public Sprite redSprite;
    public Sprite yellowRedSprite;
    public Sprite greenSprite;
    public Sprite yellowSprite;

    public bool isValid = false;

    public enum State
    {
        Init,
        Offset,
        Red,
        YellowRed,
        Green,
        Yellow
    }

    public Dictionary<State, Sprite> states = new Dictionary<State, Sprite>();


    public State currentState = State.Init;

    public float timer;
    
    void Start()
    {
        if(offset==0f || greenTime == 0f || yellowTime == 0f || redTime == 0f)
        {
            isValid = false;
        }
        states.Add(State.Init, redSprite);
        states.Add(State.Offset, redSprite);
        states.Add(State.Red, redSprite);
        states.Add(State.YellowRed, yellowRedSprite);
        states.Add(State.Green, greenSprite);
        states.Add(State.Yellow, yellowSprite);
    }

    void Update()
    {
        if (isValid)
        {
            if (timer <= 0f)
            {
                switch (currentState)
                {
                    case State.Init:
                        timer = offset;
                        currentState = State.Offset;
                        ChangeSprite();
                        break;
                    case State.Offset:
                        timer = yellowTime;
                        currentState = State.YellowRed;
                        ChangeSprite();
                        break;
                    case State.YellowRed:
                        timer = greenTime;
                        currentState = State.Green;
                        ChangeSprite();
                        break;
                    case State.Green:
                        timer = yellowTime;
                        currentState = State.Yellow;
                        ChangeSprite();
                        break;
                    case State.Yellow:
                        timer = redTime;
                        currentState = State.Red;
                        ChangeSprite();
                        break;
                    case State.Red:
                        timer = yellowTime;
                        currentState = State.YellowRed;
                        ChangeSprite();
                        break;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void ChangeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = states[currentState];
        Debug.Log(states[currentState]);
    }
}
