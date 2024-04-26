using UnityEngine;
/// <summary>
/// スキル「ライトニング」の具象クラス
/// </summary>
public class MagLiquid : AbstractSkill
{
    // スキル種別
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.MagLiquid; }
    }

    // スキル「ライトニング」の実行
    public override void Play()
    {
        Debug.Log("MagLiquid!");
    }
}
