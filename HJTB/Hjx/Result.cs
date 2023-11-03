using System.Collections.Generic;

namespace Hjx
{
	public class Result 
	{
		public Result() : base()
		{
			ErrorMessages =new List<string>();

			WarningMessages =new List<string>();

			InformationMessages =new List<string>();
		}
		
		public bool IsSuccessful { get; set; }
		
		public IList<string> ErrorMessages { get; set; }
		
		public IList<string> WarningMessages { get; set; }
		
		public IList<string> InformationMessages { get; set; }
		
		public virtual void AddErrorMessage(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			message = message.Fix();

			if (ErrorMessages.Contains(message))
			{
				return;
			}

			ErrorMessages.Add(message);
		}
		
		public virtual void AddWarningMessage(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			message = message.Fix();

			if (WarningMessages.Contains(message))
			{
				return;
			}

			WarningMessages.Add(message);
		}
		
		public virtual void AddInformationMessage(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			message = message.Fix();

			if (InformationMessages.Contains(message))
			{
				return;
			}

			InformationMessages.Add(message);
		}
		
	}
}
