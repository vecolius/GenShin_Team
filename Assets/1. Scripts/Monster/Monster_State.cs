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

    public Battle_Type battleType;      //monster타입
    public Battle_Type attackType;      //player 공격타입
    float trueDamage;                 //monster가 실제로 받는 damage

    public int maxHp;
    public int hp;
    public int atk;
    public int exp;
    public float moveSpeed;             //이동속도
    public float attackRange;           //사정거리
    public float attackSpeed;           //공격속도
    public bool isLive = true;

    public float attackState;           //공격모션

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
    //Player_Controller_L찾기
    void FindPlayer()
    {
        if (playerState == null)
            playerState = GameObject.Find("Player").GetComponent<Player_Controller_L>();
        else
            return;
    }

    //monster가 받는 대미지 연산
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
            // 기본 공격  - 타입 X
            case "Weapon":
                collision.GetComponent<Sword_Trigger>().pState.IsAttack = false;
                damage = playerState.damage + playerState.Str;
                break;
            // 기본 공격  - 타입 X
            case "MageAttack":
                damage = playerState.damage;
                break;
            // 발사형  - 타입 : 가위 타입
            case "WarriorSkill1":
                attackType = Battle_Type.scissors;
                damage = playerState.damage + playerState.Str;
                break;
            // 폭발형  - 타입 : 주먹 타입
            case "WarriorSkill2":
                attackType = Battle_Type.rock;
                damage = playerState.damage + playerState.Str;
                break;
            // 폭발형  - 타입 : 주먹 타입
            case "MageSkill1":
                attackType = Battle_Type.rock;
                damage = playerState.damage + playerState.Int;
                break;
            // 설치형  - 타입  : 보자기 타입
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
