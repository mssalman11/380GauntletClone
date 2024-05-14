using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script creates static variables for scores to be referenced to for each player.
public class PlayerScores : MonoBehaviour
{
    public static int WarriorScore;
    public static int ValkyrieScore;
    public static int WizardScore;
    public static int ElfScore;

    private void Start()
    {
        WarriorScore = 0;
        ValkyrieScore = 0;
        WizardScore = 0;
        ElfScore = 0;
    }
}
