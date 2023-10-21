using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Entities.AWS
{
    public class S3Object
    {

       public string Nome { get; set; }


        public MemoryStream InputStream { get; set; } 

        public string BucketName { get; set; }

     
    }
}
