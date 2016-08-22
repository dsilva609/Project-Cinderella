using System.Collections.Generic;
using System.Xml.Serialization;

namespace BusinessLogic.Models.BGGModels
{
	[XmlType("items")]
	public class BGGResult
	{
		[XmlAttribute("total")]
		public int total { get; set; }

		[XmlAttribute("termsofuse")]
		public string termsofuse { get; set; }

		[XmlElement("item")]
		public List<Item> item { get; set; }
	}

	[XmlType("item")]
	public class Item
	{
		[XmlAttribute("type")]
		public string type { get; set; }

		[XmlAttribute("id")]
		public int ID { get; set; }

		[XmlElement("name")]
		public Name name { get; set; }

		[XmlElement("yearpublished")]
		public YearPublished yearpublished { get; set; }

		[XmlElement("thumbnail")]
		public string Thumbnail { get; set; }

		[XmlElement("image")]
		public string Image { get; set; }

		[XmlElement("minplayers")]
		public MinPlayers MinPlayers { get; set; }

		[XmlElement("maxplayers")]
		public MaxPlayers MaxPlayers { get; set; }

		[XmlElement("playingtime")]
		public PlayingTime PlayingTime { get; set; }

		[XmlElement("minplaytime")]
		public PlayingTime MinPlayingTime { get; set; }

		[XmlElement("maxplaytime")]
		public PlayingTime MaxPlayingTime { get; set; }

		[XmlElement("minage")]
		public Value MinAge { get; set; }

		[XmlElement("link")]
		public List<Link> Links { get; set; }
	}

	[XmlType("name")]
	public class Name
	{
		[XmlAttribute("type")]
		public string type { get; set; }

		[XmlAttribute("value")]
		public string value { get; set; }
	}

	[XmlType("yearpublished")]
	public class YearPublished
	{
		[XmlAttribute("value")]
		public int value { get; set; }
	}

	[XmlType("minplayers")]
	public class MinPlayers
	{
		[XmlAttribute("value")]
		public int Value { get; set; }
	}

	[XmlType("maxplayers")]
	public class MaxPlayers
	{
		[XmlAttribute("value")]
		public int Value { get; set; }
	}

	[XmlType("playingtime")]
	public class PlayingTime
	{
		[XmlAttribute("value")]
		public int value { get; set; }
	}

	[XmlType("link")]
	public class Link
	{
		[XmlAttribute("type")]
		public string Type { get; set; }

		[XmlAttribute("id")]
		public int ID { get; set; }

		[XmlAttribute("value")]
		public string Value { get; set; }
	}

	public class Value
	{
		[XmlAttribute("value")]
		public string Val { get; set; }
	}
}