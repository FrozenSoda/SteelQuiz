using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.Extensions
{
    public static class ImageExtensions
    {
        public static string CalculateSHA512(this Image image)
        {
            using (var ms = new MemoryStream())
            using (var sha512 = new SHA512CryptoServiceProvider())
            {
                image.Save(ms, image.RawFormat);
                var hashBytes = sha512.ComputeHash(ms.ToArray());
                var hash = Convert.ToBase64String(hashBytes);
                return hash;
            }
        }
    }
}
