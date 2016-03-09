using System.Collections.Generic;
using System.Web;

namespace UnitTests.UI.Controllers
{
	public class MockHttpSession : HttpSessionStateBase
	{
		private Dictionary<string, object> _sessionDictionary = new Dictionary<string, object>();

		public override object this[string name]
		{
			get { return this._sessionDictionary[name]; }
			set { this._sessionDictionary[name] = value; }
		}
	}
}