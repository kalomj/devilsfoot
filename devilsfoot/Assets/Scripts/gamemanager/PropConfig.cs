﻿using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class representing configuration data for Props
/// 
/// Lists of nested classes are used for hierarchial organization 
/// of configuration parameters
/// 
/// PropConfig pc = new PropConfig();
/// 
/// TODO: replace public nested classes (ugly) with proper interface functions
/// 
/// </summary>
public class PropConfig {
    public string name { get; set; }

    public class global_property
    {
        public string name { get; set; }
        public string value { get; set; }

        public Dictionary<string, string> attributes;

        public global_property(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }

    public class state
    {
        public string name { get; set; }

        public class state_property
        {
            public string name { get; set; }
            public string value { get; set; }
            public string hold_ms { get; set; }
            public string pc_name { get; set; }

            public Dictionary<string, string> attributes;

            public state_property(string name, string value, string hold_ms, string pc_name)
            {
                this.name = name;
                this.value = value;
                this.hold_ms = hold_ms;
                this.pc_name = pc_name;
            }

            public state_property(string name, string value, string hold_ms)
            {
                this.name = name;
                this.value = value;
                this.hold_ms = hold_ms;
                this.pc_name = "";
            }

            public state_property(string name, string value)
            {
                this.name = name;
                this.value = value;
                this.hold_ms = "2000";
                this.pc_name = "";
            }

            public string print()
            {
                return name + " " + value + " " + hold_ms;
            }
        }
        public List<state_property> spList;

        public state(string name)
        {
            this.name = name;
            spList = new List<state_property>();
        }
        
        public string print()
        {
            string ret = name;

            foreach (state_property sp in spList)
            {
                ret += "<prop> " + sp.print();
            }

            return ret;
        }
    }

    public List<global_property> gpList;
    public List<state> stateList;

    public PropConfig()
    {
        gpList = new List<global_property>();
        stateList = new List<state>();
    }

    public List<DelayText> textListFromState(string stateName)
    {
        state foundState = null;

        foreach(state s in stateList)
        {
            if(s.name == stateName)
            {
                foundState = s;
                break;
            }
        }

        if(foundState == null)
        {
            throw new System.Exception("Prop state not found");
        }

        List<DelayText> dtList = new List<DelayText>();

        foreach (state.state_property sp in foundState.spList)
        {
            if(sp.name=="text")
            {
                dtList.Add(new DelayText(sp.value, sp.hold_ms, sp.pc_name));
            }
        }

        return dtList;
    }

    public List<DelayText> textListFromState(string stateName, string type)
    {
        state foundState = null;

        foreach (state s in stateList)
        {
            if (s.name == stateName)
            {
                foundState = s;
                break;
            }
        }

        if (foundState == null)
        {
            throw new System.Exception("Prop state not found");
        }

        List<DelayText> dtList = new List<DelayText>();

        foreach (state.state_property sp in foundState.spList)
        {
            if (sp.name == type + "_text")
            {
                dtList.Add(new DelayText(sp.value, sp.hold_ms, sp.pc_name));
            }
        }

        return dtList;
    }

    public void AddGlobalProperty(string name, string value, Dictionary<string,string> attributes)
    {
        global_property gp = new global_property(name, value);
        gp.attributes = attributes;
        gpList.Add(gp);
    }

    public void AddState(string name)
    {
        state s = new state(name);
        stateList.Add(s);
    }

    private state getState(string name)
    {
        foreach(state s in stateList)
        {
            if(s.name == name)
            {
                return s;
            }
        }

        throw new System.Exception("state " + name + " was not found");
    }

    public void AddStateProperty(string stateName, string statePropertyName, string statePropertyValue, Dictionary<string,string> spAttributes)
    {
        state.state_property sp = new state.state_property(statePropertyName, statePropertyValue);

        if (spAttributes.ContainsKey("hold_ms"))
        {
            sp.hold_ms = spAttributes["hold_ms"];
        }

        if (spAttributes.ContainsKey("pc_name"))
        {
            sp.pc_name = spAttributes["pc_name"];
        }

        sp.attributes = spAttributes;

        state s = getState(stateName);

        s.spList.Add(sp);

        return;
    }

    // The default state is the first state entry in the xml file
    public string DefaultState
    {
        get
        {
            return stateList[0].name;
        }
    }
}
