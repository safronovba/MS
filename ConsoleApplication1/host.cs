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
        set { ip=Ip; }
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

    public bool timecheck()
    {
        double tempinterval=this.scanint;
        int left = 0, right = 1;
        try
        {
            left = (DateTime.Now.Hour * 60 + DateTime.Now.Minute) * 60 + DateTime.Now.Second;
            right = (System.DateTime.Parse(this.lasttime).AddSeconds(tempinterval).Hour * 60 + System.DateTime.Parse(this.lasttime).AddSeconds(tempinterval).Minute) * 60 + System.DateTime.Parse(this.lasttime).AddSeconds(tempinterval).Second;
        }
        catch (Exception ex) { Console.WriteLine("no lasttime on device"); }
        if (left > right)
        {
            return true;
        }
        return false;
    }
}