namespace NoLink.Data
{
	public class DataConstants
	{
		public class Service
		{
			public const int ServiceNameMaxLength = 130;
			public const int ServiceNameMinLength = 10;

			public const int ServiceDescriptionMaxLength = 550;
			public const int ServiceDescriptionMinLength = 50;

			public const int ServiceImageUrlMaxLength = 550;
			public const int ServiceImageUrlMinLength = 20;
		}
		public class Category
		{
			public const int CategoryNameMaxLength = 130;
			public const int CategoryNameMinLength = 10;
		}
		public class User
		{
			public const int UsernameMaxLength = 42;
			public const int UsernameMinLength = 6;

			public const int EmailMaxLength = 50;
			public const int EmailMinLength = 3;

			public const int PasswordMaxLength = 5012;
			public const int PasswordMinLength = 8;

		}
		public class Article
		{
			public const int TitleMaxLength = 45;
			public const int TitleMinLength = 3;

			public const int TextMaxLength = 15000;
			public const int TextMinLength = 250;

		}

		public class Testimonial
		{
			public const int NameMaxLength = 20;
			public const int NameMinLength = 10;

			public const int TextMaxLength = 1250;
			public const int TextMinLength = 50;
		}

		public class File
		{
			public const int ImageNameMaxLength = 100;
			public const int ImageContentTypeMaxLength = 50;
		}
	}
}
