﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class HttpPostedFileBaseCustom : HttpPostedFileBase
    {
        MemoryStream stream;
        string contentType;
        string fileName;

        public HttpPostedFileBaseCustom(MemoryStream stream, string contentType, string fileName)
        {
            this.stream = stream;
            this.contentType = contentType;
            this.fileName = fileName;
        }

        public override int ContentLength
        {
            get { return (int)stream.Length; }
        }

        public override string ContentType
        {
            get { return contentType; }
        }

        public override string FileName
        {
            get { return fileName; }
        }

        public override Stream InputStream
        {
            get { return stream; }
        }

    }

}