namespace DMNSN.Helpers.Minifier
{
    /// <summary>
    /// Config object for the XML minifier.
    /// </summary>
    public class XMLMinifierSetting
    {
        public bool RemoveEmptyLines { get; set; }
        public bool RemoveWhitespaceBetweenElements { get; set; }
        public bool CloseEmptyTags { get; set; }
        public bool RemoveComments { get; set; }

        public static XMLMinifierSetting Aggressive
        {
            get
            {
                return new XMLMinifierSetting
                {
                    RemoveEmptyLines = true,
                    RemoveWhitespaceBetweenElements = true,
                    CloseEmptyTags = true,
                    RemoveComments = true
                };
            }
        }

        public static XMLMinifierSetting NoMinification
        {
            get
            {
                return new XMLMinifierSetting
                {
                    RemoveEmptyLines = false,
                    RemoveWhitespaceBetweenElements = false,
                    CloseEmptyTags = false,
                    RemoveComments = false
                };
            }
        }
    }
}
