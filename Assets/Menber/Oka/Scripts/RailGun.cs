using UnityEngine;
/// <summary>
/// �X�L���u�q�[���v�̋�ۃN���X
/// </summary>
public class RailGun : AbstractSkill
{
    // �X�L�����
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.RailGun; }
    }

    /// �X�L���u�q�[���v�̎��s
    public override void Play()
    {
        Debug.Log("RailGun!");
    }
}
