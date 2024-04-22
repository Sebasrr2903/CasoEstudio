using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes
{
	public static class LikeErrors
	{
		public static Error NotFound() =>
			new Error("Likes.NOT_FOUND", $"The Like was not found.");

		public static Error NotCreated() =>
			new Error("Likes.NOT_CREATED", "The Like was not  created.");
	}
}
