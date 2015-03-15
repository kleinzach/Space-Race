using UnityEngine;
using System.Collections;
using System.Xml;

public static class Util {

	public static string key = "MW9S-E7SL-26DU-VV8V";

	public static float getXMLFloat(string tag,XmlElement element){
		return float.Parse(element.GetElementsByTagName(tag).Item(0).InnerText);
	}

	public static int getXMLInt(string tag, XmlElement element)
	{
		return int.Parse(element.GetElementsByTagName(tag).Item(0).InnerText);
	}

	public static string getXMLString(string tag, XmlElement element)
	{
		return element.GetElementsByTagName(tag).Item(0).InnerText;
	}

	public static int partner(int i)
	{
		if (i % 2 == 0)
		{
			return i - 1;
		}
		return i + 1;
	}

	public static Station getStation(string abbr)
	{
		foreach(Station sta in GameObject.FindObjectsOfType<Station>()){
			if (sta.abbr == abbr)
			{
				return sta;
			}
		}
		return null;
	}

	public static Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r, g, b, 255);
	}
}
