using UnityEngine;
/// <summary>
/// �X�L���u�q�[���v�̋�ۃN���X
/// </summary>
public class UniqueMagnet : AbstractSkill
{
    // �X�L�����
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.UniqueMagnet; }
    }

    /// �X�L���u�q�[���v�̎��s
    public override void Play()
    {
        Debug.Log("UniqueMagnet!");
    }
}
