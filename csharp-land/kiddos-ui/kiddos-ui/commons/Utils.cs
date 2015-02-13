using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

/*

Copyleft 2015 - Jose Ricardo de Oliveira Damico <jd.comment@gmail.com>

This file is part of Kiddos.

Kiddos is free software: you can redistribute it and/or modify it under the terms 
of the GNU General Public License as published by the Free Software Foundation, 
either version 3 of the License, or any later version.

Kiddos is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with Kiddos. 
If not, see http://www.gnu.org/licenses/.

*/

namespace kiddos_ui
{
    class Utils
    {
        private static Utils INSTANCE = null;



        private Utils() { }

        public static Utils Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new Utils();
                }
                return INSTANCE;
            }
        }

        public String getTextFromUrl(String urlStr)
        {

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            String ret = null;

            try
            {


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlStr);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    TextReader reader = new StreamReader(response.GetResponseStream());
                    ret = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ret;
        }

        public List<String> getPcapInterfaces()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            List<String> pCapInterfaces = new List<String>();

            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                throw new Exception("No interfaces found! Make sure WinPcap is installed.");

            }
            else
            {
                for (int i = 0; i != allDevices.Count; ++i)
                {
                    LivePacketDevice device = allDevices[i];
                    pCapInterfaces.Add(device.Description);

                }
            }
            return pCapInterfaces;
        }

        public void sendPacket(int deviceIndex, int times)
        {

            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                throw new Exception("No interfaces found! Make sure WinPcap is installed.");

            }
            else
            {


                PacketDevice selectedDevice = allDevices[deviceIndex];

                using (PacketCommunicator communicator = selectedDevice.Open(100, 
                                                                             PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                                             1000)) 
                {
                    Packet httpPacket = BuildHttpPacket();
                    for (int i = 0; i < times; i++)
                    {
                        communicator.SendPacket(httpPacket);

                    }

                }
            }
        }

        private Packet BuildHttpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, 
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("0.0.0.0"),
                    CurrentDestination = new IpV4Address("0.0.0.0"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, 
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, 
                    Ttl = 100,
                    TypeOfService = 0,
                };

            TcpLayer tcpLayer =
                new TcpLayer
                {
                    SourcePort = 4050,
                    DestinationPort = 80,
                    Checksum = null, 
                    SequenceNumber = 100,
                    AcknowledgmentNumber = 50,
                    ControlBits = TcpControlBits.Acknowledgment,
                    Window = 100,
                    UrgentPointer = 0,
                    Options = TcpOptions.None,
                };

            HttpRequestLayer httpLayer =
                new HttpRequestLayer
                {
                    Version = PcapDotNet.Packets.Http.HttpVersion.Version11,
                    Header = new HttpHeader(new HttpContentLengthField(11)),
                    Body = new Datagram(Encoding.ASCII.GetBytes("?action=getPaLst")),
                    Method = new HttpRequestMethod(HttpRequestKnownMethod.Get),
                    Uri = @"http://",
                };


            PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, httpLayer);

            return builder.Build(DateTime.Now);
        }

        public KiddosPocketEntity parseKiddosPocketStrXml(String kiddosPocketStrXml)
        {
            KiddosPocketEntity seedPocket = new KiddosPocketEntity();
            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(kiddosPocketStrXml)))
                {
                    List<SeedEntity> seedLst = new List<SeedEntity>();
                    SeedEntity seed = null;
                    while (reader.Read())
                    {
                        if (reader.Name == "seed")
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    seed = new SeedEntity();
                                    seed.method = reader.GetAttribute("method");
                                    seed.address = reader.GetAttribute("address");
                                    seed.domain = reader.GetAttribute("domain");
                                    seed.ip = reader.GetAttribute("ip");
                                    seed.mac = reader.GetAttribute("mac");
                                    seed.protocol = reader.GetAttribute("protocol");
                                    try
                                    {
                                        seed.randn = Int32.Parse(reader.GetAttribute("randn"));
                                    }
                                    catch (Exception)
                                    {

                                        seed.randn = -1;
                                    }

                                    try
                                    {
                                        seed.rands = Int32.Parse(reader.GetAttribute("rands"));
                                    }
                                    catch (Exception)
                                    {

                                        seed.randn = -1;
                                    }
                                    
                                    seedLst.Add(seed);
                                    break;

                            }
                        }
                        
                    }


                    seedPocket.seedLst = seedLst;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return seedPocket;
        }

        public HttpEntity getHttpEntityFromUrlPOST(String protocol, String baseUrl, String baseParams, int nSize, int sSize)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            HttpEntity ret = new HttpEntity();
            using (WebClient client = new WebClient())
            {
                String[] paramsParts = baseParams.Split('&');
                StringBuilder sb = new StringBuilder();
                String separator = "?";
                if (baseUrl.Contains("?")) separator = "&";
                sb.Append(protocol + "://" + baseUrl + separator);
                NameValueCollection paramsCollection = new NameValueCollection();
                foreach (String item in paramsParts)
                {
                    String[] preCol = item.Split('=');
                    paramsCollection.Add(preCol[0], genRandParamValues(preCol[0], preCol[1], nSize, sSize));
                    sb.Append(preCol[0] + "=" + genRandParamValues(preCol[0], preCol[1], nSize, sSize) + "&");
 
                }
                ret.Url = sb.ToString();
                try
                {
                    byte[] response = client.UploadValues(protocol + "://" + baseUrl, paramsCollection);

                    string result = System.Text.Encoding.UTF8.GetString(response);
                    ret.Response = result;
                    ret.Length = result.Length;
                    ret.Status = HttpStatusCode.OK;
                }
                catch (Exception e)
                {
                    ret.Exception = e;
                    ret.Status = HttpStatusCode.RequestTimeout;
                }
                
            }
            return ret;
        }

        public String genRandParamValues(String param, String value, int nSize, int sSize)
        {
            DateTime dt = new DateTime();
            Int64 ms = dt.Millisecond;
            String strMs = ms.ToString();

            String md5 = CalculateMD5Hash(strMs + value + param);
           
            String subMd5 = null;

            if(value == "{SRAND}"){
                if (md5.Length > sSize) subMd5 = md5.Substring(0, sSize);
                else
                {
                    while (md5.Length <= sSize)
                    {
                        md5 = md5 + md5;
                    }
                    subMd5 = md5.Substring(0, sSize);
                }
                value = subMd5;
            }
            else if (value == "{NRAND}")
            {
                Random rnd = new Random();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < nSize; i++)
                {
                    
                    sb.Append(rnd.Next(9).ToString());

                }
                value = sb.ToString();
            } 
            if (value == "{ERAND}")
            {
                value = md5.Substring(0,5);
                value = value + "@" + value + ".com.br";
            }
            return value;
        }

        public string CalculateMD5Hash(string input)
        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public HttpEntity getHttpEntityFromUrlGET(String urlStr)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            HttpEntity ret = new HttpEntity();
            ret.Url = urlStr;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ret.Url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    TextReader reader = new StreamReader(response.GetResponseStream());
                    ret.Response = reader.ReadToEnd();
                    ret.Length = ret.Response.Length;
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                ret.Status = response.StatusCode;
            }
            catch (Exception e)
            {
                ret.Exception = e;
                ret.Status = HttpStatusCode.RequestTimeout;
            }

            return ret;
        }

        public HttpEntity getHttpEntityFromUrlGET(String protocol, String baseUrl, String baseParams, int nSize, int sSize)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            HttpEntity ret = new HttpEntity();

            try
            {
                String[] paramsParts = baseParams.Split('&');
                StringBuilder sb = new StringBuilder();
                sb.Append(protocol + "://" + baseUrl+"?");
                NameValueCollection paramsCollection = new NameValueCollection();
                foreach (String item in paramsParts)
                {
                    String[] preCol = item.Split('=');
                    sb.Append(preCol[0] + "=" + genRandParamValues(preCol[0], preCol[1], nSize, sSize) + "&");
                }
                ret.Url = sb.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ret.Url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    TextReader reader = new StreamReader(response.GetResponseStream());
                    ret.Response = reader.ReadToEnd();
                    ret.Length = ret.Response.Length;
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                ret.Status = response.StatusCode;
            }
            catch (Exception e)
            {
                //throw e;
                ret.Exception = e;
                ret.Status = HttpStatusCode.RequestTimeout;
            }

            return ret;
        }

    }
}
