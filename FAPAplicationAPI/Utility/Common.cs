using System.Globalization;
using System.Text;

namespace FAPAplicationAPI.Utility
{
    public static class Common
    {
        public static string RemoveDiacritics(string text)
        {
            string normalizedText = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedText)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    if (c == 'đ' || c == 'Đ')
                    {
                        stringBuilder.Append('d');
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        public static string GetAllAfterSecondUnderscore(string str)
        {
            // Tìm vị trí của ký tự "_" thứ hai
            int position = str.IndexOf("_", 2);

            // Lấy tất cả ký tự sau vị trí của ký tự "_" thứ hai
            string part = str.Substring(position + 1);
            part = part.Substring(1, 2).PadLeft(2, '0');
            // Trả về chuỗi
            return part;
        }
    }
}
