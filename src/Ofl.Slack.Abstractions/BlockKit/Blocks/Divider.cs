namespace Ofl.Slack.BlockKit.Blocks
{
    public class Divider : Block
    {
        #region Constructor

        public Divider(string? blockId = null) : base(blockId)
        { }

        #endregion

        public override string Type => "divider";
    }
}
