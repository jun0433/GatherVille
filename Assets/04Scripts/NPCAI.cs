using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AI_State
{
    Idle,       // 대기
    Roaming,    // 주변 배회
    ReturnHome, // 원래 자리로 복귀
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
