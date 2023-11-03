using System.ComponentModel.DataAnnotations;

namespace Models.Base
{
	public abstract class ExtendedEntity : Entity
	{
		public ExtendedEntity() : base()
		{
			UpdateDateTime = Utility.Now;
		}
		
		[Display(ResourceType = typeof(Resources.DataDictionary),Name = nameof(Resources.DataDictionary.IsActive))]
		public bool IsActive { get; set; }
		
		
		[Display(ResourceType = typeof(Resources.DataDictionary),Name = nameof(Resources.DataDictionary.UpdateDateTime))]
		public System.DateTime UpdateDateTime { get; set; }
	}
}
