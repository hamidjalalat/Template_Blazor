namespace Models
{
	public class Application : Base.ExtendedEntity
	{
		public Application() : base()
		{
		}

        public string Name { get; set; }
		public string Description { get; set; }

    }
}
