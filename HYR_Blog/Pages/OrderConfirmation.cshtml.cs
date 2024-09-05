using Dto.Payment;
using HYR_Blog.Areas;
using HYR_Blog.CoreLayer.Dtos.PayDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ZarinPal.Class;

namespace HYR_Blog.Pages
{
    public class OrderConfirmationModel : BaseRazorModel
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;

        public OrderConfirmationModel(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        //property
        [BindProperty]
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = " نام و نام خانوادگی :")]
        public string FullName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "استان :")]
        public string State { get; set; }
        [BindProperty]
        [Display(Name = "شهر")]

        [Required(ErrorMessage = "{0} الزامی است")]
        public string City { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "کد پستی")]

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "آدرس دقیق")]
        [DataType(DataType.MultilineText)]
        public string ContinueAddress { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "شماره همراه")]

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (!User.Identity.IsAuthenticated)
                return Redirect("/User/Login");


            int UserId = Convert.ToInt32(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            string? CartCode = Request.Query["HyrCart"];

            MyResultWithoutData resultConfirmation = _scopeFacadPattern.SaveOrderConfirmationService.
                SaveOrderConfirmation(new CoreLayer.Dtos.OrderDto.OrderConfirmationDto()
                {
                    City = City,
                    State = State,
                    PostalCode = PostalCode,
                    ContinueAddress = ContinueAddress,
                    PhoneNumber = PhoneNumber,
                    FullName = FullName,
                    UserId = UserId,
                });
            MyResult<ResultCreatePayDto> CreatePayResult = _scopeFacadPattern.
                CreateNewPayService.CreateNewPay(UserId, CartCode);
            if (CreatePayResult.StatusCode == StatusCodeEnum.Failed)
                return Failed(CreatePayResult, Page());


            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = $"{CreatePayResult.data.PhoneNumber}",
                CallbackUrl = "https://localhost:44389/home/validate",
                Description = "توضیحات",
                Amount = CreatePayResult.data.TotalPrise,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");

        }

    }
}
