using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class CharacterView : View
{
    /// <summary>
    /// 进行UI的各种初始化
    /// </summary>
    ///

    #region  角色属性
    [SerializeField]
    private Text LevelandNameText;
    [SerializeField]
    private Text HPText;
    [SerializeField]
    private Text MPText;
    [SerializeField]
    private Text StrengthText;
    [SerializeField]
    private Text IntelligenceText;
    [SerializeField]
    private Text AgilityText;
    [SerializeField]
    private Text EnergyText;
    [SerializeField]
    private Text StaminaText;
    [SerializeField]
    private Text AttackDamageText;
    [SerializeField]
    private Text PhysicDefenceText;
    [SerializeField]
    private Text MagicDefenceText;
    [SerializeField]
    private Text CritValueText;
    [SerializeField]
    private Text MissValueText;
    [SerializeField]
    private Text ExpText;
    #endregion

    public void InitandUpdate(Character character)
    {
        LevelandNameText.text = string.Format("LV.{0} {1}", character.Level, character.GetModelName());
        HPText.text = string.Format("HP: {0}", character.HP);
        MPText.text = string.Format("MP: {0}", character.MP);
        StrengthText.text = string.Format("力量：{0}", character.Strength);
        IntelligenceText.text = string.Format("智力: {0}", character.Intelligence);
        AgilityText.text = string.Format("敏捷: {0}", character.Agility);
        EnergyText.text = string.Format("体力: {0}", character.Energy);
        StaminaText.text = string.Format("耐力: {0}", character.Stamina);
        AttackDamageText.text = string.Format("攻击力: {0}", character.AttackDamage);
        PhysicDefenceText.text = string.Format("物理防御: {0}", character.PhysicDenfence);
        MagicDefenceText.text = string.Format("魔法防御: {0}", character.MagicDenfence);
        CritValueText.text = string.Format("暴击: {0}", character.CriValue);
        MissValueText.text = string.Format("闪避: {0}", character.MissValue);
        ExpText.text = string.Format("{0}/{1}", character.Exp, character.LevelExp);

    }
}
