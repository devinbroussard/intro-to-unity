using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalHealthTextBehaviour : MonoBehaviour
{ 
    public Text HealthText;
    public GoalBehaviour Goal;

    private void Update()
    {
        float health = Goal.Health;
        if (health < 0) health = 0;
        HealthText.text = $"Hits left: {health}";
    }
}
