

using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace RESTORANS.Utilities
{
    public class function
    {
        public static int _UserID = 0;
        public static string _UserName = string.Empty;
        public static string _Email = string.Empty;
        public static string _Messager = string.Empty;
        public static string _MessagerEmail = string.Empty;
        public static string _Images = string.Empty;
       // internal static string _MessageEmail;   
       
        public static string TitlesSlugGeneration(string type, string title, long id)
        {
            string Stitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return Stitle;
        }

        public static string getCurrentDate()
        {
            return DateTime.Now.ToString("yy-MM-dd HH:mm:ss");
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for(int i = 0; i< result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));

            }
            return strBuilder.ToString();
        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            // lặp thêm năm lần mã hóa xâu đảm bảo tính bảo mật
            // mỗi lần lặp nhân đôi xâu mã hóa , ở giữa thêm "_"
            // có thể làm cách khác để tăng tính bảo mật ở đây
            for(int i = 0; i<=5; i++)
                 str = MD5Hash(str + "_" + str);
           return str;
            
        }

        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(function._UserName) || string.IsNullOrEmpty(function._Email) || (function._UserID <= 0))
                return false;
            return true;
        }
      
    }
}
