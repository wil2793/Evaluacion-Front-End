using _1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _2.DataAcces
{
    public class daUsuario
    {
        public string GetUSuario(int userId)
        {
            var url = $"{sUrl.host}api/Usuario/{userId}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = string.Empty;
                            string result = objReader.ReadToEnd();
                            if (result != "" && result != "null")
                            {
                                responseBody = result;
                            }
                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return "";
        }
        public string GetUSuario(string user, string pass)
        {
            var url = $"{sUrl.host}api/Usuario?user={user}&pass={pass}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = string.Empty;
                            string result = objReader.ReadToEnd();
                            if (result != "" && result != "null")
                            {
                                responseBody = result;
                            }
                            return responseBody;
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return "";
        }

        public void PostUsuario(eUsuario usuario)
        {
            var url = $"{sUrl.host}api/Usuario";
            var request = (HttpWebRequest)WebRequest.Create(url);

            var jsonString = new JavaScriptSerializer();
            var json = jsonString.Serialize(usuario);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }


        /*Editar*/
        public void PutUsuario(int id, eUsuario usuario)
        {
            var url = $"{sUrl.host}api/Usuario/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);

            var jsonString = new JavaScriptSerializer();
            var json = jsonString.Serialize(usuario);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }
    }
}
