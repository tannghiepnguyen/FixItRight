using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FixItRight_Service.IServices;
using Microsoft.AspNetCore.Http;

namespace FixItRight_Service.Services
{
	public sealed class BlobService : IBlobService
	{
		private readonly BlobServiceClient blobServiceClient;

		public BlobService(BlobServiceClient blobServiceClient)
		{
			this.blobServiceClient = blobServiceClient;
		}
		public async Task<bool> DeleteBlob(string blobName, string containerName)
		{
			BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
			BlobClient blobClient = containerClient.GetBlobClient(blobName);

			return await blobClient.DeleteIfExistsAsync();
		}

		public async Task<string> GetBlob(string blobName, string containerName)
		{
			BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
			BlobClient blobClient = containerClient.GetBlobClient(blobName);

			return blobClient.Uri.AbsoluteUri;
		}

		public async Task<string> UploadBlob(string blobName, string containerName, IFormFile file)
		{
			BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
			BlobClient blobClient = containerClient.GetBlobClient(blobName);

			var httpHeaders = new BlobHttpHeaders
			{
				ContentType = file.ContentType
			};
			var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
			if (result is not null)
			{
				return await GetBlob(blobName, containerName);
			}
			return "";
		}
	}
}
