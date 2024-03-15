using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Infrastructure.ExternalApi.ImageServer
{
    //سرویسی که کمک می کند هر با خواستم عکس ها را آپ
    //آپلود کنم عکس ها رو اینجا گذاشتم که ازش استفاده کنم

    //یک سری فایل بهش می دم و لیستی از آدرس ها را ازش می گیرم

    public interface IImageUploadService
    {
        List<string> Upload(List<IFormFile> files);
    }

    public class ImageUploadService : IImageUploadService
    {
        public List<string> Upload(List<IFormFile> files)
        {
            var client = new RestClient("https://localhost:7111/api/Images?apikey=mysecretkey");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            foreach (var item in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    item.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
            }


            IRestResponse response = client.Execute(request);
            UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return upload.FileNameAddress;

        }
    }



    public class UploadDto
    {
        public bool Status { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}
