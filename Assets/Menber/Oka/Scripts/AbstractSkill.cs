/// <summary>
/// �X�L���̒��ۃN���X
/// </summary>
abstract public class AbstractSkill
{
    // �X�L����ʂ̒��ۃv���p�e�B
    public abstract SkillFactory.SkillKind SkillKind { get; }

    // �X�L�����s�̒��ۃ��\�b�h
    public abstract void Play();
}
