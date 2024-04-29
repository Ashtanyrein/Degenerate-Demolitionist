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

    void Start()
    {
        budgetCounterNumber = BudgetCounter.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        budgetCounterNumber.text = budget.ToString();    
    }

    public void TriggerExplosives()
    {
        Structure.shouldExplode = !Structure.shouldExplode;
        StartCoroutine(ResetExplosion());
    }

    private IEnumerator ResetExplosion()
    {
        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);
        // Reset shouldExplode to false after 0.5 seconds
        Structure.shouldExplode = false;
    }
}
