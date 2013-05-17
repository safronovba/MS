using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;

namespace mssupport
{
    public class icmp
    {
        Ping Sender = new Ping();
        String Data = "[012345678901234567890123456789]";
        const int Timeout = 120;
        private string lastsuccess;

        public icmp() { }

        public string resolvename(string hostiptoresolve)
        {
            string tempname;
            tempname = Dns.Resolve(hostiptoresolve).HostName.ToString();
            return tempname;
        }

        public string resolveip(string hostnametoresolve)
        {
            string tempip = "";
            try { tempip = Dns.Resolve(hostnametoresolve).AddressList[0].ToString(); }
            catch (Exception ex) { tempip = ex.Message; }
            return tempip;
        }

        public string resolvemac(string hostmactoresolve)
        {
            string tempmac;
            tempmac = "000000000000";
            return tempmac;
        }

        public string resolvename(IPAddress hostiptoresolve)
        {
            string tempname;
            tempname = Dns.Resolve(hostiptoresolve.ToString()).HostName.ToString();
            return tempname;
        }

        public string resolveip(IPAddress hostnametoresolve)
        {
            string tempip = "";
            try { tempip = Dns.Resolve(hostnametoresolve.ToString()).AddressList[0].ToString(); }
            catch (Exception ex) { tempip = ex.Message; }
            return tempip;
        }

        public string resolvemac(IPAddress hostmactoresolve)
        {
            string tempmac;
            tempmac = "000000000000";
            return tempmac;
        }

        public bool ping(string ip, int re)
        {
            PingReply Reply;
            byte[] Buffer = Encoding.ASCII.GetBytes(Data);
            try { Reply = Sender.Send(ip, Timeout, Buffer); }
            catch (Exception ex)
            {
                lastsuccess = DateTime.Now.ToString("T") + "\nОшибка: " + ex;
                return false; ;
            }
            if (Reply.Status == IPStatus.Success)
            {
                lastsuccess = DateTime.Now.ToString("T") + " - " + Reply.RoundtripTime + "мс";
                return true;
            }
            return false;
        }

        public bool ping(IPAddress ip, int re)
        {
            PingReply Reply;
            byte[] Buffer = Encoding.ASCII.GetBytes(Data);
            try { Reply = Sender.Send(ip, Timeout, Buffer); }
            catch (Exception ex)
            {
                lastsuccess = "host " + ip + " is offline now";
                lastsuccess = DateTime.Now.ToString("T") + ": Ошибка: " + ex.Message;
                return false;
            }
            if (Reply.Status == IPStatus.Success)
            {
                lastsuccess = DateTime.Now.ToString("T") + " - " + Reply.RoundtripTime + "мс";
                return true;
            }
            return false;
        }

        public string ping(string ip)
        {
            PingReply Reply;
            byte[] Buffer = Encoding.ASCII.GetBytes(Data);
            try { Reply = Sender.Send(ip, Timeout, Buffer); }
            catch (Exception ex)
            {
                lastsuccess = "host " + ip + " is offline now";
                lastsuccess = DateTime.Now.ToString("T") + ": Ошибка: " + ex.Message;
                return lastsuccess;
            }
            if (Reply.Status == IPStatus.Success)
            {
                lastsuccess = DateTime.Now.ToString("T") + " - " + Reply.RoundtripTime + "мс";
            }
            return lastsuccess;
        }

        public string ping(IPAddress ip)
        {
            PingReply Reply;
            byte[] Buffer = Encoding.ASCII.GetBytes(Data);
            try { Reply = Sender.Send(ip, Timeout, Buffer); }
            catch (Exception ex)
            {
                lastsuccess = "host " + ip + " is offline now";
                lastsuccess = DateTime.Now.ToString("T") + ": Ошибка: " + ex.Message;
                return lastsuccess; ;
            }
            if (Reply.Status == IPStatus.Success)
            {
                lastsuccess = DateTime.Now.ToString("T") + " - " + Reply.RoundtripTime + "мс";
            }
            return lastsuccess;
        }

        private int CompressByteArray(byte[] bytes)
        {
            /*Проверяем является ли массив подходящим для свертывания в int*/
            if (bytes.Length != 4) throw new FormatException("Wrong IPv4 address");
            int retval = 0; byte bit_shift = 0;
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                /*Прибавляем к финальному значению байты со сдвигом,
                  зависящим от текущего элемента массива*/
                retval += ((int)bytes[i]) << bit_shift;
                bit_shift += 8;
            }
            return retval;
        }

        private byte[] DecompressByteArray(int ip)
        {
            //Разбиваем целое число на байты           
            var bytes = BitConverter.GetBytes(ip);
            //Разворачиваем в нужную последовательность     
            Array.Reverse(bytes);
            return bytes;
        }

        public IPAddress[] ExpandIpRange(IPAddress RangeFirst, IPAddress RangeLast)
        {
            /*Сворачиваем байты адреса в целое число*/
            var start_ip = (uint)(CompressByteArray(RangeFirst.GetAddressBytes()));
            /*Расчитываем дельту адресов(можно простым вычитанием, но xor логичнее и быстрее)*/
            var delta = (uint)(CompressByteArray(RangeLast.GetAddressBytes()) ^ start_ip);
            IPAddress[] retval = new IPAddress[delta];
            /*Создаем список адресов диапазона
              перебор осуществляется простым приращением*/
            for (uint i = 0; i <= delta - 1; i++)
                /*Разворачиваем число в массив байтов
                  Создаем экземпляр Ip адреса и передаем массив в конструктор
                  Добавляем адрес в список*/
                try { retval[i] = new IPAddress(DecompressByteArray((int)(start_ip + i))); }
                catch { continue; }
            return retval;
        }
    }
}
