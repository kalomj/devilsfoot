using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;


/// <summary>
/// Read script XML file, construct a list of
/// PropConfig objects based on the content of the file
/// </summary>
public class KaloScriptReader {

    XmlDocument xmlDoc;

    public void OpenTextAsset(TextAsset textAsset)
    {
        xmlDoc = new XmlDocument();

        using (StringReader reader = new StringReader(textAsset.text))
        {
            xmlDoc.Load(reader);
        }
    }

    public List<PropConfig> ReadProps()
    {
        if(xmlDoc == null)
        {
            throw new System.Exception("Attempt to read null XMLDocument Object");
        }

        List<PropConfig> pcList = new List<PropConfig>();

        foreach(XmlNode propNode in xmlDoc.DocumentElement.ChildNodes)
        {
            if(propNode.Name == "prop")
            {
                PropConfig pc = new PropConfig();  
                
                if(propNode.Attributes["name"] == null)
                {
                    throw new System.Exception("KaloScript has unnamed prop");
                }

                pc.name = propNode.Attributes["name"].Value;
                
                foreach (XmlNode child in propNode.ChildNodes)
                {
                    switch (child.Name)
                    {
                        case "global_property":
                            buildGlobalProperty(pc, child);
                            break;
                        case "state":
                            buildState(pc,child);
                            break;
                        default:
                            Debug.Log(child.Name + " Not Found In KaloScript");
                            break;
                    }
                }
                pcList.Add(pc);
            }
        }

        return pcList;
    }

    private void buildGlobalProperty(PropConfig pc, XmlNode gpNode)
    {
        Dictionary<string, string> attributeDictionary = new Dictionary<string, string>();

        foreach (XmlAttribute attribute in gpNode.Attributes)
        {
            attributeDictionary.Add(attribute.Name, attribute.Value);
        }

        pc.AddGlobalProperty(gpNode.Attributes["name"].Value, gpNode.Attributes["value"].Value,attributeDictionary);
    }

    private void buildState(PropConfig pc, XmlNode stateNode)
    {
        pc.AddState(stateNode.Attributes["name"].Value);

        foreach (XmlNode statePropertyNode in stateNode.ChildNodes)
        {
            switch(statePropertyNode.Name)
            {
                case "state_property":
                    buildStateProperty(pc, stateNode,statePropertyNode);
                    break;
                default:
                    Debug.Log(statePropertyNode.Name + " Not Found In KaloScript");
                    break;
            }
        }

        return;
    }

    private void buildStateProperty(PropConfig pc, XmlNode stateNode, XmlNode statePropertyNode)
    {

        Dictionary<string, string> attributeDictionary = new Dictionary<string, string>();

        foreach(XmlAttribute attribute in statePropertyNode.Attributes)
        {
            attributeDictionary.Add(attribute.Name, attribute.Value);
        }

        pc.AddStateProperty(stateNode.Attributes["name"].Value, statePropertyNode.Attributes["name"].Value, statePropertyNode.Attributes["value"].Value, attributeDictionary);

        return;
    }

}
