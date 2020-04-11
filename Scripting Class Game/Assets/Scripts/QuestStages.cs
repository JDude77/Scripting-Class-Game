using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStages : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private int stage;
    #endregion

    #region Getters
    public int getCurrentStage()
    {
        return stage;
    }//End Stage Getter
    #endregion

    #region Behaviours
    // Start is called before the first frame update
    private void Start()
    {
        stage = 0;
    }//End Start

    public void nextQuestStage()
    {
        stage++;
    }//End nextQuestStage
    #endregion
}