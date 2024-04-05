using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int budget = 20;
    public GameObject BudgetCounter;
    public StructureManager Structure;

    private TMPro.TextMeshProUGUI budgetCounterNumber;

    public void TriggerExplosives()
    {
        Structure.shouldExplode = true;
    }
    void Start()
    {
        budgetCounterNumber = BudgetCounter.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        budgetCounterNumber.text = budget.ToString();    
    }
}
