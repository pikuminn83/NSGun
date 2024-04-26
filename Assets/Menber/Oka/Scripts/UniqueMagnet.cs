using UnityEngine;
/// <summary>
/// スキル「ヒール」の具象クラス
/// </summary>
public class UniqueMagnet : AbstractSkill
{
    // スキル種別
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.UniqueMagnet; }
    }

    /// スキル「ヒール」の実行
    public override void Play()
    {
        Debug.Log("UniqueMagnet!");
    }
}
