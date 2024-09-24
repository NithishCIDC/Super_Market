using FluentValidation;
using SuperMarket.Domain.Models;

namespace SuperMarket.Domain.Validation
{
	public class Validation : AbstractValidator<ProductModel>
	{
		public Validation()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name of the Product is required");

			RuleFor(x=> x.Quantity)
				.NotEmpty().WithMessage("Quantity is required")
				.GreaterThanOrEqualTo(0).WithMessage("Quantity Should be Greater than or equal to 0");

			RuleFor(x => x.Price)
				.NotEmpty().WithMessage("Price is Required")
				.GreaterThanOrEqualTo(0).WithMessage("Price Should be Greater than or equal to 0");

			RuleFor(x=> x.Discount)
				.NotEmpty().WithMessage("Discount is Required")
				.LessThanOrEqualTo(100).WithMessage("Discount Percentage Should be Less than or equal to 100")
				.GreaterThanOrEqualTo(0).WithMessage("Discount Percentage Should be Greater than or equal to 0");
		}
	}

}
