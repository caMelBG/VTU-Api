using ImageAPI.Converter;
using ImageAPI.Enums;
using System;
using System.Web.Http;
using System.Web.Hosting;
using ImageAPI.Resizer;
using ImageAPI.Resizer.Strategies;

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

        [HttpGet]
        public IHttpActionResult Resize(string sourceImagePath, string destinationImageName, ResizeType resizeType, int width, int height, int x, int y)
        {
            try
            {
                var lastIndex = sourceImagePath.LastIndexOf('/');
                var outputImageDirectory = sourceImagePath.Substring(0, lastIndex);
                var imageName = sourceImagePath.Substring(lastIndex + 1, sourceImagePath.Length - lastIndex - 1);
                var extension = this.GetFileExtension(imageName);
                var srcImage = HostingEnvironment.MapPath(sourceImagePath);
                var destImage = HostingEnvironment.MapPath(outputImageDirectory + "/" + destinationImageName + "." + extension);
                var imagePath = outputImageDirectory + "/" + destinationImageName + "." + extension;

                var resizer = new Resizer(new ResizeStrategyCreator());
                resizer.Resize(srcImage, destImage, resizeType, width, height, x, y);

                return Ok(imagePath);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GetFileExtension(string fileName)
        {
            var indexOf = fileName.LastIndexOf('.');
            var extension = fileName.Substring(indexOf + 1, fileName.Length - indexOf - 1);
            return extension;
        }
    }
}
