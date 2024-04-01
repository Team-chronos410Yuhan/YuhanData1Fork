using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{

    //�뷱�� ������ ���� ����

    /// <summary> ��ȭ Ȯ�� ��� (������) </summary>
    double upgradePercentChange = 0.93;
    /// <summary> ��ȭ ��� ��� (������) </summary>
    double upgradePriceChange = 1.5;
    /// <summary> �Ǹ� ��� ��� (������) </summary>
    double sellChange = 1.8;

    //���� ����

    /// <summary> ������ </summary>
    int playerMoney = 0;
    /// <summary> ���� ���� ���� </summary>
    int level = 0;

    /// <summary> �̹� ��ȭ�� �Ҹ�� ��� </summary>
    double upgradePrice = 0;
    /// <summary> ��ȭ �Ҹ� ����� int������ ��ȯ�� �� </summary>
    int iupgradePrice = 0;

    /// <summary> ��ȭ�� ������ Ȯ�� </summary>
    double upgradePercent = 0;
    /// <summary> ��ȭ ���� Ȯ���� int������ ��ȯ�� �� </summary>
    int iupgradePercent = 0;

    /// <summary> �ǸŽ� �޴� �ݾ� </summary>
    double sellPrice = 0;
    /// <summary> �Ǹ� �ݾ��� int������ ��ȯ�� �� </summary>
    int isellPrice = 0;


    public Text PlayerMoneyText, LevelText, UpgradePercentText, UpgradeBtnText, SellBtnText;    //ȭ�鿡 ���̴� UI�� ������ �� �ְ� ������


    /// <summary>
    /// ���� ��ȭ�� 1������ �ʱ�ȭ �ϴ� �Լ�
    /// </summary>
    void ResetWeapon()
    {
        level = 1;
        upgradePrice = 10;
        upgradePercent = 100;
        sellPrice = 100;
    }

    /// <summary>
    /// ��ȭ ��ư�� Ŭ�� �� ����Ǵ� �Լ�
    /// </summary>
    public void OnClickUpgrade()
    {
        if (playerMoney >= iupgradePrice)   //�������� ������� üũ
        {
            playerMoney = playerMoney - iupgradePrice;  //��ȭ ��� ����
            if (UnityEngine.Random.Range(0, 100) <= iupgradePercent)        //��ȭ ���� Ȯ������ Random (0~100) ���� ���ų� ���� ��� ��ȭ ����
            {
                //!!!��ȭ ���� �α� �ۼ�
                upgradePercent = upgradePercent * upgradePercentChange;
                upgradePrice = upgradePrice * upgradePriceChange;
                sellPrice = sellPrice * sellChange;
                level++;

            }
            else    //��ȭ ����
            {
                //!!!��ȭ ���� �α� �ۼ�
                ResetWeapon();
            }
        }
        else    //�������� ��ȭ��뺸�� ���� ���
        {
            //!!!������ ���� �α� �ۼ�
        }
    }

    /// <summary>
    /// �Ǹ� ��ư�� Ŭ�� �� ����Ǵ� �Լ�
    /// </summary>
    public void OnClickSell()       //�� �Ǹ� ��ư Ŭ��
    {
        //!!!�� �Ǹ� �α� �ۼ�
        playerMoney = playerMoney + isellPrice;
        ResetWeapon();
    }


    /// <summary>
    /// ���� ���� ��ư�� Ŭ�� �� ����Ǵ� �Լ�
    /// </summary>
    public void OnClickExit()       //���� ���� ��ư Ŭ��
    {
        //!!!���� ���� �α� �ۼ�
        //!!!csv ���� ����?
        Debug.Log("Exit");
        Application.Quit();         //���� �����
    }


    void Start()
    {
        //!!!csv���� �����ϴ� ���� �־�ߵ�(�� �� ����)
        FileStream LogFile = File.Create("Log_" + DateTime.Now + ".csv");
        LogFile.WriteLine("�ð�,�ൿ,���,������,����,��ȭ���,����Ȯ��,����");
        LogFile.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", DateTime.Now, , );
        //!!!���� ���� �α�
        playerMoney = 1000;
        ResetWeapon();
    }

    void Update()
    {
        //double �������� int�� ��ȯ�� ����
        iupgradePercent = Convert.ToInt32(upgradePercent);
        iupgradePrice = Convert.ToInt32(upgradePrice);
        isellPrice = Convert.ToInt32(sellPrice);

        //UI�� ��Ÿ�� �ؽ�Ʈ
        PlayerMoneyText.text = "������: " + playerMoney.ToString() + "G";
        LevelText.text = "Lv." + level.ToString();
        UpgradePercentText.text = iupgradePercent.ToString() + "%";
        UpgradeBtnText.text = "�ٰ�ȭ��\n" + iupgradePrice.ToString() + "G";
        SellBtnText.text = "�Ǹ�\n" + isellPrice.ToString() + "G";
    }
}
