//using eCinema.Domain.DomainModels;
//using eCinema.Repository.Interface;
//using eCinema.Services.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eCinema.Services.Implementation
//{
//    public class BackgroundEmailSender : IBackgroundEmailSender
//    {
//        private readonly IEmailService _emailService;
//        private readonly IRepository<EmailMessage> _emailRepository;

//        public BackgroundEmailSender(IEmailService emailService, IRepository<EmailMessage> emailRepository)
//        {
//            _emailRepository = emailRepository;
//            _emailService = emailService;
//        }
//        public async Task DoWork()
//        {
//            await _emailService.SendEmailASync(_emailRepository.GetAll().Where(z => !z.Status).ToList());
//        }
//    }
//}
