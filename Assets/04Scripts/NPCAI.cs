using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AI_State
{
    Idle,       // ���
    Roaming,    // �ֺ� ��ȸ
    ReturnHome, // ���� �ڸ��� ����
}

public class NPCAI : MonoBehaviour
{

    private NavMeshAgent navAgent;

    private Vector2 homePos;
    private Vector2 movePos;


    private IEnumerator Roaming()
    {
        yield return null;

        while (true)
        {
            movePos.x = Random.Range(-5f, 5f);
            movePos.y = Random.RandomRange(-5f, 5f);
            yield return new WaitForSeconds(Random.Range(4, 6));
        }
    }
}
