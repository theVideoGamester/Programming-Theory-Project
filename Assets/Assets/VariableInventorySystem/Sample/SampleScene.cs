﻿using System.Collections;
using UnityEngine;
using VariableInventorySystem;
using VariableInventorySystem.Sample;

public class SampleScene : MonoBehaviour
{
    [SerializeField] StandardCore standardCore;
    [SerializeField] StandardStashView standardStashView;

    void Awake()
    {
        standardCore.Initialize();
        standardCore.AddInventoryView(standardStashView);

        StartCoroutine(InsertCoroutine());
    }

    IEnumerator InsertCoroutine()
    {
        var stashData = new StandardStashViewData(7, 32);

        var caseItem = new CaseCellData(0);
        stashData.InsertInventoryItem(stashData.GetInsertableId(caseItem).Value, caseItem);
        standardStashView.Apply(stashData);

        for (var i = 0; i < 2; i++)
        {
            var item = new ItemCellData(i % 6);
            stashData.InsertInventoryItem(stashData.GetInsertableId(item).Value, item);
            standardStashView.Apply(stashData);

            yield return null;
        }
        gameObject.SetActive(false);
    }
}
