using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using ImageResizer;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

public class SaveUploadedFileController : ApiController
{
    public HttpResponseMessage SaveUploadedFile()
    {
        string hostUrl = ConfigurationManager.AppSettings["ServiceHost"];

        string imageWidthThumbnail = ConfigurationManager.AppSettings["ImageWidthThumbnail"];
        string imageWidthFullSize = ConfigurationManager.AppSettings["ImageWidthFullSize"];

        string imageQualityThumbnail = ConfigurationManager.AppSettings["ImageQualityThumbnail"];
        string imageQualityFullSize = ConfigurationManager.AppSettings["ImageQualityFullSize"];

        string fName = "";
        try
        {
            var timePopId = HttpContext.Current.Request.Form["timepopid"];

            HttpFileCollection fileCollection = HttpContext.Current.Request.Files;

            foreach (string fileName in fileCollection)
            {
                var file = fileCollection[fileName];

                fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    var outputPath = HttpContext.Current.Server.MapPath(@"\");

                    outputPath += "Images\\UserData\\";

                    var tmpVal = fName.Split('\\');
                    var tmpVal2 = tmpVal[tmpVal.Length - 1].Split('.');

                    var imageId = ObjectId.GenerateNewId().ToString();

                    var inputFilePathFullSize = outputPath + "FullSize_" + imageId + "." + tmpVal2[1];
                    file.SaveAs(inputFilePathFullSize);

                    var inputFilePathThumbnail = outputPath + "Thumbnail_" + imageId + "." + tmpVal2[1];
                    file.SaveAs(inputFilePathThumbnail);

                    // Resize large image
                    ImageBuilder.Current.Build(file, inputFilePathFullSize, new ResizeSettings("width=" + imageWidthFullSize + "&quality=" + imageQualityFullSize));
                    
                    // Need to create thumbnail too!
                    ImageBuilder.Current.Build(file, inputFilePathThumbnail, new ResizeSettings("width=" + imageWidthThumbnail + "&quality=" + imageQualityThumbnail));

                    var tmpPath = inputFilePathFullSize.Split('\\');

                    var htmlPath = hostUrl + "/Images/UserData/" + tmpPath[tmpPath.Length-1];

                    return Request.CreateResponse<string>(HttpStatusCode.OK, htmlPath);
                }
            }
        }
        catch (Exception ex)
        {
            return Request.CreateResponse<string>(HttpStatusCode.SeeOther, "Error: " + ex.ToString());
        }
        return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Error: unknown");
    }
}
