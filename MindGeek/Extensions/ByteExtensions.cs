namespace MindGeek.Extensions
{
    public static class ByteExtensions
    {
        static readonly List<byte> jpg = new() { 0xFF, 0xD8 };
        static readonly List<byte> bmp = new() { 0x42, 0x4D };
        static readonly List<byte> gif = new() { 0x47, 0x49, 0x46 };
        static readonly List<byte> png = new() { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
        static readonly List<byte> svg_xml_small = new() { 0x3C, 0x3F, 0x78, 0x6D, 0x6C }; // "<?xml"
        static readonly List<byte> svg_xml_capital = new() { 0x3C, 0x3F, 0x58, 0x4D, 0x4C }; // "<?XML"
        static readonly List<byte> svg_small = new() { 0x3C, 0x73, 0x76, 0x67 }; // "<svg"
        static readonly List<byte> svg_capital = new() { 0x3C, 0x53, 0x56, 0x47 }; // "<SVG"
        static readonly List<byte> intel_tiff = new() { 0x49, 0x49, 0x2A, 0x00 };
        static readonly List<byte> motorola_tiff = new() { 0x4D, 0x4D, 0x00, 0x2A };

        static readonly List<(List<byte> magic, string extension)> imageFormats = new()
        {
            (jpg, "image/jpg"),
            (bmp, "image/bmp"),
            (gif, "image/gif"),
            (png, "image/png"),
            (intel_tiff,"image/tif"),
            (motorola_tiff, "image/tif"),
            (svg_small, "image/svg+xml"),
            (svg_capital, "image/svg+xml"),
            (svg_xml_small, "image/svg+xml"),
            (svg_xml_capital, "image/svg+xml")
        };

        public static string? TryGetExtension(this byte[] array)
        {
            foreach (var (magic, extension) in imageFormats)
            {
                if (array.IsImage(magic) is false)
                {
                    continue;
                }

                if (magic != svg_xml_small && magic != svg_xml_capital)
                {
                    return extension;
                }

                // special handling for SVGs starting with XML tag
                int readCount = magic.Count; // skip XML tag
                int maxReadCount = 1024;

                do
                {
                    if (array.IsImage(svg_small, readCount) || array.IsImage(svg_capital, readCount))
                    {
                        return extension;
                    }
                    readCount++;
                }
                while (readCount < maxReadCount && readCount < array.Length - 1);

                return null;
            }
            return null;
        }

        private static bool IsImage(this byte[] array, List<byte> comparer, int offset = 0)
        {
            int arrayIndex = offset;
            foreach (byte c in comparer)
            {
                if (arrayIndex > array.Length - 1 || array[arrayIndex] != c)
                {
                    return false;
                }
                ++arrayIndex;
            }
            return true;
        }
    }
}