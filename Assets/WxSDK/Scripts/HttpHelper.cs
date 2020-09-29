using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
public class HttpHelper
{
    public static async Task<string> Post(string url, string postData,string app="")
    {
        HttpWebRequest request = null;
        if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request.ProtocolVersion = HttpVersion.Version11;
            // 这里设置了协议类型。
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//(SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
            request.KeepAlive = false;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.Expect100Continue = false;
        }
        else
        {
            request = (HttpWebRequest)WebRequest.Create(url);
        }

        request.Method = "POST";    //使用get方式发送数据
        request.ContentType = "text/plain";
        request.Referer = null;
        request.AllowAutoRedirect = true;
        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)";
        request.Accept = "*/*";
        request.Headers.Add("X-Requested-With", app);

        byte[] data = Encoding.UTF8.GetBytes(postData);
        Stream newStream = request.GetRequestStream();
        await newStream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
        newStream.Close();
        //获取网页响应结果
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        string result = string.Empty;
        using (StreamReader sr = new StreamReader(stream))
        {
            return await sr.ReadToEndAsync();
        }
    }

    private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
        return true; //总是接受  
    }

    public static async Task<string> Get(string url)
    {
        HttpClient httpClient = new HttpClient();
        var res = await httpClient.GetAsync(url);
        return await res.Content.ReadAsStringAsync();
    }
}

