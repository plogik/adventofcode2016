using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_2
{
	public class ColumnLineReader : IEnumerable<string>
	{
		private string text;

		public ColumnLineReader(string text)
		{
			this.text = text;
		}

		public IEnumerator<string> GetEnumerator()
		{
			return new ColumnLineEnumerator(text);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ColumnLineEnumerator(text);
		}
	}

	public class ColumnLineEnumerator : IEnumerator<string>
	{
		private List<string> lines = new List<string>();
		private int currentRow = -1;

		public ColumnLineEnumerator(string text)
		{
			Parse(text);
		}

		private void Parse(string text)
		{
			var col1 = new List<string>();
			var col2 = new List<string>();
			var col3 = new List<string>();
			using (var reader = new StringReader(text))
			{
				string line;
				while((line = reader.ReadLine()) != null)
				{
					var columns = line.Split(new char[] { ' ' },
						StringSplitOptions.RemoveEmptyEntries);

					col1.Add(columns[0]);
					col2.Add(columns[1]);
					col3.Add(columns[2]);
				}
			}
			lines.Add(String.Join(" ", col1.ToArray()));
			lines.Add(String.Join(" ", col2.ToArray()));
			lines.Add(String.Join(" ", col3.ToArray()));
		}

		public string Current
		{
			get
			{
				return lines[currentRow];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return lines[currentRow];
			}
		}

		public void Dispose()
		{
			
		}

		public bool MoveNext()
		{
			currentRow++;
			return currentRow < 3;
		}

		public void Reset()
		{
			currentRow = 0;
		}
	}
}
