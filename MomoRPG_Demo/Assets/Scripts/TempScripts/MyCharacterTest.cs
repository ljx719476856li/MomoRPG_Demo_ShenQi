using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCharacterTest : MonoBehaviour
{
    private Character m_character;
    public Text text;
    public Text text1;
    private int OverExp = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_character = (Character)DataSerivice.Instance.ModelDataList[0];
        UpdataData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CharacterLevelUP(m_character);
        }
    }



    public void ShowCharacterInfo()
    {

    }

    //升级
    public void CharacterLevelUP(Character character)
    {
        m_character.Exp += m_character.Level * 100;

        if (character.Exp >= character.LevelExp)
        {
            OverExp = character.Exp - character.LevelExp;
            character.Level++;
            character.Strength += 5;
            character.Agility += 5;
            character.Intelligence += 5;
            character.Stamina += 5;
            character.Energy += 5;
            character.Exp = OverExp;
            if(character.Level <= 10)
            {
                character.LevelExp = ((character.Level - 1) * 40 + 120) * 10 + character.Level * 50;
            }
            else if (character.Level <= 20)
            {
                character.LevelExp = ((character.Level - 1) * 40 + 120) * 10 + character.Level * 250;
            }else if(character.Level <= 49)
            {
                character.LevelExp = (int)Mathf.Pow(character.Level * ((character.Level - 1) * 40) / 4, (float)1.3);
            }
            else
            {
                character.LevelExp = (int)Mathf.Pow(character.Level * ((character.Level - 1) * 40) / 4, (float)1.3);
            }
            CurrentProfession(m_character);
            UpdataData();
        }
        UpdataData();
    }

    //判断当前角色职业改变攻击力等
    public void CurrentProfession(Character character)
    {
        switch (character.Profession)
        {
            case EProfessionType.eArcher:
                character.HP = (int)(character.Energy * 3.2);
                character.PhysicDenfence = (int)(character.Strength * 2 + character.Stamina * 1.6);
                character.MagicDenfence = (int)(character.Intelligence * 2);
                character.AttackDamage = character.Agility * 3;
                character.MissValue =(int)(character.Agility * 0.55);
                character.CriValue = (int)(character.Agility * 0.55);
                //character.MissRate 
                //character.CritRate
                break;
            case EProfessionType.eMage:
                character.HP = (int)(character.Energy * 4.2);
                character.PhysicDenfence = (int)(character.Strength * 1.9 + character.Stamina * 2.2);
                character.MagicDenfence = (int)(character.Intelligence * 2.2);
                character.AttackDamage = character.Intelligence * 1;
                character.MissValue = (int)(character.Agility * 0.66);
                character.CriValue = (int)(character.Intelligence * 0.55);
                break;
            case EProfessionType.eWarrior:
                character.HP = (int)(character.Energy * 5);
                character.PhysicDenfence = (int)(character.Stamina * 2.2);
                character.MagicDenfence = (int)(character.Agility * 1.9);
                character.AttackDamage = character.Strength * 3;
                character.MissValue = (int)(character.Agility * 0.66);
                character.CriValue = (int)(character.Agility * 0.66);
                break;
            default:
                break;
        }
    }

    public void UpdataData()
    {
        text.text = "等级: " + m_character.Level.ToString() + "\n"
            + "HP: " + m_character.HP.ToString() + "\n"
            + "MP: " + m_character.MP.ToString() + "\n"
            + "力量: " + m_character.Strength.ToString() + "\n"
            + "智力: " + m_character.Intelligence.ToString() + "\n"
            + "敏捷: " + m_character.Agility.ToString() + "\n"
            + "体力: " + m_character.Energy.ToString() + "\n"
            + "耐力: " + m_character.Stamina.ToString() + "\n";
        text1.text = "攻击力: " + m_character.AttackDamage.ToString() + "\n"
            + " 物防: " + m_character.PhysicDenfence.ToString() + "\n"
            + " 法防: " + m_character.MagicDenfence.ToString() + "\n"
        +" 经验: " + m_character.Exp.ToString() +"/" + m_character.LevelExp+ "\n";
    }
}
