using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ImageAPI.Enums;
using ImageAPI.Resizer;
using ImageAPI.Converter;
using ImageAPI.Resizer.Strategies;

namespace MvcClient.Controllers
{
    public enum ProcessType
    {
        Default,
        Convert,
        Resize,
    }

    public class ProcessImageModel
    {
        public ProcessType ProceesType { get; set; }
        public string InputImagePath { get; set; }
        public string OutputFileName { get; set; }
        public ImageType ImageType { get; set; }
        public ResizeType ResizeType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult WebApiDemo()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessImage(ProcessImageModel model)
        {
            Exception exception = null;
            if (model == null)
            {
                exception = new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.InputImagePath))
            {
                exception = new ArgumentNullException(nameof(model.InputImagePath));
            }

            if (string.IsNullOrEmpty(model.OutputFileName))
            {
                exception = new ArgumentNullException(nameof(model.OutputFileName));
            }

            try
            {
                var lastIndex = model.InputImagePath.LastIndexOf('/');
                var outputImageDirectory = model.InputImagePath.Substring(0, lastIndex);
                var imageName = model.InputImagePath.Substring(lastIndex + 1, model.InputImagePath.Length - lastIndex - 1);
                var srcImage = Server.MapPath(model.InputImagePath);
                var destImage = string.Empty;
                var imagePath = string.Empty;
                if (model.ProceesType == ProcessType.Convert)
                {
                    destImage = Server.MapPath(outputImageDirectory + "/" + model.OutputFileName + "." + model.ImageType);
                    imagePath = outputImageDirectory + "/" + model.OutputFileName + "." + model.ImageType;

                    var converter = new Converter();
                    converter.Convert(srcImage, destImage, model.ImageType);
                }
                else if (model.ProceesType == ProcessType.Resize)
                {
                    var extension = this.GetFileExtension(imageName);
                    destImage = Server.MapPath(outputImageDirectory + "/" + model.OutputFileName + "." + extension);
                    imagePath = outputImageDirectory + "/" + model.OutputFileName + "." + extension;

                    var resizer = new Resizer(new ResizeStrategyCreator());
                    resizer.Resize(srcImage, destImage, model.ResizeType, model.Width, model.Height, model.StartX, model.StartY);
                }
                else
                {
                    var ex = new ArgumentException($"Invalid process type: {model.ProceesType}");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Content(ex.Message);
                }

                if (exception != null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Content(exception.Message);
                }

                return Json(imagePath);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase image)
        {
            if (image == null)
            {
                var ex = new ArgumentNullException(nameof(image));
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }

            try
            {
                var rootPath = Server.MapPath("~/Content/");
                var fileName = Path.Combine(rootPath, image.FileName);
                image.SaveAs(fileName);
                return Json($"../Content/{image.FileName}");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
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
