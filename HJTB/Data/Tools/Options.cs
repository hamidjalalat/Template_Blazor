using Data.Tools.Enums;

namespace Data.Tools
{
	public class Options 
	{
		public Options() : base()
		{
		}

		public Provider Provider { get; set; }
		
		public string ConnectionString { get; set; }
		
	}
}
