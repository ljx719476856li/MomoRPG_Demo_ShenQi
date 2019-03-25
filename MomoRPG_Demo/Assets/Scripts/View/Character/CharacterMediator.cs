using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CharacterMediator : EventMediator
{
    private readonly object input;

    [Inject]
    public CharacterView characterView { get; set; }

    private List<BaseModel> baseModelList;
    private Character character;

    public override void OnRegister()
    {
        dispatcher.AddListener(CharacterMediatorEvent.GetCharacterData, OnReceiveModelList);
        dispatcher.Dispatch(CharacterStatusCommandEvent.UpdateCharacterStatus);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(CharacterMediatorEvent.GetCharacterData, OnReceiveModelList);
    }

    public void OnReceiveModelList(IEvent evt)
    {
        baseModelList = evt.data as List<BaseModel>;
        character = (Character)baseModelList[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetExp(character);
            characterView.InitandUpdate(character);
        }
        if (character.Exp >= character.LevelExp)
        {
            CharacterLevelUP(character);
            characterView.InitandUpdate(character);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            SaveCharacterInfo(character);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L");
            LoadCharacterInfo(character);
            characterView.InitandUpdate(character);
        }

    }

    //获取经验
    public void GetExp(Character character)
    {
        //测试版
        character.Exp += 100;
    }
    
#region 角色升级
    public void CharacterLevelUP(Character character)
    {
        int OverExp;
        if (character.Exp - character.LevelExp >= 0)
        {
            OverExp = character.Exp - character.LevelExp;
            character.Exp = OverExp;
        }
        character.Level++;
        character.Strength += 5;
        character.Agility += 5;
        character.Intelligence += 5;
        character.Stamina += 5;
        character.Energy += 5;
        if (character.Level <= 10)
        {
            character.LevelExp = ((character.Level - 1) * 40 + 120) * 10 + character.Level * 50;
        }
        else if (character.Level <= 20)
        {
            character.LevelExp = ((character.Level - 1) * 40 + 120) * 10 + character.Level * 250;
        }
        else if (character.Level <= 49)
        {
            character.LevelExp = (int)Mathf.Pow(character.Level * ((character.Level - 1) * 40) / 4, (float)1.3);
        }
        else
        {
            character.LevelExp = (int)Mathf.Pow(character.Level * ((character.Level - 1) * 40) / 4, (float)1.3);
        }
        CurrentProfession(character);
    }

    //加点影响各属性的公式
    public void CurrentProfession(Character character)
    {
        switch (character.Profession)
        {
            case EProfessionType.eArcher:
                character.HP = (int)(character.Energy * 3.2);
                character.PhysicDenfence = (int)(character.Strength * 2 + character.Stamina * 1.6);
                character.MagicDenfence = (int)(character.Intelligence * 2);
                character.AttackDamage = character.Agility * 3;
                character.MissValue = (int)(character.Agility * 0.55);
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
    #endregion

    //保存加载角色信息
    private void SaveCharacterInfo(Character character)
    {
        StringBuilder sb = new StringBuilder();
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("Lv", character.Level.ToString());
        foreach(string key in dic.Keys)
        {
            string value;
            dic.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        }
        File.WriteAllText("Assets\\Resources\\characterInfo.txt", sb.ToString());
    }

    private void LoadCharacterInfo(Character character)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        if (File.Exists("Assets\\Resources\\characterInfo.txt") == false) return;
        string[] lines = File.ReadAllLines("Assets\\Resources\\characterInfo.txt");
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyValue = line.Split(',');
            character.Level = int.Parse(keyValue[1]);
        }
    }
}
