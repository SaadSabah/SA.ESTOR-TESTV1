internal static class FileSaveExtensionHelpers
{
	public static async Task SaveAsAsync(this IFormFile formFile, string filePath)
	{
		using (var stream = new FileStream(filePath, FileMode.Create))
		{
			await formFile.CopyToAsync(stream);
		}
	}
}