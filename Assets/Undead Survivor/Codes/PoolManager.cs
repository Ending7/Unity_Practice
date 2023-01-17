using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ��������� ������ ������ �ʿ��ϴ�.
    public GameObject[] prefabs;
    // Ǯ ����� �ϴ� ����Ʈ���� �ʿ��ϴ�.
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        // ������ Ǯ�� ��� (��Ȱ��ȭ ��) �ִ� ���� ������Ʈ ����     

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // �߰��ϸ� select������ �Ҵ��Ѵ�.
                select = item;
                select.SetActive(true);
                break;

            }

        }
        // �� ã������?

        if (!select)
        {         // ���Ӱ� �����ؼ� select�� �Ҵ��Ѵ�.
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}

