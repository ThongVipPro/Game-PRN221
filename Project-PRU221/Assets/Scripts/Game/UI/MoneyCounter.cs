using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public int amount;

    Timer timer;

    PurchaseSuccessful purchaseSuccessful = new PurchaseSuccessful();
    PurchaseFailed purchaseFailed = new PurchaseFailed();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = amount.ToString();

        EventManager.AddSoldierDiedListener(AddMoney);
        EventManager.AddPurchaseListener(SpendMoney);
        EventManager.AddPurchaseSuccessfulInvoker(this);
        EventManager.AddPurchaseFailedInvoker(this);

        // Initiates timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            amount += 10;
            gameObject.GetComponent<TextMeshProUGUI>().text = amount.ToString();

            timer.Duration = 1;
            timer.Run();
        }
    }

    public void AddMoney(int money)
    {
        amount += money;
        gameObject.GetComponent<TextMeshProUGUI>().text = amount.ToString();
    }

    public void SpendMoney(int i, int money)
    {
        if (amount >= money)
        {
            amount -= money;
            gameObject.GetComponent<TextMeshProUGUI>().text = amount.ToString();
            purchaseSuccessful.Invoke(i);
        }
        else
        {
            purchaseFailed.Invoke();
        }
    }

    public void AddPurchaseSuccessfulListener(UnityAction<int> listener)
    {
        purchaseSuccessful.AddListener(listener);
    }

    public void AddPurchaseFailedListener(UnityAction listener)
    {
        purchaseFailed.AddListener(listener);
    }
}
