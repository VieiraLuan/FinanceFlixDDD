using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using FinanceFlix.Domain.Entities.AWS;
using FinanceFlix.Domain.Interfaces.IServices.IAWS;


namespace FinanceFlix.Domain.Services.AWS
{
    public class StorageService : IStorageService
    {



        public async Task<S3Response> UploadFileAsync(S3Object s3Object, Entities.AWS.AWSCredentials awsCredentials)
        {

            //aws credentials
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            //region
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new S3Response();

            try
            {
                //upload Request
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = s3Object.InputStream,
                    Key = s3Object.Nome,
                    BucketName = s3Object.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                //S3 Client
                var client = new AmazonS3Client(credentials, config);


                //Transfer Utility to S3
                var fileTransferUtility = new TransferUtility(client);

                //Uploading the file to S3
                await fileTransferUtility.UploadAsync(uploadRequest);

                response.StatusCode = 200;
                response.Message = $"{s3Object.Nome} foi carregado com sucesso";

            }
            catch (AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {

                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;


        }


    }
}
