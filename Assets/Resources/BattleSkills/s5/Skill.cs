using System.Collections.Generic;
using CGTool;
using Controller;
using DG.Tweening;
using GameData;
using Prefeb;
using Reference;
using UnityEngine;

namespace Resources.BattleSkills.s5
{
    public class Skill:SkillSetting.SkillBase,SkillSetting.ISkill
    {
        public override void Init(PlayerUnit playerUnit, SkillSetting.SkillInfo skillInfo)
        {
            InitBase(playerUnit, skillInfo);
        }
        
        public override void CastSkill()
        {

        }
        
        public override void OnCDComplate()
        {
            
        }

        public override void LevelUp()
        {
            Level++;
            int percent = (int) SkillInfo.Params["Percent"] + Level * (int) SkillInfo.Params["PercentRatePerLevel"];
            int diff = percent - (int) Params["Percent"];
            Params["Percent"] = percent;
            GlobalReference.BattleData.PlayerUnit.Attr.DEF_Addon_Rate += diff;

        }
        public override Dictionary<string, object> GetLevelParams(int level)
        {
            Dictionary<string,object> param = new Dictionary<string, object>(SkillInfo.Params);
            param["Percent"] = (int) SkillInfo.Params["Percent"] + level * (int) SkillInfo.Params["PercentRatePerLevel"];
            return param;
        }
    }    
}

