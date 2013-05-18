using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

public class host
{
    private string ip;
    private string name;
    private string mac;
    private int scanint;
    private string nowstate;
    private string lasterror;
    private string lastsucces;
    private string lasttime;
    private string group;

    public host() { }

    public host(string ip)
    {
        this.ip = ip;
    }

    public host(string ip, string name, string mac)
    {
        this.ip = ip;
        this.name = name;
        this.mac = mac;
    }

    public host(string ip, string name, string mac, int scanint)
    {
        this.ip = ip;
        this.name = name;
        this.mac = mac;
        this.scanint = scanint;
    }

    public host(string ip, string name, int scanint, string group)
    {
        this.ip = ip;
        this.name = name;

        if (scanint == 0) { scanint = 60; }
        this.scanint = scanint;

        this.group = group;
    }

    public host(int id, string ip, int scanint, string nowstate, string lasterror, string lastsucces, string lasttime)
    {
        this.ip = ip;

        if (scanint == 0) { scanint = 20; }
        this.scanint = scanint;

        this.nowstate = nowstate;

        this.lasterror = lasterror;

        this.lastsucces = lastsucces;

        this.lasttime = lasttime;
    }

    public string Ip
    {
        get { return ip; }
    }

    public string Name
    {
        get { return name; }
    }

    public string Mac
    {
        get { return mac; }
    }

    public int Scanint
    {
        get { return scanint; }
    }

    public string Group
    {
        get { return group; }
    }

    public bool timecheck()
    {
        double tempinterval = this.scanint;
        int left = 0, right = 1;

        if ((this.lasttime == null) || (this.lasttime == "")) { return true; }
        left = (DateTime.Now.Hour * 60 + DateTime.Now.Minute) * 60 + DateTime.Now.Second;
        right = (System.DateTime.Parse(this.lasttime).AddSeconds(tempinterval).Hour * 60 + System.DateTime.Parse(this.lasttime).AddSeconds(tempinterval).Minute) * 60 + System.DateTime.Parse(this.lasttime).AddSeconds(tempinterval).Second;

        if (left > right)
        {
            return true;
        }
        return false;
    }

    public bool checkmatch(string ip, string[] oldhosts)
    {
        for (int i = 0; i < oldhosts.Length; i++)
        {
            if (ip == oldhosts[i]) { return true; }
        }
        return false;
    }
}