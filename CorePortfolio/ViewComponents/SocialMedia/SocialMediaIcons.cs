using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.SocialMedia
{
    public class SocialMediaIcons:ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values=socialMediaManager.TGetList();
            return View(values);
        }

    }
}
