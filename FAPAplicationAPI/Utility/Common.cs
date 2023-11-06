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
    }
}
