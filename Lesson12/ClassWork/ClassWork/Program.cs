using System;

namespace ClassExtentions
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDocument document1 = new BaseDocument("someDoc1", 1, DateTimeOffset.MinValue);
			BaseDocument document2 = new BaseDocument("someDoc2", 2, DateTimeOffset.MinValue);
			Passport passport = new Passport(234, DateTimeOffset.Now, "Russia", "Ivan");
			BaseDocument[] docArray =
			{
			document1,
			document2,
			passport
			};
			for(int i=0; i < docArray.Length; i++)
			{
				if(docArray[i] is Passport)
				{
					((Passport)docArray[i]).ChangeIssueDate(DateTimeOffset.Now);
				}
			}
		}
	}
}