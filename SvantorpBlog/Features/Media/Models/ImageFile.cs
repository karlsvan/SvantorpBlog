using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace SvantorpBlog.Features.Media.Models
{
    [ContentType(DisplayName = "ImageFile", GUID = "875b3b51-e0a7-412c-8f56-44f59c184440", Description = "Used for images of different file formats.")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {
        public virtual string AltText { get; set; }
    }
}
