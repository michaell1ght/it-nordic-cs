using System;
using System.Collections.Generic;
using System.Text;

namespace ClassExtentions
{
	class Passport : BaseDocument
	{
		public Passport(int docNumber, DateTimeOffset issueDate, string personName, string country)
			:base("Passport", docNumber, issueDate)
		{
			DocNumber = docNumber;
			IssueDate = issueDate;
			PersonName = personName;
			Country = country;
		}
		public string PersonName { get; private set; }
		public string Country { get; private set; }
		override public string PropertyString
		{
			get
			{
				return $"Document name is {DocName}, country is {Country}, " +
					$"personName is {PersonName}, number is {DocNumber}, issue date is {IssueDate}";
			}
		}

		public void ChangeIssueDate (DateTimeOffset newIssueDate)
		{
			IssueDate = newIssueDate;
		}
	}
}
