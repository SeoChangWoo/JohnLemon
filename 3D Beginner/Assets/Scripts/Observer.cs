using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    private bool isPlayerInRange;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other) // �÷��̾ �������� �ü������� �������� isPlayerInRange�� ���� true�� ������ִ� �޼���
    {
        if(other.transform == player)
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other) // �÷��̾ �������� �ü������� ������� isPlayerInRagne�� ���� false�� ������ִ� �޼���
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if(isPlayerInRange == true) // isPlayerInRange�� ���� true�� ���� ���ǹ��� ����
        {
            Vector3 direction = player.position - transform.position + Vector3.up; // ����
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
