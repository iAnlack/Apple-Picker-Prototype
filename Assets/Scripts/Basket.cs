using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    private void Start()
    {
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // �������� ��������� Text ����� �������� �������
        scoreGT = scoreGO.GetComponent<Text>();
        // ���������� ��������� ����� ����� ������ 0
        scoreGT.text = "0";
    }
    private void Update()
    {
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition;

        // ���������� Z ������ ����������, ��� ������ � ��������� ������������
        // ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z;

        // ������������� ����� �� ��������� ��������� ������ � ���������
        // ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // ����������� ������� ����� ��� X � ���������� X ��������� ����
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������, �������� � ��� �������
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // ������������� ����� � scoreGT � ����� �����
            int score = int.Parse(scoreGT.text);
            // �������� ���� �� ��������� ������
            score += 100;
            // ������������� ����� ����� ������� � ������ � ������� � �� �����
            scoreGT.text = score.ToString();

            // ��������� ������ ����������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
