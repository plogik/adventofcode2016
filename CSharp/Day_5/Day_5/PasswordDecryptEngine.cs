using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
	public class PasswordDecryptEngine
	{
		public static string GetPwd(string doorId)
		{
			var pwdBuf = new StringBuilder();
			var md5 = MD5.Create();

			for (int i = 0; pwdBuf.Length < 8; i++)
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(doorId + i);
				byte[] hash = md5.ComputeHash(inputBytes);

				var builder = new StringBuilder();
				for (int n = 0; n < hash.Length; n++)
				{
					builder.Append(hash[n].ToString("x2"));
				}
				var str = builder.ToString();
				if (str.StartsWith("00000"))
				{
					pwdBuf.Append(str[5]);
				}
			}
			return pwdBuf.ToString();
		}

		public static string GetPt2Pwd(string doorId)
		{

			var pwdBuf = new char[8];
			var pwdFoundPositions = new bool[8];
			var md5 = MD5.Create();

			for (int i = 0, foundCount = 0; foundCount < 8; i++)
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(doorId + i);
				byte[] hash = md5.ComputeHash(inputBytes);

				var builder = new StringBuilder();
				for (int n = 0; n < hash.Length; n++)
				{
					builder.Append(hash[n].ToString("x2"));
				}
				var str = builder.ToString();
				if (str.StartsWith("00000"))
				{
					int pos = (int)char.GetNumericValue(str[5]);
					if(pos > -1 && pos < 8 && !pwdFoundPositions[pos])
					{
						pwdBuf[pos] = str[6];
						pwdFoundPositions[pos] = true;
						foundCount++;
					}
				}
			}
			return new string(pwdBuf);
		}

	}
}
