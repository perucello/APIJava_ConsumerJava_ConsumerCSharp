using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //importar biblioteca Client
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Testando Console Basico
            Console.WriteLine("Testando C# - EducaCiencia FastCode");
            Console.ReadLine();
            */

            /*
            //GetAPI_Java
            GetAPI_Java();
            Console.ReadKey();
            */ 

            /*
            // GetAPI_Java_2
            GetAPI_Java_2();
            Console.ReadKey();
            */

            /*
            //PostAPI_Java
            PostAPI_Java();
            Console.ReadKey();
            */

            /*
            //PutAPI_Java
            PutAPI_Java();
            Console.ReadKey();
            */

            /*
            //DeleteAPI_Java
            DeleteAPI_Java();
            Console.ReadKey();
            */

        }

        //Get API Java SpringBoot simples WebClient
        public static void GetAPI_Java()
        {
            string endpointGet = "http://localhost:8080/api/JPA/clientes/";
            WebClient api = new WebClient();
            string content = api.DownloadString(endpointGet); //insere o endpoint Java
            Console.WriteLine(content);
        }

        //Get API Java SpringBoot - WebRequest
        public static void GetAPI_Java_2()
        {
            string endpointGet_2 = "http://localhost:8080/api/JPA/clientes/";
            WebRequest request = WebRequest.Create(endpointGet_2);
            request.Method = "GET";
            var response = request.GetResponse();

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    string content = streamReader.ReadToEnd();
                    Console.WriteLine("GET" + content);
                }
            }
            else
            {
                Console.WriteLine("GET Fail");
            }
        }

        //Post API Java SpringBoot - WebRequest
        public static void PostAPI_Java()
        {
            string endpointPost = "http://127.0.0.1:8080/api/JPA/clientes/add/";
            WebRequest request = WebRequest.Create(endpointPost);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            string json = 
                "{" +
                "\"nome\":\"EducacienciaFastCode\"," +
                "\"email\":\"Educaciencia@FastCode.com.br\"" +
                "}";

            var byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Post  => ok");
                Console.WriteLine(json);
            }
            else
            {
                Console.Write("fail Post");
            }
        }

        //Put API Java SpringBoot - WebRequest
        public static void PutAPI_Java()
        {
            string endpointPut = "http://localhost:8080/api/JPA/clientes/";
            string id = "1";
            WebRequest request = WebRequest.Create(endpointPut + id);
            request.Method = "PUT";
            request.ContentType = "application/json; charset=UTF-8";
            string json = 
                "{" +
                "\"id\":\"1\"," +
                "\"nome\":\"PUT-EducaCiencia\"," +
                "\"email\":\"PUT-Educaciencia@FastCode.com.br\"" +
                "}";

            var byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("PUT ID " + id + " => ok " );
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("fail Post");
            }
        }


        //Delete API Java SpringBoot - WebRequest
        public static void DeleteAPI_Java()
        {
            string endpointDelete = "http://localhost:8080/api/JPA/clientes/delete/";
            string id = "1";
            WebRequest request = WebRequest.Create(endpointDelete + id);
            request.Method = "DELETE";
            var response = (HttpWebResponse)request.GetResponse();

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.NoContent && (int)response.StatusCode == 204)
            {
                if ((int)response.StatusCode == 204)
                    Console.WriteLine("Deletado id " + id + " => OK ");
            }
            else
            {
                Console.WriteLine("Falha metodo Delete");
            }

        }
    }
}
