using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_State : MonoBehaviour, IHitable
{
    public enum Battle_Type
    {
        rock,
        scissors,
        paper
    }

    public Battle_Type battleType;      //monsterŸ��
    public Battle_Type attackType;      //player ����Ÿ��
    float trueDamage;                 //monster�� ������ �޴� damage

    public int maxHp;
    public int hp;
    public int atk;
    public int exp;
    public float moveSpeed;             //�̵��ӵ�
    public float attackRange;           //�����Ÿ�
    public float attackSpeed;           //���ݼӵ�
    public bool isLive = true;

    public float attackState;           //���ݸ��

    public GameObject bgHpbar;
    public Image Hpbar;

    public Player_Controller_L playerState;


    public virtual void GetDamage(int _damage)
    {

        DamageControl(_damage);
        hp -= (int)trueDamage;
        if (hp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        isLive = false;
        Debug.Log(gameObject.name + "DIE");
    }
    //Player_Controller_Lã��
    void FindPlayer()
    {
        if (playerState == null)
            playerState = GameObject.Find("Player").GetComponent<Player_Controller_L>();
        else
            return;
    }

    //monster�� �޴� ����� ����
    void DamageControl(int _damage)
    {
        if (battleType == attackType)
        {
            trueDamage = _damage;
        }
        else if (battleType == Battle_Type.rock)
        {
            switch (attackType)
            {
                case Battle_Type.scissors:
                    trueDamage = _damage * 0.5f;
                    break;
                case Battle_Type.paper:
                    trueDamage = _damage * 1.5f;
                    break;
            }
        }
        else if (battleType == Battle_Type.scissors)
        {
            switch (attackType)
            {
                case Battle_Type.rock:
                    trueDamage = _damage * 1.5f;
                    break;
                case Battle_Type.paper:
                    trueDamage = _damage * 0.5f;
                    break;
            }
        }
        else if (battleType == Battle_Type.paper)
        {
            switch (attackType)
            {
                case Battle_Type.scissors:
                    trueDamage = _damage * 1.5f;
                    break;
                case Battle_Type.rock:
                    trueDamage = _damage * 0.5f;
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindPlayer();
        int damage = 0;
        switch (collision.tag)
        {
            // �⺻ ����  - Ÿ�� X
            case "Weapon":
                collision.GetComponent<Sword_Trigger>().pState.IsAttack = false;
                damage = playerState.damage + playerState.Str;
                break;
            // �⺻ ����  - Ÿ�� X
            case "MageAttack":
                damage = playerState.damage;
                break;
            // �߻���  - Ÿ�� : ���� Ÿ��
            case "WarriorSkill1":
                attackType = Battle_Type.scissors;
                damage = playerState.damage + playerState.Str;
                break;
            // ������  - Ÿ�� : �ָ� Ÿ��
            case "WarriorSkill2":
                attackType = Battle_Type.rock;
                damage = playerState.damage + playerState.Str;
                break;
            // ������  - Ÿ�� : �ָ� Ÿ��
            case "MageSkill1":
                attackType = Battle_Type.rock;
                damage = playerState.damage + playerState.Int;
                break;
            // ��ġ��  - Ÿ��  : ���ڱ� Ÿ��
            case "MageSkill2":
                attackType = Battle_Type.paper;
                damage = playerState.damage + playerState.Int;
                break;
        }
        Hit(damage);
    }

    public void Hit(float damage)
    {
        GetDamage((int)damage);
    }
}
