using System;

namespace ViewModels.Applications
{
	public class CreateViewModel 
	{
		public CreateViewModel() : base()
		{
		}
        public Guid Id { get; set; }

        public string Name { get; set; }

		public string Description { get; set; }
		
	}
}
