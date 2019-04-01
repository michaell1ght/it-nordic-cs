using System;
using System.Collections.Generic;
using System.Text;

namespace ClassExtentions
{
	class BaseDocument
	{
		public BaseDocument(string docName, int docNumber, DateTimeOffset issueDate)
		{
			DocName = docName;
			DocNumber = docNumber;
			IssueDate = issueDate;
		}

		public string DocName { get; set; } 
		public int DocNumber { get; set; }
		public DateTimeOffset IssueDate { get; set; }
		virtual public string PropertyString
		{
			get
			{
				return $"Document name is {DocName}, number is {DocNumber}, issue date is {IssueDate}" ;
			}
		}

		virtual public void WriteToConsole()
		{
			Console.WriteLine(PropertyString);
		}
	}
}
