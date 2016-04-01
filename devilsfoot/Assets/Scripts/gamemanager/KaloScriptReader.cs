using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;

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

    public List<PropNode> ReadProps()
    {
        if(xmlDoc == null)
        {
            throw new System.Exception("Attempt to read null XMLDocument Object");
        }

        List<PropNode> pnList = new List<PropNode>();

        foreach(XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
        {
            if(xmlNode.Name == "prop")
            {
                PropNode pn = new PropNode();             

                foreach(XmlNode child in xmlNode.ChildNodes)
                {
                    switch (child.Name)
                    {
                        case "global_property":
                            pn.gpList.Add(new PropNode.global_property(child.Attributes["name"].Value,child.Attributes["value"].Value));
                            break;
                        case "state":
                            pn.stateList.Add(buildState(child));
                            break;
                        default:
                            Debug.Log(child.Name + " Not Found In KaloScript");
                            break;
                    }
                }
                Debug.Log(pn.gpList[0].name + " " + pn.gpList[0].value);
                pnList.Add(pn);
            }
        }

        return pnList;
    }

    private PropNode.state buildState(XmlNode node)
    {
        PropNode.state s = new PropNode.state(node.Attributes["name"].Value);

        foreach (XmlNode child in node.ChildNodes)
        {
            switch(child.Name)
            {
                case "state_property":
                    s.spList.Add(new PropNode.state.state_property(child.Attributes["name"].Value,child.Attributes["value"].Value,child.Attributes["hold_ms"].Value));
                    break;
                default:
                    Debug.Log(child.Name + " Not Found In KaloScript");
                    break;
            }
        }

        Debug.Log(s.print());

        return s;
    }

    public void Close()
    {
        xmlDoc = null;
    }
}
