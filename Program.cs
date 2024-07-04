
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion.FileTypes;
using HtmlAgilityPack;
using System.Net;
static string GetURl(HtmlNode node){
    Console.WriteLine(node.GetAttributeValue("src", "a"));
    return node.GetAttributeValue("src", "a");
     
}
string URL = "The Url";
var WEB = new HtmlWeb();
HtmlDocument htmlDocument = WEB.Load(URL);
List<String> Images = new List<String>();
var Nodes = htmlDocument.DocumentNode.SelectNodes("//img[contains(@class, 'ts-main-image')]"); // THis is an example will need to change depending on the website
foreach (var nodule in Nodes){
   Images.Add(GetURl(nodule));
}
 int x = 0;
Images.RemoveAt(0);
foreach (var image in Images){
    x++;
    string path = $@"filepath\image{x}.webp";
    string Outpath = $@"filepath\image{x}.jpg";

    WebClient Client = new WebClient ();
    Client.DownloadFile(image, path);
    GroupDocs.Conversion.Converter  converter = new GroupDocs.Conversion.Converter (path);
    ImageConvertOptions options = new ImageConvertOptions
    { 
       Format = ImageFileType.Jpg,
    };
    converter.Convert(Outpath, options);
    string filePath = path;

    if (File.Exists(filePath))// cleans up the webp files
    {
        // Delete the file
        File.Delete(filePath);
    }
}

  

