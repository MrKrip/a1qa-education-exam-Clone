using System.Security.Cryptography;

namespace ExamTask.Util
{
    public static class TextGenerator
    {
        public static string GenerateText()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrtuvwxyz0123456789";
            int lenght = RandomNumberGenerator.GetInt32(0, chars.Length);
            string text = new string(Enumerable.Repeat(chars, lenght).Select(s => s[RandomNumberGenerator.GetInt32(0, chars.Length)]).ToArray());
            return text;
        }
    }
}
