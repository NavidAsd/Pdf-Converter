
using System;
using System.IO;

namespace Common
{
    public enum FilesFormat
    {
        pdf,
        xlsx,
        ppt,
        jpg,
        png,
        bmp,
        tiff,
        gif,
        docx,
        rtf,
        zip,
        rar,
        none
    }

    public static class Formating
    {
        public static readonly string StandardFaqSchemaFileName = "PdfToConverter-FaqSchemaGenerator-";
        public static readonly string StandardHowToSchemaFileName = "PdfToConverter-HowToSchemaGenerator-";
        public static readonly string StandardVideoSchemaFileName = "PdfToConverter-VideoSchemaGenerator-";
        public static readonly string[] VideosFormat = new string[] { "mp4", "webm", "ogg", "3gp" };
        public static readonly string[] AllImagesFormat = new string[]{ ".jpg",
        ".png",
        ".bmp",
        ".tiff",
        ".gif",
        ".jfif",
        ".jpeg",
        ".svg",
        ".ico",
        ".avif"};
        public static string FixFileNameFormat(string FileName)
        {
            FileName = FileName.Replace(":", "-").Replace("/", "-").Replace(@"\", "-").Replace("|", "-");
            FileName = FileName.Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "");
            return FileName;
        }
        public static string FixFilterFormat(string Input)
        {
            string[] filter = new string[] { "/", "\\", "*", "?", ">", "<", "|", " ", "@", "$", "'", "!", "=", "+", "==", "Drop", "drop", "%", "^", "&" };
            if (!string.IsNullOrWhiteSpace(Input))
            {
                for (int i = 0; i < filter.Length; i++)
                {
                    Input = Input.Replace(filter[i], "");
                }
            }
            return Input;
        }
        public static bool FileFormatValidation(string FileName, string Format)
        {
            if (!Path.GetExtension(FileName).ToLower().Equals(Format))
                return true;
            else return false;
        }
        public static bool FileFormatsValidation(string FileName, string[] Formats)
        {
            foreach (var item in Formats)
            {
                if (Path.GetExtension(FileName).ToLower().Equals(item))
                    return false;
            }
            return true;
        }
        public static bool ImageFileFormatValidation(string FileName)
        {
            bool result = true;
            for (int i = 0; i < AllImagesFormat.Length; i++)
            {
                if (Path.GetExtension(FileName).ToLower().Equals(AllImagesFormat[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public static bool FileFormatingValidation(string FileName, string[] Formats)
        {
            bool result = false;
            for (int i = 0; i < Formats.Length; i++)
            {
                if (!Path.GetExtension(FileName).ToLower().Equals(Formats[i]))
                {
                    result = true;
                    break;
                }
                else result = false;
            }
            return result;
        }
        public static string ReturnFileName(FilesFormat FileFormat, string ModifiedTo)
        {
            return FixFileNameFormat($"PdfToConverter.com-ModifiedTo{ModifiedTo}_{System.DateTime.Now.ToString().Replace(" ", "_") + "-" + System.DateTime.Now.Millisecond.ToString().Replace(" ", "_")}{ReturnFormat(FileFormat)}");
        }
        public static string ReturnFileNameWithoutModified(FilesFormat FileFormat, string FileName)
        {
            return FixFileNameFormat($"PdfToConverter.com-{FileName}_{System.DateTime.Now.ToString().Replace(" ", "_") + "-" + System.DateTime.Now.Millisecond.ToString().Replace(" ", "_")}{ReturnFormat(FileFormat)}");
        }
        public static string ReturnInputFileName(string FileName)
        {
            return FixFileNameFormat($"{System.DateTime.Now.ToString().Replace(" ", "_") + "-" + System.DateTime.Now.Millisecond.ToString()}_{FileName}");
        }
        public static string ReturnFileNameWithoutDate(FilesFormat FileFormat, string ModifiedTo, int uniqenum)
        {
            return FixFileNameFormat($"PdfToConverter.com-ModifiedTo{ModifiedTo}_{uniqenum}{ReturnFormat(FileFormat)}");
        }
        public static string ReturnZipFileName(FilesFormat FileFormat, string ModifiedTo)
        {
            return FixFileNameFormat($"PdfToConverter.com-AllPages-ModifiedTo{ModifiedTo}_{System.DateTime.Now.ToString().Replace(" ", "_") + "-" + System.DateTime.Now.Millisecond.ToString().Replace(" ", "_")}{ReturnFormat(FileFormat)}");
        }
        public static string ReturnQrName()
        {
            return FixFileNameFormat($"QrCode_{System.DateTime.Now.ToString().Replace(" ", "_") + "-" + System.DateTime.Now.Millisecond.ToString().Replace(" ", "_")}");
        }
        public static string FixBlogPostTags(string Context)
        {
            string tag = "h5";
            return Context.Replace("h1", tag).Replace("h2", tag).Replace("h3", tag).Replace("h4", tag).Replace("<strong", "<h5");
        }
        public static string FixBlogPostTagsShortTime(string Context)
        {
            string tag = "h6";
            return Context.Replace("h1", tag).Replace("h2", tag).Replace("h3", tag).Replace("h4", tag).Replace("<strong", "<h6").Replace("<b", "<p").Replace("<a href=\"https://pdftoconverter.com/html-to-pdf/\" targe...=\"\" <=\"\" p=\"\">", "");
        }
        private static string ReturnFormat(FilesFormat Format)
        {
            switch (Format)
            {
                case FilesFormat.jpg:
                    return ".jpg";
                case FilesFormat.png:
                    return ".png";
                case FilesFormat.gif:
                    return ".gif";
                case FilesFormat.tiff:
                    return ".tiff";
                case FilesFormat.bmp:
                    return ".bmp";
                case FilesFormat.pdf:
                    return ".pdf";
                case FilesFormat.docx:
                    return ".docx";
                case FilesFormat.rtf:
                    return ".rtf";
                case FilesFormat.ppt:
                    return ".ppt";
                case FilesFormat.xlsx:
                    return ".xlsx";
                case FilesFormat.zip:
                    return ".zip";
                case FilesFormat.rar:
                    return ".rar";
                default:
                    return null;
            }
        }

        private static readonly string[] SizeSuffixes =
                    { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
        public static string FixStringFormat(string Text)
        {
            Text = Text.Replace("&quot;", @"""");
            Text = Text.Replace("&#xD;&#xA;", Environment.NewLine);
            return Text;
        }
    }
}
