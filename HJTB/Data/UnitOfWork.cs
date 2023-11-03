using Data.Tools;

namespace Data
{
	public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
	{

		public UnitOfWork(Options options) : base(options)
		{
		}

		 
		//private IXXXXXRepository _xXXXXRepository;

		//public IXXXXXRepository XXXXXRepository
		//{
		//	get
		//	{
		//		if (_xXXXXRepository == null)
		//		{
		//			_xXXXXRepository =
		//				new XXXXXRepository(DatabaseContext);
		//		}

		//		return _xXXXXRepository;
		//	}
		//}

		 
		private IApplicationRepository _applicationRepository;

		public IApplicationRepository ApplicationRepository
		{
			get
			{
				if (_applicationRepository == null)
				{
					_applicationRepository =
						new ApplicationRepository(DatabaseContext);
				}

				return _applicationRepository;
			}
		}
		 
	}
}
