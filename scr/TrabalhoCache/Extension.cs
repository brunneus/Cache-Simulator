
namespace TrabalhoCache
{
    public static class Extension
    {
        public static string Truncate(this string value)
        {
            try
            {
                string[] split = value.Split(',');
                string strResult = string.Concat(split[0], ",");

                int i = 0;
                if (split.Length > 1)
                {
                    for (i = 0; i < 4; i++)
                        strResult = string.Concat(strResult, split[1][i]);
                }

                i = 4 - i;

                for (int j = 0; j < i; j++)
                    strResult = string.Concat(strResult, "0");

                return strResult;
            }
            catch
            {
                return value;
            }
        }
    }
}
