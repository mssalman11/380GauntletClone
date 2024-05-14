using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
