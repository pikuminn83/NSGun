using System;
using System.Linq;

/// <summary>
/// Skillを管理し、作ってくれるFactoryクラス
/// </summary>
public class SkillFactory 
{
    // スキル一覧
    static readonly AbstractSkill[] skills = {
        new MagLiquid(),
        new RailGun(),
        new UniqueMagnet()
    };

    /// スキルのenum
    public enum SkillKind
    {
        MagLiquid,
        RailGun,
        UniqueMagnet
    }

    // SkillKindを引数に、それに応じたスキルを返す
    public AbstractSkill Create(SkillKind skillKind) 
    {
        return skills.SingleOrDefault(skill => skill.SkillKind == skillKind);
    }

}
