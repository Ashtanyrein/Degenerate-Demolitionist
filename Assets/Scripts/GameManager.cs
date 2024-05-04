using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int budget = 20;
    public GameObject BudgetCounter;
    public StructureManager Structure;
    public bool itemPurchased = false;
    public bool showShop = true;
    private TMPro.TextMeshProUGUI budgetCounterNumber;
    public GameObject bombButton;
    public GameObject shop;

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
        //Structure.shouldExplode = !Structure.shouldExplode;
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        // Wait for 0.5 seconds
        Structure.shouldExplode = true;
        yield return new WaitForSeconds(0.5f);
        bombButton.SetActive(false);
        shop.SetActive(false);
    }

    public void SetItemPurchased(bool purchased)
    {
        itemPurchased = purchased;
    }

    public bool IsItemPurchased()
    {
        return itemPurchased;
    }
}
