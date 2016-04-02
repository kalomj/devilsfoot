using System.Collections;
using System.Collections.Generic;

public class PropNode {
    public string name { get; set; }

    public class global_property
    {
        public string name { get; set; }
        public string value { get; set; }

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

    public PropNode()
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
}
