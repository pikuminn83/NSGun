using UnityEngine;
/// <summary>
/// �X�L���u���C�g�j���O�v�̋�ۃN���X
/// </summary>
public class MagLiquid : AbstractSkill
{
    // �X�L�����
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.MagLiquid; }
    }

    // �X�L���u���C�g�j���O�v�̎��s
    public override void Play()
    {
        Debug.Log("MagLiquid!");
    }
}
