using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Soldier soldierDiedInvoker;
    static UnityAction<int> soldierDiedListener;

    static ShopManager purchaseInvoker;
    static UnityAction<int, int> purchaseListener;

    static MoneyCounter purchaseSuccessfulInvoker;
    static UnityAction<int> purchaseSuccessfulListener;

    static MoneyCounter purchaseFailedInvoker;
    static UnityAction purchaseFailedListener;

    static GameController upGenerationInvoker;
    static UnityAction upGenerationListener;

    public static void AddSoldierDiedInvoker(Soldier script)
    {
        soldierDiedInvoker = script;
        if (soldierDiedListener != null)
        {
            soldierDiedInvoker.AddSoldierDiedListener(soldierDiedListener);
        }
    }

    public static void AddSoldierDiedListener(UnityAction<int> handler)
    {
        soldierDiedListener = handler;
        if (soldierDiedInvoker != null)
        {
            soldierDiedInvoker.AddSoldierDiedListener(soldierDiedListener);
        }
    }

    public static void AddPurchaseInvoker(ShopManager script)
    {
        purchaseInvoker = script;
        if (purchaseListener != null)
        {
            purchaseInvoker.AddPurchaseListener(purchaseListener);
        }
    }

    public static void AddPurchaseListener(UnityAction<int, int> handler)
    {
        purchaseListener = handler;
        if (purchaseInvoker != null)
        {
            purchaseInvoker.AddPurchaseListener(purchaseListener);
        }
    }

    public static void AddPurchaseSuccessfulInvoker(MoneyCounter script)
    {
        purchaseSuccessfulInvoker = script;
        if (purchaseSuccessfulListener != null)
        {
            purchaseSuccessfulInvoker.AddPurchaseSuccessfulListener(purchaseSuccessfulListener);
        }
    }

    public static void AddPurchaseSuccessfulListener(UnityAction<int> handler)
    {
        purchaseSuccessfulListener = handler;
        if (purchaseSuccessfulInvoker != null)
        {
            purchaseSuccessfulInvoker.AddPurchaseSuccessfulListener(purchaseSuccessfulListener);
        }
    }

    public static void AddPurchaseFailedInvoker(MoneyCounter script)
    {
        purchaseFailedInvoker = script;
        if (purchaseFailedListener != null)
        {
            purchaseFailedInvoker.AddPurchaseFailedListener(purchaseFailedListener);
        }
    }

    public static void AddPurchaseFailedListener(UnityAction handler)
    {
        purchaseFailedListener = handler;
        if (purchaseFailedInvoker != null)
        {
            purchaseFailedInvoker.AddPurchaseFailedListener(purchaseFailedListener);
        }
    }

    public static void AddUpGenerationInvoker(GameController script)
    {
        upGenerationInvoker = script;
        if (upGenerationListener != null)
        {
            upGenerationInvoker.AddUpGenerationListener(upGenerationListener);
        }
    }

    public static void AddUpGenerationListener(UnityAction handler)
    {
        upGenerationListener = handler;
        if (upGenerationInvoker != null)
        {
            upGenerationInvoker.AddUpGenerationListener(upGenerationListener);
        }
    }
}
