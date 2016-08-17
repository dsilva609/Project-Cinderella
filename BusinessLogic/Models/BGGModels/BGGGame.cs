using System.Collections.Generic;

namespace BusinessLogic.Models.BGGModels
{
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class BGGGame
	{
		public itemsItem2 item { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string termsofuse { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItem2
	{
		[System.Xml.Serialization.XmlElementAttribute("description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("image", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("link", typeof(itemsItemLink))]
		[System.Xml.Serialization.XmlElementAttribute("maxplayers", typeof(itemsItemMaxplayers))]
		[System.Xml.Serialization.XmlElementAttribute("maxplaytime", typeof(itemsItemMaxplaytime))]
		[System.Xml.Serialization.XmlElementAttribute("minage", typeof(itemsItemMinage))]
		[System.Xml.Serialization.XmlElementAttribute("minplayers", typeof(itemsItemMinplayers))]
		[System.Xml.Serialization.XmlElementAttribute("minplaytime", typeof(itemsItemMinplaytime))]
		[System.Xml.Serialization.XmlElementAttribute("name", typeof(itemsItemName))]
		[System.Xml.Serialization.XmlElementAttribute("playingtime", typeof(itemsItemPlayingtime))]
		[System.Xml.Serialization.XmlElementAttribute("poll", typeof(itemsItemPoll))]
		[System.Xml.Serialization.XmlElementAttribute("thumbnail", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("yearpublished", typeof(itemsItemYearpublished))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items { get; set; }

		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public List<ItemsChoiceType> ItemsElementName { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string type { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint id { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemLink
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string type { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint id { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemMaxplayers
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemMaxplaytime
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemMinage
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemMinplayers
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemMinplaytime
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemName
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string type { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte sortindex { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemPlayingtime
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemPoll
	{
		private itemsItemPollResults[] resultsField;

		[System.Xml.Serialization.XmlElementAttribute("results")]
		public itemsItemPollResults[] results
		{
			get
			{
				return this.resultsField;
			}
			set
			{
				this.resultsField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string title { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte totalvotes { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemPollResults
	{
		[System.Xml.Serialization.XmlElementAttribute("result")]
		public List<itemsItemPollResultsResult> result { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string numplayers { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemPollResultsResult
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte numvotes { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte level { get; set; }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool levelSpecified { get; set; }
	}

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class itemsItemYearpublished
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort value { get; set; }
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType
	{
		description,

		image,

		link,

		maxplayers,

		maxplaytime,

		minage,

		minplayers,

		minplaytime,

		name,

		playingtime,

		poll,

		thumbnail,

		yearpublished,
	}
}