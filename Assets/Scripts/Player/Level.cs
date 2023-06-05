using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    [SerializeField] ExperienceBar experienceBar;

    public int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void AddExperince(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
        }
    }
}
