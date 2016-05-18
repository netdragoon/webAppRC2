namespace Canducci.Helpers
{
    public enum ButtonSize
    {
        [EnumDescription()]
        Default,
        [EnumDescription("btn-sm")]
        Small,
        [EnumDescription("btn-xs")]
        ExtraSmall,
        [EnumDescription("btn-lg")]
        Large,
        [EnumDescription("btn-block")]
        DefaultAndBlock,
        [EnumDescription("btn-block btn-sm")]
        SmallAndBlock,
        [EnumDescription("btn-block btn-xs")]
        ExtraSmallAndBlock,
        [EnumDescription("btn-block btn-lg")]
        LargeAndBlock
    }
}
