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
                
                if(xmlNode.Attributes["name"] == null)
                {
                    throw new System.Exception("KaloScript has unnamed prop");
                }

                pn.name = xmlNode.Attributes["name"].Value;

                foreach (XmlNode child in xmlNode.ChildNodes)
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
                    s.spList.Add(buildStateProperty(child));
                    break;
                default:
                    Debug.Log(child.Name + " Not Found In KaloScript");
                    break;
            }
        }

        Debug.Log(s.print());

        return s;
    }

    private PropNode.state.state_property buildStateProperty(XmlNode node)
    {
        PropNode.state.state_property sp = new PropNode.state.state_property(node.Attributes["name"].Value, node.Attributes["value"].Value);

        if(node.Attributes["hold_ms"] != null)
        {
            sp.hold_ms = node.Attributes["hold_ms"].Value;
        }

        if (node.Attributes["pc_name"] != null)
        {
            sp.pc_name = node.Attributes["pc_name"].Value;
        }
        return sp;
    }

}
