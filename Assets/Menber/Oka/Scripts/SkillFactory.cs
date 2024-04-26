using System;
using System.Linq;

/// <summary>
/// Skill���Ǘ����A����Ă����Factory�N���X
/// </summary>
public class SkillFactory 
{
    // �X�L���ꗗ
    static readonly AbstractSkill[] skills = {
        new MagLiquid(),
        new RailGun(),
        new UniqueMagnet()
    };

    /// �X�L����enum
    public enum SkillKind
    {
        MagLiquid,
        RailGun,
        UniqueMagnet
    }

    // SkillKind�������ɁA����ɉ������X�L����Ԃ�
    public AbstractSkill Create(SkillKind skillKind) 
    {
        return skills.SingleOrDefault(skill => skill.SkillKind == skillKind);
    }

}
