using ImageAPI.Converter;
using ImageAPI.Enums;
using System;
using System.Web.Http;
using System.Web.Hosting;

namespace WebClient.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]  
        [AllowAnonymous]
        public IHttpActionResult Convert(string sourceImagePath, string destinationImageName, ImageType imageType)
        {
            try
            {
                var lastIndex = sourceImagePath.LastIndexOf('/');
                var outputImageDirectory = sourceImagePath.Substring(0, lastIndex);
                var imageName = sourceImagePath.Substring(lastIndex + 1, sourceImagePath.Length - lastIndex - 1);

                var sourceImage = HostingEnvironment.MapPath(sourceImagePath);
                var destImage = HostingEnvironment.MapPath(outputImageDirectory + "/" + destinationImageName + "." + imageType);

                var converter = new Converter();
                converter.Convert(sourceImage, destImage, imageType);

                var imagePath = outputImageDirectory + "/" + destinationImageName + "." + imageType;

                return Ok(imagePath);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
