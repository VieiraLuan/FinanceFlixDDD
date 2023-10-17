
using FinanceFlix.Domain.Entities.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Interfaces.IServices.IAWS
{
    public interface IStorageService
    {

        Task<S3Response> UploadFileAsync(S3Object s3Object, AWSCredentials awsCredentials);



    }
}
