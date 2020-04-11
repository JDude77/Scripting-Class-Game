using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    protected QuestStages stages;
    [SerializeField]
    protected bool isInteractive;
    [SerializeField]
    protected int questStageForUse;
    [SerializeField]
    protected string hudText;
    [SerializeField]
    protected AudioClip audio;
    [SerializeField]
    protected GameObject soundThing;

    public bool getIsInteractive()
    {
        return isInteractive;
    }//End getIsInteractive

    public void setIsInteractive(bool value)
    {
        isInteractive = value;
    }//End setIsInteractive

    public string getHUDText()
    {
        return hudText;
    }//End getHUDText

    public virtual void interact()
    {
        if(audio != null)
        {
            soundThing = Instantiate(soundThing, transform);
            soundThing.transform.parent = null;
            soundThing.GetComponent<AudioSource>().clip = audio;
            soundThing.GetComponent<AudioSource>().loop = false;
            soundThing.GetComponent<AudioSource>().Play();
        }//End if
    }//End interact

    protected void Awake()
    {
        stages = GameObject.FindGameObjectWithTag("Quest Tracker").GetComponent<QuestStages>();
        soundThing = (GameObject) Resources.Load("Prefabs/Soundthing");
    }//End Awake

    protected virtual void Start()
    {
        isInteractive = false;
    }//End Start

    protected virtual void Update()
    {
        if(stages.getCurrentStage() == questStageForUse)
        {
            isInteractive = true;
        }//End if
        else
        {
            isInteractive = false;
        }//End else
    }//End Update
}