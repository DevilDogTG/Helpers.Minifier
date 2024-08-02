namespace DMNSN.Helpers.Minifier
{
    /// <summary>
    /// Config object for the XML minifier.
    /// </summary>
    public class XmlMinifierSetting
    {
        public bool RemoveEmptyLines { get; set; }
        public bool RemoveWhitespaceBetweenElements { get; set; }
        public bool CloseEmptyTags { get; set; }
        public bool RemoveComments { get; set; }

        public static XmlMinifierSetting Aggressive
        {
            get
            {
                return new XmlMinifierSetting
                {
                    RemoveEmptyLines = true,
                    RemoveWhitespaceBetweenElements = true,
                    CloseEmptyTags = true,
                    RemoveComments = true
                };
            }
        }

        public static XmlMinifierSetting NoMinification
        {
            get
            {
                return new XmlMinifierSetting
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
