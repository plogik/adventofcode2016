using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
	class Day14
	{
		struct Key
		{
			public char Letter;
			public int Index;

			public override bool Equals(object obj)
			{
				return obj is Key &&
					((Key)obj).Letter == Letter &&
					((Key)obj).Index == Index;
			}

			public override int GetHashCode()
			{
				return (int)Letter + Index;
			}
		}

		private List<Key> candidates = new List<Key>();
		private List<Key> found = new List<Key>();

		public int GetIndex(string salt)
		{
			var hasher = MD5.Create();
			int idx = 0;

			while (found.Count < 64)
			{
				var result = GetMd5Hash(hasher, String.Format("{0}{1}", salt, idx));

				PruneInvalidCandidates(idx);

				FindAndMatchCandidates(result);

				FindNewCandidates(result, idx);

				idx++;
			}
			return found[found.Count - 1].Index;
		}

		void PruneInvalidCandidates(int idx)
		{
			var tmpCandidates = new List<Key>(candidates);
			foreach (var candidate in candidates)
			{
				if ((candidate.Index + 1000) < idx)
				{
					tmpCandidates.Remove(candidate);
				}
			}
			candidates = tmpCandidates;
		}

		void FindAndMatchCandidates(string input)
		{
			var tmpCandidates = new List<Key>(candidates);
			foreach (var candidate in candidates)
			{
				if (Contains5LetterCombo(input, candidate.Letter))
				{
					tmpCandidates.Remove(candidate);
					found.Add(new Key() { Letter = candidate.Letter, Index = candidate.Index });

					/*Console.WriteLine("Matched:" + candidate.Letter + ", seed at " + candidate.Index);
					Console.WriteLine(candidate.Hash);
					Console.WriteLine(input);
					Console.WriteLine();
					*/
					//break;
				}
			}
			candidates = tmpCandidates;
		}

		void FindNewCandidates(string input, int idx)
		{
			char foundChar;
			if (Contains3LetterCombo(input, out foundChar))
			{
				candidates.Add(new Key() { Letter = foundChar, Index = idx });
			}
		}

		static bool Contains5LetterCombo(string input, char needle)
		{
			int charCount = 1;
			char lastChar = (char)0;

			foreach (var c in input)
			{
				if (c == needle && c == lastChar)
					charCount++;
				else
					charCount = 1;
				lastChar = c;

				if (charCount == 5)
				{
					return true;
				}
			}
			return false;
		}

		static bool Contains3LetterCombo(string input, out char foundChar)
		{
			char lastChar = (char)0;
			int charCount = 1;
			foreach (var c in input)
			{
				if (c == lastChar)
					charCount++;
				else
					charCount = 1;

				if (charCount == 3)// && c != lastChar)
				{
					foundChar = c;
					return true;
				}

				lastChar = c;
			}
			foundChar = 'a'; // Does not matter
			return false;
		}

		// https://msdn.microsoft.com/en-us/library/system.security.cryptography.md5(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
		static string GetMd5Hash(MD5 md5Hash, string input)
		{
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}
	}
}
