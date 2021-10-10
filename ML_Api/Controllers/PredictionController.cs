using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWE_ML_RestML.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ML_Api.Controllers
{
	[ApiController]
	public class PredictionController : ControllerBase
	{
		[HttpPost("predict")]
		public ActionResult<string> Predict([FromBody] ImageDTO imageDto)
		{
			// converting to image, saving it and passing the path to the model input
			var imageBytes = Convert.FromBase64String(imageDto.base64);
			using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
			{
				Image image = Image.FromStream(ms, true);
				image.Save(@".\Images\temp.jpeg");

				ModelInput input = new ModelInput()
				{
					ImageSource = @".\Images\temp.jpeg"
				};

				var predictionResult = ConsumeModel.Predict(input);

				return predictionResult.Prediction;
			}
		}
	}
}
