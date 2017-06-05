using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProjectCinderella.Model.BGGModels
{
	[XmlType("items")]
	public class BGGGame
	{
		[XmlElement("item")]
		public List<Item> Items { get; set; }
	}
}