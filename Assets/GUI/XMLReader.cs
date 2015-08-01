using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;

public class XMLReader : MonoBehaviour {
	public TextAsset diccionario;

	public string idioma;
	public int codIdioma;

	string NuevaOleada;
	string button2;

	List<Dictionary<string, string>> lenguajes = new List<Dictionary<string, string>>();
	Dictionary<string, string> obj;

	void Awake(){
		lector ();
	}

	void Update(){
		lenguajes [codIdioma].TryGetValue ("Name", out idioma);
		lenguajes [codIdioma].TryGetValue ("nuevaOleada", out NuevaOleada);
		lenguajes [codIdioma].TryGetValue ("button2", out button2);
	}

	void OnGUI(){
		GUILayout.Button (NuevaOleada);
		GUILayout.Button (button2);
	}

	void lector(){
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (diccionario.text);
		XmlNodeList listaLenguajes = xmlDoc.GetElementsByTagName ("lenguage");

		foreach(XmlNode lenguajeValue in listaLenguajes){
			XmlNodeList Contenido = lenguajeValue.ChildNodes;
			obj = new Dictionary<string, string>();

			foreach(XmlNode value in Contenido){
				if(value.Name == "Name")
					obj.Add(value.Name, value.InnerText);
				if(value.Name == "nuevaOleada")
					obj.Add(value.Name, value.InnerText);
				if(value.Name == "button2")
					obj.Add(value.Name, value.InnerText);
			}
			lenguajes.Add(obj);
		}
	}

	public string getNuevaOleada(){
		return NuevaOleada;
	}

	public int getCodIdioma(){
		return codIdioma;
	}

	public void setCodIdioma(int codIdioma){
		this.codIdioma = codIdioma;
	}
}
