namespace Sample.Models;

public class Global
{
    public static readonly string LoginPath = "/util/login.aspx";
    public static readonly string AppRelativeLoginPath = string.Format("~{0}", LoginPath);

    public const string dynamicsettings = "dynamicsettings";

    [GroupDefinitions]
    public static class GroupNames
    {
        [Display(Name = "Titles", Order = 0)]
        public const string Titles = "Titles";

        [Display(Name = "Default", Order = 2)]
        public const string Default = "Default";

        [Display(Name = "Meta data", Order = 3)]
        public const string MetaData = "Metadata";

        [Display(Name = "Site Settings", Order = 6)]
        public const string SiteSettings = "SiteSettings";

        [Display(Name = "Page Settings", Order = 9)]
        public const string PageSettings = "PageSettings";

        [Display(Name = "Content Pages", Order = 10)]
        public const string ContentPages = "Content Pages";

        [Display(Name = "Commerce Pages", Order = 11)]
        public const string CommercePages = "Commerce Pages";

        [Display(Name = "Content Blocks", Order = 12)]
        public const string ContentBlocks = "Content Blocks";

        [Display(Name = "Commerce Blocks", Order = 13)]
        public const string CommerceBlocks = "Commerce Blocks";

        [Display(Name = "Shared Blocks", Order = 14)]
        public const string SharedBlocks = "Shared Blocks";

        [Display(Name = "Setting Blocks", Order = 15)]
        public const string SettingBlocks = "Setting Blocks";

        [Display(Name = "Utility", Order = 16)]
        public const string Utility = "Utility";

        [Display(Name = "Labels", Order = 17)]
        public const string Labels = "Labels";

        [Display(Name = "Block styling", Order = 18)]
        public const string BlockStyling = "BlockStyling";

        [Display(Name = "Base Page", Order = -1)]
        public const string Base = "Base";
    }

    public static class ContentAreaTags
    {
        public const string FullWidth = "basis-full";
        public const string OneSixthWidth = "basis-1/6";
        public const string HalfWidth = "basis-1/2";
        public const string OneThirdWidth = "basis-1/3";
        public const string TwoThirdsWidth = "basis-2/3";
        public const string FiveSixthWidth = "basis-5/6";
        public const string NoRenderer = "norenderer";
    }

    public static class ContentAreaWidths
    {
        public const int FullWidth = 12;
        public const int TwoThirdsWidth = 8;
        public const int HalfWidth = 6;
        public const int OneThirdWidth = 4;
    }

    public static Dictionary<string, int> ContentAreaTagWidths = new Dictionary<string, int>
    {
        { ContentAreaTags.FullWidth, ContentAreaWidths.FullWidth },
        { ContentAreaTags.TwoThirdsWidth, ContentAreaWidths.TwoThirdsWidth },
        { ContentAreaTags.HalfWidth, ContentAreaWidths.HalfWidth },
        { ContentAreaTags.OneThirdWidth, ContentAreaWidths.OneThirdWidth }
    };

    public static class SiteUIHints
    {
        public const string Contact = "contact";
        public const string Strings = "StringList";
        public const string StringsCollection = "StringsCollection";
    }

    public const string StaticGraphicsFolderPath = "~/Static/gfx/";
}
